using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Diagnostics;

using NUnit.Framework;

using AAnet;

using ASCOM.Helper;

namespace ASCOM.VXAscom
{
    namespace Axis
    {
        using Controller;

        public enum AxisStatus
        {
            Acceleration,
            AccelerationUpdate,
            AccelerationLimit,
            Position,
        };


        class Status
        {
            public Dictionary<AxisStatus, Int32> StatusValues
            {
                get; set;
            }
        };

        /**
         * @brief
         * Base class to control the micro controller for a single axis
         */
        public abstract class AxisControl : IUpdatable, INotifyPropertyChanged
        {
            Int32 tstAngle = 0;
     
            public const double  SiderialTrackingSpeed = 360.0 / ((23 * 60 +56) * 60 + 56.0);     

            protected const int motorSteps = 96; ///< Number of steps for single rotation of the motor
            protected const int wormGearing = 120; ///< Number of motor rotations for one wormwheel rotation
            protected const int axisGearing = 144; ///< Number of wormwheel rotations for one axis rotation                              
            protected const double kDegreesPerStep = 360.0 / (motorSteps * wormGearing * axisGearing);

            protected IControllerConnect iController;
            protected Dictionary<AxisStatus, Registers> iAxisCommands;

            protected Angle iZeroPoint = Angle.FromDegrees(12.12345);

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

            public string AngleString
            {
                get
                {
                    Angle theAngle = Angle;
                    return String.Format("{0} {1:00}\' {2:00.00}", (int)theAngle.Deg, theAngle.Minutes, theAngle.Seconds);
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

            public Int32 GetControllerStatus(AxisStatus aStatus)
            {
                Debug.Assert(StatusRegister.ContainsKey(aStatus));
                Controller.Registers theRegister = StatusRegister[aStatus];
                return ReadInt(theRegister);
            }

            public void SetControllerStatus(AxisStatus aStatus, Int32 aValue)
            {
                Debug.Assert(StatusRegister.ContainsKey(aStatus));
                Controller.Registers theRegister = StatusRegister[aStatus];
                WriteInt(theRegister, aValue);
            }

            public Int32 this[AxisStatus aStatus]
            {
                get
                {
                    return StatusValues[aStatus];
                }
                set
                {
                    if (StatusValues[aStatus] != value)
                    {
                        StatusValues[aStatus] = value;
                        SetControllerStatus(AxisStatus.Acceleration, value);
                    }
                }
            }

            public double Acceleration
            {
                get
                {
                    return this[AxisStatus.Acceleration] / 100.0;
                }
                set
                {
                    this[AxisStatus.Acceleration] = (int)(value * 100.0);
                }
            }

            public double AccUpdate
            {
                get
                {
                    return 0.1 * this[AxisStatus.AccelerationUpdate];
                }
                set
                {
                    this[AxisStatus.AccelerationUpdate] = (int)(value * 10);
                }
            }
            public double AccLimit
            {
                get
                {
                    return this[AxisStatus.AccelerationLimit];
                }
                set
                {
                    this[AxisStatus.AccelerationLimit] = (int)(value);
                }
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
            protected Int32 GetPosition()
            {
                return tstAngle;
                //return GetControllerStatus(AxisStatus.Position);
            }

            protected abstract void SetPosition(Int32 aPosition);

            protected Dictionary<AxisStatus, Registers> StatusRegister
            {
                get;
                set;
            }

            public Dictionary<AxisStatus, Int32> StatusValues
            {
                get; set;
            }

            public void LoadStatus()
            {
                foreach (AxisStatus stat in StatusRegister.Keys)
                {
                    StatusValues[stat] = ReadInt(StatusRegister[stat]);
                }
            }

            public void StoreStatus()
            {
                foreach (AxisStatus stat in StatusValues.Keys)
                {
                    WriteInt(StatusRegister[stat], StatusValues[stat]);
                }
            }


            protected abstract int CBacklash
            {
                get;
                set;
            }


            #region IUpdatable Members

            public void Update()
            {
                tstAngle += 1024;
                // This call will trigger users to read the Angle
                // which will be obtained from the controller
                NotifyPropertyChanged("Angle");
            }

            #endregion

            #region INotifyPropertyChanged Members

            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }

            #endregion
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
}
