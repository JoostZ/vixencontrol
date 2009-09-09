using System;
using System.Collections.Generic;


using ASCOM.Helper;

namespace ASCOM.VXAscom
{
    class AccessCommands
    {
        public byte? readCommand;
        public byte? writeCommand;
    }

    class BoxdorferConnect : IControllerConnect
    {
        static private Dictionary<Registers, AccessCommands> commands = 
            new Dictionary<Registers, AccessCommands> {
                {Registers.RaPosition, new AccessCommands {readCommand = 0xAA, 
                                                           writeCommand = 0xAB}}
        };
        Serial iSerial;
        BoxdorferConnect(Serial aSerial) {
            iSerial = aSerial;
        }

        #region IControllerConnect Members

        public int Read(Registers aRegister)
        {
            byte? command = commands[aRegister].readCommand;
            if (command.HasValue)
            {
                byte[] theCommand = { (byte)command }; // new byte[1];
                
                iSerial.TransmitBinary(ref theCommand);

                byte[] theReadData = iSerial.ReceiveCountedBinary(4);

                UInt32 result = 0;
                for (int i = 0; i < 4; ++i)
                {
                    result = (result << 8) | theReadData[i];
                }

                return (Int32)result;
            }
            return 0;
        }

        #endregion
    }
}
