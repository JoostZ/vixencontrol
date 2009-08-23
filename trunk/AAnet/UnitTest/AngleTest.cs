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
    }
}
