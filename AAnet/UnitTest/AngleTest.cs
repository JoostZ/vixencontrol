using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using AAnet;

namespace UnitTest
{
    [TestFixture]
    public class AngleTest
    {
        [Test]
        public void TestConstructor()
        {
            Angle angle = new Angle();
            Assert.That(angle.Degrees, Is.EqualTo(0.0));
            Assert.That(angle.Radians, Is.EqualTo(0.0));
        }

        [Test]
        public void TestAssignement()
        {
            Angle angle = new Angle();
            angle.Degrees = 30.0;
            Assert.That(angle.Degrees, Is.EqualTo(30.0));
            Assert.That(angle.Radians, Is.EqualTo(30.0 * Math.PI / 180.0));
        }

        [Test]
        public void TestParts()
        {
            Angle angle = Angle.FromDegrees(30, 12, 23.45);
            Assert.That(angle.Minutes, Is.EqualTo(12));
            Assert.That(angle.Seconds, Is.EqualTo(23.45).Within(0.005));

            angle = Angle.FromDegrees(-30, 12, 23.45);
            Assert.That(angle.Minutes, Is.EqualTo(12));
            Assert.That(angle.Seconds, Is.EqualTo(23.45).Within(0.005));
        }
    }
}
