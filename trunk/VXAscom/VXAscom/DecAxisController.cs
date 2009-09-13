using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace ASCOM.VXAscom
{
    namespace Axis
    {
        using Controller;

        public class DecAxisController : AxisControl
        {

            public DecAxisController(IControllerConnect aController)
                : base(aController)
            {
            }

            protected override void SetPosition(int aPosition)
            {
                throw new System.NotImplementedException();
            }

            protected override int CBacklash
            {
                get
                {
                    throw new System.NotImplementedException();
                }
                set
                {
                    throw new System.NotImplementedException();
                }
            }
        }
    }
}
