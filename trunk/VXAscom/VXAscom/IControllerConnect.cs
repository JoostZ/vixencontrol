using System;
using System.Collections.Generic;
using System.Text;

namespace ASCOM.VXAscom
{
    public enum Registers
    {
        RaPosition
    }

    public interface IControllerConnect
    {
        Int32 Read(Registers aRegister);
    }
}
