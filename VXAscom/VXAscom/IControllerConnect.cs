using System;
using System.Collections.Generic;
using System.Text;

namespace ASCOM.VXAscom
{
    /**
     * @brief
     * Interface to the controller that drives the telescope
     * 
     * Through this interface we simulate the micro controller
     * as having a set of registers that we can read and write
     */
    namespace Controller
    {
        /// <summary>
        /// Name of registers in the simulated micro controller
        /// </summary>
        public enum Registers
        {
            RaPosition,     //!< Current position of RA axis
            RaTarget,       //!< Target position of the RA axis
            RaBacklash,     //!< Number of pulses to correct for backlash of the RA axis
            RaLimit,        //!< Below this limit no ramping takes place
            RaAcceleration, //!< Acceleration in tracking/sec for the RA axis
            RaAccUpdate,    //!< Acceleration update interval in msec for the RA axis
        }

        public enum Commands
        {
            RaGotoStart,        //!< Start GoTo for the RA axis
            RaGotoStop,         //!< Stop GoTo for the RA axis
        }

        /// <summary>
        /// Interface defining access to the micro controller
        /// </summary>
        /// <seealso cref="Registers"/>
        public interface IControllerConnect
        {
            /// <summary>
            /// Read register
            /// </summary>
            /// <param name="aRegister">The register to read</param>
            /// <returns>The value of register aRegister</returns>
            Int32 Read(Registers aRegister);

            /// <summary>
            /// Write a register
            /// </summary>
            /// <param name="aRegister">The register to write</param>
            /// <param name="aValue">The value to write to register aRegister</param>
            void Write(Registers aRegister, Int32 aValue);

            /// <summary>
            /// Write a command
            /// </summary>
            /// <param name="aCommand">The command to write</param>
            void Command(Commands aCommand);
        }
    }
}
