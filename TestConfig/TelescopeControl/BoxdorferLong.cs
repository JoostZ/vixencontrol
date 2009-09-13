using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
//using NLog;

namespace TestConfig
{
    namespace Boxdorfer
    {
        /**
         * @brief
         * General class to handle the transmission of 32 bit integer between this program
         * and the controller.
         */
        public class BoxdorferLong : IBoxdorferCommand, ISynchronizable
        {
            //private Logger iLogger = LogManager.GetCurrentClassLogger();

            public event EventHandler ValueChanged;
            private Int32 iValue;
            private int count = 0;

            public Int32 Value
            {
                get
                {
                    return iValue;
                }
                set
                {
                    iValue = value;
                }
            }

            private byte iSendCommand;
            private byte iReceiveCommand;

            public BoxdorferLong(byte aSendCommand, byte aReceiveCommand)
            {
                //iLogger.Debug(String.Format("BoxdorferLong send {0:X}, receive {1:X}", aSendCommand, aReceiveCommand));
                iSendCommand = aSendCommand;
                iReceiveCommand = aReceiveCommand;
            }

            private bool isWriting = false;

            public void Write(BoxdorferSerial theChannel)
            {
                //iLogger.Debug(String.Format("BoxdorferLong Write {0:X}", iSendCommand));
                if (theChannel != null)
                {
                    isWriting = true;
                    theChannel.AddCommand(this);
                }
            }

            public void Read(BoxdorferSerial theChannel)
            {
                //iLogger.Debug(String.Format("BoxdorferLong Read {0:X}", iReceiveCommand));
                if (theChannel != null)
                {
                    isWriting = false;
                    theChannel.AddCommand(this);
                }
            }

            public bool Done
            {
                get
                {
                    return isWriting || count >= 4;
                }
            }

            public void HandleReceived(byte[] aByte)
            {
                Int32 theValue = 0;
                for (int i = 0; i < aByte.Length; i++)
                {
                    theValue = (theValue << 8) | (byte)aByte[i];
                    count++;
                    if (Done)
                    {
                        break;
                    }
                }
                //iLogger.Debug(String.Format("BoxdorferLong HandleReceived {0:X}", theValue));

                Value = theValue;

                if (Done && ValueChanged != null)
                {
                    ValueChanged(this, EventArgs.Empty);
                }
            }

            public int RequiredReturnBytes
            {
                get
                {
                    if (isWriting)
                    {
                        return 0;
                    }
                    else
                    {
                        return 4;
                    }
                }
            }

            public void SendCommand(BoxdorferSerial aPort)
            {
                if (isWriting)
                {
                    aPort.SendLong(iValue);
                    aPort.SendByte(iSendCommand);
                    count = 4;
                }
                else
                {
                    aPort.SendByte(iReceiveCommand);
                    count = 0;
                    iValue = 0;
                }

            }
        }
    }
}