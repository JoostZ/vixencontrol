using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Diagnostics;

using NUnit.Framework;
using NLog;

using AAnet;

using ASCOM.Helper;

namespace ASCOM.VXAscom
{
    namespace Axis
    {
        using Controller;

        /// <summary>
        /// The registers defined for an axis
        /// </summary>
        /// <remarks>
        /// These are values for a generic axis. The actual registers are defined in the derived classes (for RA and DEC)
        /// </remarks>
        public enum AxisStatus
        {
            Acceleration,
            AccelerationUpdate,
            AccelerationLimit,
            Position,
        };

        /// <summary>
        /// The commands that can be sent to the controller
        /// </summary>
        /// <remarks>
        /// These are values for a generic axis. The actual commands are defined in the derived classes (for RA and DEC)
        /// </remarks>
        public enum AxisCommands
        {
            TrackingOn,
            TrackingOff,
            FastOn,
            FastOff,
            LeftOn,
            LeftOff,
            RightOn,
            RightOff
        };

        /// <summary>
        /// Base class for the control of an axis of the mount
        /// </summary>
        /// The class is based on the idea that the micro controller has a set of
        /// registers that can be read and written and a set of commands that can be
        /// sent to the controller.
        public abstract class AxisControl : IUpdatable, INotifyPropertyChanged
        {
     
            /// <summary>
            /// The tracking rate needed for siderial tracking in degrees per second
            /// </summary>
            public const double  SiderialTrackingSpeed = 360.0 / ((23 * 60 +56) * 60 + 56.0);     

            protected const int motorSteps = 96; ///< Number of steps for single rotation of the motor
            protected const int wormGearing = 120; ///< Number of motor rotations for one wormwheel rotation
            protected const int axisGearing = 144; ///< Number of wormwheel rotations for one axis rotation 
            
            /// <summary>
            /// The number of degrees the axis will turn for a single step of the motor
            /// </summary>
            protected const double kDegreesPerStep = 360.0 / (motorSteps * wormGearing * axisGearing);

            /// <summary>
            /// The interface to the controller 
            /// </summary>
            protected IControllerConnect iController;

            /// <summary>
            /// The zero point of the reported angle
            /// </summary>
            /// <remarks>
            /// The information we get from the controller has an arbitrary angle offset. In fact the
            /// controller will report an angle of 0 degrees when it is started. This field specifies
            /// an offset that will be added to the reported angle.
            /// </remarks>
            protected Angle iZeroPoint = Angle.FromDegrees(12.12345);

            protected System.Threading.Timer pulseTimer = null;

            protected AxisCommands pulseOffCommand;

            /// <summary>
            /// Switch the axis motor on (in slow speed) during a specified time
            /// </summary>
            /// <param name="aPositive">Direction to turn. true means in anti-clockwise direction</param>
            /// <param name="duration">The duration in milli seconds that the motor should turn</param>
            public void Pulse(bool aPositive, Int32 duration)
            {
                Logger theLog = LogManager.GetCurrentClassLogger();
                theLog.Debug("Pulse {0}, {1}", aPositive, duration);

                if (pulseOffCommand != 0)
                {
                    theLog.Debug("Already pulsing: ignore");
                    return;
                }

                // Switch to slow speed
                SendCommand(AxisCommands.FastOff);

                // Start turning in the right direction
                if (aPositive)
                {
                    theLog.Debug("Start pulse {0}", AxisCommands.RightOn);
                    SendCommand(AxisCommands.RightOn);
                    pulseOffCommand = AxisCommands.RightOff;
                }
                else
                {
                    theLog.Debug("Start pulse {0}", AxisCommands.LeftOn);
                    SendCommand(AxisCommands.LeftOn);
                    pulseOffCommand = AxisCommands.LeftOff;
                }

                // Start a timer
                pulseTimer = new System.Threading.Timer(PulseTimeout, this, duration, Timeout.Infinite);
            }

            private void EndPulse()
            {
                Logger theLog = LogManager.GetCurrentClassLogger();
                theLog.Debug("Stop pulse {0}", pulseOffCommand);
                // Stop the movement
                SendCommand(pulseOffCommand);
                pulseOffCommand = 0;

                // Go back to fast mode
                SendCommand(AxisCommands.FastOn);
            }
      
