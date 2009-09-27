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
                StatusRegister = new System.Collections.Generic.Dictionary<Status, Registers> {
                    {Status.Acceleration, Registers.RaAcceleration},
                    {Status.AccelerationUpdate, Registers.RaAccUpdate},
                    {Status.AccelerationLimit, Registers.RaAccLimit},
                    {Status.Position, Registers.RaPosition},
                    {Status.Fast, Registers.RaFast},
                };

                // Set the default values for the RA status registers
                StatusValues = new Dictionary<Status, Int32> { 
                    {Status.Acceleration, 2410},
                    {Status.AccelerationUpdate, 25},
                    {Status.AccelerationLimit, 15},
                    {Status.Position, 0},
                    {Status.Fast, 20},
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
