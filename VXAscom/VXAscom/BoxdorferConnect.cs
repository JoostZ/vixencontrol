using System;
using System.Collections.Generic;
using System.Diagnostics;

using NLog;


using ASCOM.Helper;

namespace ASCOM.VXAscom
{
    namespace Controller
    {
        enum CommandByte
        {
            writeLeftOn = 0xA8,
            writeLeftOff = 0xA9,
            writeRightOn = 0xAA,
            writeRightOff = 0xAB,
            writeOnOn = 0xAE,
            writeOnOff = 0xAF,
            writeFastOn = 0xB0,
            writeFastOff = 0xB1,
            readRaTargetPosition = 0xB2,
            writeRaTargetPosition = 0xB3,
            writeRaGotoStart = 0xB4,
            writeRaGotoStop = 0xB5,
            writeRaBacklash = 0x11,
            readRaBacklash = 0x12,
            readRaFast = 0xDE,
            writeRaFast = 0xBE,
            writeRAMicro = 0xD0,
            readRAMicro = 0xD4,
            readRaCurrentPos = 0xB7,
            resetRaCurrentPos = 0xB8,
            readRaAccLowerLimit = 0xD1,
            writeRaAccLowerLimit = 0xD2,
            readRaAcceleration = 0xD5,
            writeRaAcceleration = 0xD6,
            readRaCurrentAccleration = 0xD9,
            readRaAccelerationUpdate = 0xDA,
            writeRaAccelerationUpdate = 0xDB,
            getVersion = 0xD7,
        }

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
                    {Registers.RaPosition, new AccessCommands {readCommand = (byte)CommandByte.readRaCurrentPos, 
                                                               writeCommand = null}},
                    {Registers.RaBacklash, new AccessCommands {readCommand = (byte)CommandByte.readRaBacklash,
                                                               writeCommand = (byte)CommandByte.writeRaBacklash}
                                                               },

                    {Registers.RaTarget, new AccessCommands {  readCommand = (byte)CommandByte.readRaTargetPosition,
                                                               writeCommand = (byte)CommandByte.writeRaTargetPosition}
                                                               },
                                                               
                    {Registers.RaAcceleration, new AccessCommands {  
                                                                readCommand = (byte)CommandByte.readRaAcceleration,
                                                                writeCommand = (byte)CommandByte.writeRaAcceleration}
                                                               },

                    {Registers.RaAccUpdate, new AccessCommands {  
                                                                readCommand = (byte)CommandByte.readRaAccelerationUpdate,
                                                                writeCommand = (byte)CommandByte.writeRaAccelerationUpdate}
                                                                },
                    {Registers.RaAccLimit, new AccessCommands {  
                                                                readCommand = (byte)CommandByte.readRaAccLowerLimit,
                                                                writeCommand = (byte)CommandByte.writeRaAccLowerLimit}
                                                                },
                   {Registers.RaFast, new AccessCommands {
                                                            readCommand = (byte)CommandByte.readRaFast,
                                                            writeCommand = (byte)CommandByte.writeRaFast}
                                                            },
                                                               
            };

            static private Dictionary<Commands, byte> commandMap = new Dictionary<Commands,byte> {
                    { Commands.RaGotoStart, (byte)CommandByte.writeRaGotoStart},
                    { Commands.RaGotoStop, (byte)CommandByte.writeRaGotoStop},
                    { Commands.RaTrackingOn, (byte)CommandByte.writeOnOn},
                    { Commands.RaTrackingOff, (byte)CommandByte.writeOnOff}, 
                    {Commands.RaFastOn, (byte)CommandByte.writeFastOn},
                    {Commands.RaFastOff, (byte)CommandByte.writeFastOff},
                    {Commands.RaLeftOn, (byte)CommandByte.writeLeftOn},
                    {Commands.RaLeftOff, (byte)CommandByte.writeLeftOff},
                    {Commands.RaRightOn, (byte)CommandByte.writeRightOn},
                    {Commands.RaRightOff, (byte)CommandByte.writeRightOff},
                };

            Serial _connection;
            public Serial Connection
            {
                get { return _connection; }
                set { _connection = value; }
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="aSerial">The serial port to use in the communication</param>
            public BoxdorferConnect(Serial aSerial)
            {
                Log = LogManager.GetCurrentClassLogger();
                Connection = aSerial;
                Log.Debug("Creating BoxdorfeConnect with serial for {0}", aSerial);
            }

            /// <summary>
            /// Default constructor
            /// </summary>
            public BoxdorferConnect()
            {
                Log =LogManager.GetCurrentClassLogger();
                Connection = null;
                Log.Debug("Creating BoxdorfeConnect without serial");
            }

            private Logger Log { get; set; }
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
                Log.Debug("SendLong {0}", aValue);
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
                        byte[] theReadData;
                        lock (Connection)
                        {
                            byte[] theCommand = { (byte)command };

                            Connection.TransmitBinary(ref theCommand);

                            theReadData = Connection.ReceiveCountedBinary(4);
                        }

                        UInt32 result = 0;
                        for (int i = 0; i < 4; ++i)
                        {
                            result = (result << 8) | theReadData[i];
                        }
                        Log.Debug("Read register {0} value = {1}", aRegister, result);
                        return (Int32)result;
                    }
                }
                Log.Debug("No connection while reading register {0}", aRegister);
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
                        lock (Connection)
                        {
                            SendLong(aValue);
                            byte[] theCommand = { (byte)command };

                            Connection.TransmitBinary(ref theCommand);
                        }
                    }
                }
            }

            /// <summary>
            /// Write a command to the micro controller
            /// </summary>
            /// <param name="aCommand"></param>
            public void Command(Commands aCommand)
            {
                Log.Debug("Send command {0}", aCommand);
                Debug.Assert(commandMap.ContainsKey(aCommand));
                if (Connection != null)
                {
                    lock (Connection)
                    {
                        byte[] theCommand = { commandMap[aCommand] };
                        Connection.TransmitBinary(ref theCommand);
                    }
                }
            }

            public bool Connected
            {
                get { return Connection != null && Connection.Connected; }
            }

            #endregion
        }
    }
}
