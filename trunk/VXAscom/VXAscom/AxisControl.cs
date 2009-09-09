using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

using ASCOM.Helper;

namespace ASCOM.VXAscom
{
    /**
     * @brief
     * Base class to control the micro controller for a single axis
     */
    abstract public class AxisControl
    {
        protected const int motorSteps = 96; ///< Number of steps for single rotation of the motor
        protected const int wormGearing = 120; ///< Number of motor rotations for one wormwheel rotation
        protected const int axisGearing = 144; ///< Number of wormwheel rotations for one axis rotation                              
        protected const double kDegreesPerStep = 360.0 / (motorSteps * wormGearing * axisGearing);

        protected IControllerConnect iController;

        protected double iZeroPoint;

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
        public double Angle
        {
            get
            {
                return GetPosition() * kDegreesPerStep - iZeroPoint;
            }
            set
            {
                double currentAngle = GetPosition() * kDegreesPerStep;
                iZeroPoint = currentAngle - value;
            }
        }

        protected Int32 ReadInt(Registers aRegister)
        {
            return iController.Read(aRegister);
        }

        protected abstract Int32 GetPosition();

        public void StartRotate()
        {
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
