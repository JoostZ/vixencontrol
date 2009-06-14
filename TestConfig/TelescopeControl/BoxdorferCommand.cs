using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace TelescopeControl
{
    namespace Boxdorfer
    {
        /**
         * @brief 
         * Handling a command without expected return bytes
         */
        public class BoxdorferCommand : IBoxdorferCommand
        {
            private Logger iLogger = LogManager.GetCurrentClassLogger();
            private byte iCmd;

            /**
             * @brief
             * Constructor
             * 
             * @param aCmd
             * The command to be sent
             */
            public BoxdorferCommand(byte aCmd)
            {
                iLogger.Debug(String.Format("Boxdorfer command {0:X}", aCmd));
                iCmd = aCmd;
            }

            /**
             * @brief
             * Send the command to the controler
             * 
             * @param theChannel
             * The serial connection to the controler
             */
            public void Send(BoxdorferSerial theChannel)
            {
                theChannel.AddCommand(this);
            }

            /**
             * @brief
             * Check if this command is done
             * 
             * As this command does not expect return bytes it will always be true.
             */
            public bool Done
            {
                get
                {
                    return true;
                }
            }

            /**
             * @brief 
             * Handle the bytes received from the controler
             * 
             * @param aByte
             * The returned bytes.
             * 
             * @note This command does not need to handle any return bytes
             */
            public void HandleReceived(byte[] aByte)
            {
            }

            public int RequiredReturnBytes
            {
                get
                {
                    return 0;
                }
            }

            public void SendCommand(BoxdorferSerial aPort)
            {
                aPort.SendByte(iCmd);
            }
        }
    }
}
