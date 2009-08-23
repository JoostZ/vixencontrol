using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;



using AAnet;
	
namespace UnitTest
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    [TestFixture]
    public class JDTest
    {
        [Test]
        public void Conversion()
        {
            JulianDate jd = new JulianDate(new DateTime(2003, 1, 1));
            double JD = jd.ToDouble();

            Assert.AreEqual(JD, 2452640.5);

        }
        [Test]
        public void Subtract()
        {
            JulianDate jd = new JulianDate(new DateTime(2003, 1, 1));
            double JD = jd.ToDouble() - 1.5;

            Assert.That(jd - JD, Is.EqualTo(1.5));

        }

        [Test]
        public void ReverseConvert()
        {
            DateTime dt = new DateTime(2003, 3, 5, 13, 22, 4);
            JulianDate jd = new JulianDate(dt);
            Assert.That(dt, Is.EqualTo(jd.ToDateTime()));
        }

        [Test]
        public void ImplicitToDouble()
        {
            JulianDate jd = new JulianDate(new DateTime(2003, 1, 1));
            double jdd = jd;
            Assert.That(jdd, Is.EqualTo(jd.ToDouble()));
        }

        [Test]
        public void AddSecond()
        {
            JulianDate jd = new JulianDate(new DateTime(2003, 1, 1));
            JulianDate jd1 = new JulianDate(jd);
            jd1.AddSeconds(24);
            Assert.That(jd1 - jd, Is.EqualTo(24.0 / (3600 * 24)).Within(0.00000000000001));
            DateTime dt = jd1.ToDateTime();
            Assert.That(dt.Second, Is.EqualTo(24));
        }
    }
}
