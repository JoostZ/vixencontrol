using System;
using System.Collections.Generic;
using System.Text;

namespace TestConfig
{
    using Boxdorfer;

    interface ISynchronizable
    {
        void Write(BoxdorferSerial theChannel);
        void Read(BoxdorferSerial theChannel);
    }
}
