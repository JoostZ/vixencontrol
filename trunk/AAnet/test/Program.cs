using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AAnet;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            JulianDate jd = new JulianDate(new DateTime(2003, 1, 1, 12, 42, 10, 500));
            DateTime result = jd.ToDateTime();
        }
    }
}