            static void PulseTimeout(object state)
            {
                AxisControl me = state as AxisControl;
                me.pulseTimer.Dispose();
                me.EndPulse();
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="aController">Access to the hardware controller</param>
            public AxisControl(IControllerConnect aController)
            {
                iController = aController;
                CurrentPosition = 0;
            }

            /// <summary>
            /// The angle (in degrees) of the position of this angle.
            /// </summary>
            /// <remarks>
            /// The zero point of the axis is arbitrary. In fact, setting the
            /// Angle defines the zero point.
            /// </remarks>
            public Angle Angle
            {
                get
                {
                    return Angle.FromDegrees(CurrentPosition * kDegreesPerStep) + iZeroPoint;
                }
                set
                {
                    Angle currentAngle = Angle.FromDegrees(CurrentPosition * kDegreesPerStep);
                    iZeroPoint = value - currentAngle;
                }
            }

            /// <summary>
            /// Angle as formatted string 
            /// </summary>
            public string AngleString
            {
                get
                {
                    Angle theAngle = Angle;
                    return String.Format("{0} {1:00}\' {2:00.00}", (int)theAngle.Deg, theAngle.Minutes, theAngle.Seconds);
                }
            }
            #region Controller interface

            /// <summary>
            /// Get an integer from the sepcified register
            /// </summary>
            /// <param name="aRegister">The register to read. It is the <i>axis specific</i> register</param>
            /// <returns>The read integer</returns>
            protected Int32 ReadInt(Controller.Registers aRegister)
            {
                return iController.Read(aRegister);
            }


            /// <summary>
            /// Write an integer to the sepcified register
            /// </summary>
            /// <param name="aRegister">The register to write to. It is the <i>axis specific</i> register</param>
            /// <param name="aValue">The value to write to aRegister</param>
            protected void WriteInt(Controller.Registers aRegister, Int32 aValue)
            {
                iController.Write(aRegister, aValue);
            }

            /// <summary>
            /// Write a command to the controller
            /// </summary>
            /// <param name="aCommand">The command to be written. It is the <i>axis specific</i> command</param>
            protected void WriteCommand(Controller.Commands aCommand)
            {
                iController.Command(aCommand);
            }

            /// <summary>
            /// Read a status register from the controller
            /// </summary>
            /// <param name="aStatus">The register to be read. It is the <i>generic axis</i> register</param>
            /// <returns>The value of the register</returns>
            public Int32 GetControllerStatus(AxisStatus aStatus)
            {
                Debug.Assert(StatusRegister.ContainsKey(aStatus));
                Controller.Registers theRegister = StatusRegister[aStatus];
                return ReadInt(theRegister);
            }

            /// <summary>
            /// Write a status register in the controller
            /// </summary>
            /// <param name="aStatus">The register to be written to. It is the <i>generic axis</i> register</param>
            /// <param name="aValue">The value to write in the register</param>
            public void SetControllerStatus(AxisStatus aStatus, Int32 aValue)
            {
                Debug.Assert(StatusRegister.ContainsKey(aStatus));
                Controller.Registers theRegister = StatusRegister[aStatus];
                WriteInt(theRegister, aValue);
            }

            /// <summary>
            /// Write a command to the controller
            /// </summary>
            /// <param name="aCommand">The command to be written. It is the <i>generic axis</i> command</param>
            public void SendCommand(AxisCommands aCommand)
            {
                Debug.Assert(CommandRegister.ContainsKey(aCommand));
                Controller.Commands theCommand = CommandRegister[aCommand];
                WriteCommand(theCommand);
            } 
            #endregion

            /// <summary>
            /// Access to the generic registers
            /// </summary>
            /// <param name="aStatus">The register to get or set</param>
            /// <returns>The value of the register</returns>
            /// <remarks>
            /// This property reflects a local cache. However when settin the property
            /// the value will also be written to the controller.
            /// </remarks>
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
                        SetControllerStatus(aStatus, value);
                    }
                }
            }
            #region Properties of the axis

            #region Acceleration related properties

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
            #endregion

            private bool _tracking;
            /// <summary>
            /// Get or Set if the axis is tracking
            /// </summary>
            public bool IsTracking
            {
                get
                {
                    return _tracking;
                }
                set
                {
                    //if (_tracking != value)
                    {
                        _tracking = value;
                        if (value)
                        {
                            SendCommand(AxisCommands.TrackingOn);
                        }
                        else
                        {
                            SendCommand(AxisCommands.TrackingOff);
                        }
        
                        NotifyPropertyChanged("Tracking");
                        
                    }
                }
            }

            /// <summary>
            /// Last read position from the controller
            /// </summary>
            private Int32 CurrentPosition { get; set; }

            /// <summary>
            /// The rate, in degrees per second, used in tracking
            /// </summary>
            public double TrackingRate
            { get; set; }

            protected abstract int CBacklash
            {
                get;
                set;
            }

            #endregion

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
                return GetControllerStatus(AxisStatus.Position);
            }

            /// <summary>
            /// Mapping between Axis generic and axis specific registers
            /// </summary>
            protected Dictionary<AxisStatus, Registers> StatusRegister
            {
                get;
                set;
            }

            /// <summary>
            /// Local cache of all axis generic registers
            /// </summary>
            public Dictionary<AxisStatus, Int32> StatusValues
            {
                get; set;
            }

            /// <summary>
            /// Mapping between axis generic and axis specific commands
            /// </summary>
            /// <example>
            /// For instance, for the RA axis TrackingOn maps to RaTrackingOn.
            /// </example>
            protected Dictionary<AxisCommands, Commands> CommandRegister { get; set; }

            /// <summary>
            /// Load all the registers from the controller into the local cache.
            /// </summary>
            public void LoadStatus()
            {
                foreach (AxisStatus stat in StatusRegister.Keys)
                {
                    StatusValues[stat] = ReadInt(StatusRegister[stat]);
                }
            }

            public Int32 LoadStatus(AxisStatus stat)
            {
                return StatusValues[stat] = ReadInt(StatusRegister[stat]);
            }

            /// <summary>
            /// Write all the registers from the local cache to the controller
            /// </summary>
            public void StoreStatus()
            {
                foreach (AxisStatus stat in StatusValues.Keys)
                {
                    WriteInt(StatusRegister[stat], StatusValues[stat]);
                }
            }



            #region IUpdatable Members

            public void Update()
            {
                if (iController.Connected)
                {
                    try
                    {
                        CurrentPosition = GetPosition();
                        // This call will trigger users to read the Angle
                        // which will be obtained from the controller
                        NotifyPropertyChanged("Angle");
                    }
                    catch (Exception ex)
                    {
                        ASCOM.Helper.Util util = new Util();
                        util.MessageBox(ex.Message, MessageBoxOptions.mbOKOnly, "Exception");
                    }
                }
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
