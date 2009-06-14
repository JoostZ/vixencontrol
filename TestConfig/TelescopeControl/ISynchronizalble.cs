using System;
using System.Collections.Generic;
using System.Text;

namespace TelescopeControl
{
    using Boxdorfer;

    interface ISynchronizable
    {
        void Write(BoxdorferSerial theChannel);
        void Read(BoxdorferSerial theChannel);
    }
}
