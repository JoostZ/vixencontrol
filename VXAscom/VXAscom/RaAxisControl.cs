using System;

using ASCOM.Helper;

namespace ASCOM.VXAscom
{
    using Controller;

    public class RaAxisControl :  AxisControl
    {

        public RaAxisControl(IControllerConnect aController)
            : base(aController)
        {
        }

        protected override Int32 GetPosition()
        {
            return ReadInt(Controller.Registers.RaPosition);
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
