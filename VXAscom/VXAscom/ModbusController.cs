using System;
using System.Collections.Generic;
using System.Text;

namespace ASCOM.VXAscom.Controller
{
    class ModbusController : IControllerConnect
    {
        #region IControllerConnect Members

        public bool ReadStatus(uint idx)
        {
            throw new System.NotImplementedException();
        }

        public void WriteStatus(uint idx, bool stat)
        {
            throw new System.NotImplementedException();
        }

        public short ReadRoRegister(uint idx)
        {
            throw new System.NotImplementedException();
        }

        public short ReadRegister(uint idx)
        {
            throw new System.NotImplementedException();
        }

        public void WriteRegister(uint idx, short value)
        {
            throw new System.NotImplementedException();
        }

        public int ReadRegister32(uint idx)
        {
            throw new System.NotImplementedException();
        }

        public void WriteRegister32(uint idx, int value)
        {
            throw new System.NotImplementedException();
        }

        public bool Connected
        {
            get { throw new System.NotImplementedException(); }
        }

        #endregion
    }
}
