using System;
using System.Collections.Generic;
using System.Diagnostics;


using ASCOM.Helper;

namespace ASCOM.VXAscom
{
    namespace Controller
    {
        /// <summary>
        /// Commands associated with the registers
        /// </summary>
        class AccessCommands
        {
            public byte? readCommand;
            public byte? writeCommand;
        }

        /// <summary>
        /// Implementation of the ICongtrollerConnect interface for the 
        /// Boxdörfer like interface.
        /// </summary>
        /// 
        /// This interface is based on the MTS3 interface from Boxdörfer. It uses
        /// a serial interface. The micro controller is accessed by sending single byte 
        /// commands over the serial link. 
        /// 
        /// For the reading of a register the controller will return a 4 byte integer
        /// 
        /// For the writing of a register, first send over the 4 byte integer and then
        /// send the write command.
        public class BoxdorferConnect : IControllerConnect
        {
            /// <summary>
            /// Mapping of the different registers to the required commands
            /// </summary>
            static private Dictionary<Registers, AccessCommands> accessMap =
                new Dictionary<Registers, AccessCommands> {
                    {Registers.RaPosition, new AccessCommands {readCommand = 0xAA, 
                                                               writeCommand = 0xAB}},
                    {Registers.RaBacklash, new AccessCommands {readCommand = 0x12,
                                                               writeCommand = 0x11}
                                                               },

                    {Registers.RaTarget, new AccessCommands {  readCommand = 0xB2,
                                                               writeCommand = 0xB3}
                                                               },

            };

            static private Dictionary<Commands, byte> commandMap = new Dictionary<Commands,byte> {
                    { Commands.RaGotoStart, 0xB4},
                    { Commands.RaGotoStop, 0xB5},
                };

            public Serial Connection
            {
                get;
                set;
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="aSerial">The serial port to use in the communication</param>
            BoxdorferConnect(Serial aSerial)
            {
                Connection = aSerial;
            }

            /// <summary>
            /// Default constructor
            /// </summary>
            public BoxdorferConnect()
            {
                Connection = null;
            }

            /// <summary>
            /// Write a 4 byte integer to the controller
            /// </summary>
            /// <param name="aValue">The value to send</param>
            /// <remarks>
            /// The protocol requires the 4 bytes to be split up in 8 nibbles.
            /// Each nibble is put in the lower bits of a byte while the top
            /// bits will be set to 0x80 for the high nibble and to 0x90 for
            /// the low nibble. These 8 bytes are then sent to the controller
            /// where the will be put into an input buffer, ready to be used
            /// by the next write command.
            /// </remarks>
            private void SendLong(Int32 aValue)
            {
                UInt32 theValue = (UInt32)aValue;
                byte[] cmds = new byte[8];
                for (int i = 0, j = 0; i < 4; i++)
                {
                    byte lowNibble = (byte)(theValue & 0xf);
                    theValue >>= 4;
                    byte highNibble = (byte)(theValue & 0xf);
                    theValue >>= 4;
                    cmds[j++] = (byte)(0x80 | highNibble);
                    cmds[j++] = (byte)(lowNibble | 0x90);
                }
                Connection.TransmitBinary(ref cmds);
            }
            #region IControllerConnect Members

            /// <summary>
            /// Read a register
            /// </summary>
            /// <param name="aRegister">The register to read</param>
            /// <returns>The value of aRegister</returns>
            public int Read(Registers aRegister)
            {
                Debug.Assert(accessMap.ContainsKey(aRegister));
                if (Connection != null)
                {
                    byte? command = accessMap[aRegister].readCommand;
                    if (command.HasValue)
                    {
                        byte[] theCommand = { (byte)command };

                        Connection.TransmitBinary(ref theCommand);

                        byte[] theReadData = Connection.ReceiveCountedBinary(4);

                        UInt32 result = 0;
                        for (int i = 0; i < 4; ++i)
                        {
                            result = (result << 8) | theReadData[i];
                        }

                        return (Int32)result;
                    }
                }
                return 0;
            }

            /// <summary>
            /// Write to a register
            /// </summary>
            /// <param name="aRegister">The register to write to</param>
            /// <param name="aValue">The new value of aRegister</param>
            public void Write(Registers aRegister, Int32 aValue)
            {
                Debug.Assert(accessMap.ContainsKey(aRegister));
                if (Connection != null)
                {
                    byte? command = accessMap[aRegister].writeCommand;
                    if (command.HasValue)
                    {
                        SendLong(aValue);
                        byte[] theCommand = { (byte)command };

                        Connection.TransmitBinary(ref theCommand);
                    }
                }
            }

            /// <summary>
            /// Write a command to the micro controller
            /// </summary>
            /// <param name="aCommand"></param>
            public void Command(Commands aCommand)
            {
                Debug.Assert(commandMap.ContainsKey(aCommand));
                if (Connection != null)
                {
                    byte[] theCommand = { commandMap[aCommand] };
                    Connection.TransmitBinary(ref theCommand);
                }
            }

            #endregion
        }
    }
}
