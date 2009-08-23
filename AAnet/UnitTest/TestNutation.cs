using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using AAnet;

namespace UnitTest
{
    [TestFixture]
    public class TestNutation
    {
        [Test]
        public void TestEquinox()
        {
            JulianDate jd = new JulianDate(new DateTime(2003, 1, 1));
            Nutation nut = new Nutation(jd);
            Assert.That(nut.EquationOfEquinox, Is.EqualTo(-0.9381).Within(0.00005));
            Assert.That(nut.DeltaPsi, Is.EqualTo(-15.340).Within(0.0005));
            Assert.That(nut.DeltaEpsilon, Is.EqualTo(3.024).Within(0.0005));
            Assert.That(nut.Epsilon.Seconds, Is.EqualTo(23.068));

            jd = new JulianDate(new DateTime(2003, 2, 1));
            nut = new Nutation(jd);

            Assert.That(nut.EquationOfEquinox, Is.EqualTo(-0.8444).Within(0.00005)); 
            Assert.That(nut.DeltaPsi, Is.EqualTo(-13.808).Within(0.0005));
            Assert.That(nut.DeltaEpsilon, Is.EqualTo(3.782).Within(0.0005));
            //Assert.That(nut.Epsilon, Is.EqualTo(Angle.FromDegrees(23, 26, 23.068)));
        }
    }
}
