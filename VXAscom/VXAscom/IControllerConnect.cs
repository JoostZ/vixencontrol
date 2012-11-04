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
     * 
     * There are several types of registers:
     * - One bit status registers
     * - 32 bit Read-only registers
     * - 32 bit Read/Write registers
     * - float Read/Write registers
     */
    namespace Controller
    {
        /**
         * @brief boolean status registers
         */
        public enum StatusRegister
        {
            Left,
            Right,
            Up,
            Down,
            RaTracking,
            DecTracking,
            RaGoto,
            DecGoto,
            Fast,
        }

        /// <summary>
        /// Name of Read-only registers
        /// </summary>
        public enum RoRegisters
        {
            RaPosition,     //!< Current position of RA axis
            DePosition,     //!< Current position of Dec axis
        }

        public enum Registers {
            RaTarget,       //!< Target position of the RA axis
            DecTarget,      //!< Number of pulses to correct for backlash of the RA axis
         
        }

        public enum FloatRegisters
        {
            RaFast,
            DecFast,
            RaSlow,
            DecSlow
        }


        /// <summary>
        /// Interface defining access to the micro controller
        /// </summary>
        /// <seealso cref="Registers"/>
        public interface IControllerConnect
        {
            Boolean ReadStatus(StatusRegister aRegister);

            Int32 Read(RoRegisters aRegister);

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

            float Read(FloatRegisters aRegister);
            void Write(FloatRegisters aRegister, float aValue);

            bool Connected { get; }
        }
    }
}
