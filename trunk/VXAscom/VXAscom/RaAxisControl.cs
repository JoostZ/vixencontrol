using System;
using System.Collections.Generic;

using ASCOM.Helper;

namespace ASCOM.VXAscom
{
    namespace Axis
    {
        using Controller;

        public class RaAxisControl : AxisControl
        {

            public RaAxisControl(IControllerConnect aController)
                : base(aController)
            {
                // Initialize the commands for the RA status registers
                StatusRegister = new System.Collections.Generic.Dictionary<AxisStatus, Registers> {
                    {AxisStatus.Acceleration, Registers.RaAcceleration},
                    {AxisStatus.AccelerationUpdate, Registers.RaAccUpdate},
                    {AxisStatus.AccelerationLimit, Registers.RaAccLimit},
                    {AxisStatus.Position, Registers.RaPosition},
                    {AxisStatus.Fast, Registers.RaFast},
                };

                // Set the default values for the RA status registers
                StatusValues = new Dictionary<AxisStatus, Int32> { 
                    {AxisStatus.Acceleration, 2410},
                    {AxisStatus.AccelerationUpdate, 25},
                    {AxisStatus.AccelerationLimit, 15},
                };

                CommandRegister = new Dictionary<AxisCommands, Commands> {
                    {AxisCommands.TrackingOn, Commands.RaTrackingOn},
                    {AxisCommands.TrackingOff, Commands.RaTrackingOff},
                    {AxisCommands.FastOn, Commands.RaFastOn},
                    {AxisCommands.FastOff, Commands.RaFastOff},
                    {AxisCommands.LeftOn, Commands.RaLeftOn},
                    {AxisCommands.LeftOff, Commands.RaLeftOff},
                    {AxisCommands.RightOn, Commands.RaRightOn},
                    {AxisCommands.RightOff, Commands.RaRightOff},
                };

            }

            protected override int CBacklash
            {
                get
                {
                    return ReadInt(Controller.Registers.RaBacklash);
                }
                set
                {
                    WriteInt(Controller.Registers.RaBacklash, value);
                }
            }

        }
    }
}
