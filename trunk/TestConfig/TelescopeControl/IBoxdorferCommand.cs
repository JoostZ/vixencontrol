using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace TestConfig
{
    namespace Boxdorfer
    {
        /**
         * @brief
         * Interface to handling Boxdorf commands
         * 
         * In the Boxdorf protocol the host sends a single byte command
         * and expects 0-4 bytes in response.
         */
        public interface IBoxdorferCommand
        {
            /**
             * @brief
             * Check if the command is done
             */
            bool Done { get; }

            /**
             * @brief
             * Send a single command to the controler
             * 
             * @param aPort
             * The serial port to which the controler is connected
             * */
            void SendCommand(BoxdorferSerial aPort);

            /**
             * @brief 
             * Handle the received response from the controler
             * 
             * @param aByte
             * The bytes received from the controler
             */
            void HandleReceived(byte[] aByte);

            /**
             * The number of bytes to receive after the command has been sent
             */
            int RequiredReturnBytes { get; }
        }
    }
}