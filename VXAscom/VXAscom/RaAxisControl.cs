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
                    {AxisStatus.AccelerationLimit, Registers.RaLimit},
                    {AxisStatus.Position, Registers.RaPosition}
                };

                // Set the default values for the RA status registers
                StatusValues = new Dictionary<AxisStatus, Int32> { 
                    {AxisStatus.Acceleration, 2510},
                    {AxisStatus.AccelerationUpdate, 20},
                    {AxisStatus.AccelerationLimit, 20},
                };

            }

            protected override void SetPosition(int aPosition)
            {
                throw new System.NotImplementedException();
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
