using System;

using ASCOM.Helper;

namespace ASCOM.VXAscom
{
    public class RaAxisControl :  AxisControl
    {
        const byte kReadPosition = 0xA1;

        RaAxisControl(IControllerConnect aController)
            : base(aController)
        {
        }

        protected override Int32 GetPosition()
        {
            return ReadInt(Registers.RaPosition);
        }
    }
}
