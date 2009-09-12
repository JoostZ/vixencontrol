using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

using AAnet;

using ASCOM.Helper;

namespace ASCOM.VXAscom
{
    using Controller;

    /**
     * @brief
     * Base class to control the micro controller for a single axis
     */
    public abstract class AxisControl
    {
        protected const int motorSteps = 96; ///< Number of steps for single rotation of the motor
        protected const int wormGearing = 120; ///< Number of motor rotations for one wormwheel rotation
        protected const int axisGearing = 144; ///< Number of wormwheel rotations for one axis rotation                              
        protected const double kDegreesPerStep = 360.0 / (motorSteps * wormGearing * axisGearing);

        protected IControllerConnect iController;

        protected Angle iZeroPoint;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="aController">Access to the hardware controller</param>
        public AxisControl(IControllerConnect aController)
        {
            iController = aController;
        }

        /**
         * @brief
         * The angle (in degrees) of the position of this angle.
         * 
         * The zero point of the axis is arbitrary. In fact, setting the
         * Angle defines the zero point.
         */
        public Angle Angle
        {
            get
            {
                return Angle.FromDegrees(GetPosition() * kDegreesPerStep) - iZeroPoint;
            }
            set
            {
                Angle currentAngle = Angle.FromDegrees(GetPosition() * kDegreesPerStep);
                iZeroPoint = currentAngle - value;
            }
        }

        /// <summary>
        /// Get an integer from the sepcified register
        /// </summary>
        /// <param name="aRegister">The register to read.</param>
        /// <returns>The read integer</returns>
        protected Int32 ReadInt(Controller.Registers aRegister)
        {
            return iController.Read(aRegister);
        }

        protected void WriteInt(Controller.Registers aRegister, Int32 aValue)
        {
            iController.Write(aRegister, aValue);
        }


        /// <summary>
        /// Get or Set if the axis is tracking
        /// </summary>
        public bool IsTracking
        { get; set; }

        /// <summary>
        /// The rate, in degrees per second, used in tracking
        /// </summary>
        public double TrackingRate
        { get; set; }

        /// <summary>
        /// Rotate around the axis to the specified target angle
        /// </summary>
        /// <param name="target">The angle to move to</param>
        public void Goto(Angle target)
        {
        }

        public virtual int Backlash
        {
            get;
            set;
        }

        public void StartRotate()
        {
        }


        /// <summary>
        /// Get the current position from the controller
        /// </summary>
        /// <returns>The current position</returns>
        /// <remarks>This an abstract function that must be implemented
        /// by the actual AxisControl</remarks>
        protected abstract Int32 GetPosition();

        protected abstract void SetPosition(Int32 aPosition);

        protected abstract int CBacklash
        {
            get;
            set;
        }

    }
#if DEBUG

    [TestFixture]
    public class TestAxisControl
    {
        class NotifyHandler
        {

        }


    }
#endif
}
