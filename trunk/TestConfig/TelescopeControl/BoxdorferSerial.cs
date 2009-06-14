using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using NLog;

namespace TestConfig
{
    namespace Boxdorfer
    {
        public class BoxdorferSerial
        {
            public const byte writeLeftOn = 0xA8;
            public const byte writeLeftOff = 0xA9;
            public const byte writeRightOn = 0xAA;
            public const byte writeRightOff = 0xAB;
            public const byte writeOnOn = 0xAE;
            public const byte writeOnOff = 0xAF;
            public const byte writeFastOn = 0xB0;
            public const byte writeFastOff = 0xB1;
            public const byte readRaTargetPosition = 0xB2;
            public const byte writeRaTargetPosition = 0xB3;
            public const byte writeRaGotoStart = 0xB4;
            public const byte writeRaGotoStop = 0xB5;
            public const byte writeRaBacklash = 0x11;
            public const byte readRaBacklash = 0x12;
            public const byte readRALimit = 0xDE;
            public const byte writeRALimit = 0xBE;
            public const byte writeRAMicro = 0xD0;
            public const byte readRAMicro = 0xD4;
            public const byte readRaCurrentPos = 0xB7;
            public const byte resetRaCurrentPos = 0xB8;
            public const byte readRaAcceleration = 0xD5;
            public const byte writeRaAcceleration = 0xD6;
            public const byte readRaCurrentAccleration = 0xD9;
            public const byte readRaAccelerationUpdate = 0xDA;
            public const byte writeRaAccelerationUpdate = 0xDB;
            public const byte getVersion = 0xD7;

            private SerialPort iPort = null;
            private Form1 iForm = null;

            private Queue<IBoxdorferCommand> iCommandQueue = new Queue<IBoxdorferCommand>();
            private IBoxdorferCommand iCurrentCommand = null;
            private Logger iLogger = LogManager.GetCurrentClassLogger();

            public BoxdorferSerial(SerialPort aPort, Form1 aForm)
            {
                iLogger.Debug("Created BoxdorferSerial");
                iPort = aPort;
                iForm = aForm;
            }

            /**
             * @brief
             * Add a Boxdorfer command 
             * 
             * @param aCommand
             * The command to add
             * 
             * This executes the command if the serial port is not in use or queues it
             * to be executed when the port is free.
             */
            public void AddCommand(IBoxdorferCommand aCommand)
            {
                if (iCurrentCommand != null)
                {
                    iCommandQueue.Enqueue(aCommand);
                    return;
                }

                iCurrentCommand = aCommand;
                iCurrentCommand.SendCommand(this);

                if (iCurrentCommand.RequiredReturnBytes != 0)
                {
                    iForm.backgroundSerial.RunWorkerAsync(iCurrentCommand.RequiredReturnBytes);
                }
                else
                {
                    iCurrentCommand = null;
                }
            }

            public void Flush()
            {
                iCommandQueue.Clear();
                iCurrentCommand = null;
            }

            public void HandleByte(byte[] aByte)
            {
                if (iCurrentCommand == null)
                {
                    // Don't know where this is intended for
                    return;
                }

                iCurrentCommand.HandleReceived(aByte);

                while ((iCurrentCommand != null) && iCurrentCommand.Done)
                {
                    if (iCommandQueue.Count != 0)
                    {
                        iCurrentCommand = iCommandQueue.Dequeue();
                        iCurrentCommand.SendCommand(this);
                        if (iCurrentCommand.RequiredReturnBytes != 0)
                        {
                            iForm.backgroundSerial.RunWorkerAsync(iCurrentCommand.RequiredReturnBytes);
                        }
                        else
                        {
                            iCurrentCommand = null;
                        }
                    }
                    else
                    {
                        iCurrentCommand = null;
                    }
                }
            }

            public void SendByte(byte aByte)
            {
                byte[] cmd = new byte[1];
                cmd[0] = aByte;

                iPort.DiscardInBuffer();
                iPort.Write(cmd, 0, 1);
            }

            public void SendLong(long aValue)
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
                iPort.Write(cmds, 0, 8);
            }
        }
    }
}