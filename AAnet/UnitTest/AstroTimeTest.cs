using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using AAnet;

namespace UnitTest
{
    [TestFixture]
    public class AstroTimeTest
    {
        [Test]
        public void DateProperty()
        {
            DateTime dt = new DateTime(2003, 1, 1);
            AstroTime time = new AstroTime(dt);
            Assert.That(time.Date, Is.EqualTo(dt));
        }

        [Test]
        public void JDProperty()
        {
            DateTime dt = new DateTime(2003, 1, 1);
            AstroTime time = new AstroTime(dt);
            Assert.That(time.JD.ToDouble(), Is.EqualTo(2452640.5));
        }

        [Test]
        public void TimeParser()
        {
            string[] corrections = new string[] {
                "1972-01-01       +10       -       +42.23    -0.05",
                "1972-07-01       +11       -       +42.80    +0.38",
                "1973-01-01       +12       -       +43.37    +0.81",
                "1973-07-01        \"        -       +43.93    +0.25",
                "1974-01-01       +13       -       +44.49    +0.69",
                "1974-07-01        \"        -       +44.99    +0.19",
                "1975-01-01       +14       -       +45.48    +0.70",
                "1975-07-01        \"        -       +45.97    +0.21",
                "1976-01-01       +15       -       +46.46    +0.72",
                "1976-07-01        \"        14      +46.99    +0.19",
                "2010-01-01        \"        \"       +66.5     -0.3  (pred)",
                "2012-01-01        ?        ?       +68"
            };

            TimeConversion conversion = new TimeConversion(corrections);

            // Tests for time earlier then first entry
            DateTime dt = new DateTime(1970, 1, 1);
            TimeConverter conv = conversion.GetConverter(dt);
            Assert.That(10, Is.EqualTo(conv.TaiUtc));
            Assert.That(0, Is.EqualTo(conv.GpsUtc));
            Assert.That(42.23, Is.EqualTo(conv.TtUt1));
            Assert.That(-0.05, Is.EqualTo(conv.Ut1Utc));


            // Tests for time later than last entry
            dt = new DateTime(2020, 1, 1);
            conv = conversion.GetConverter(dt);
            Assert.That(15, Is.EqualTo(conv.TaiUtc));
            Assert.That(14, Is.EqualTo(conv.GpsUtc));
            Assert.That(68, Is.EqualTo(conv.TtUt1));
            Assert.That(-0.3, Is.EqualTo(conv.Ut1Utc));

            // Tests for time between first and second entry
            // Should return the first entry
            dt = new DateTime(1972, 3, 1);
            conv = conversion.GetConverter(dt);
            Assert.That(10, Is.EqualTo(conv.TaiUtc));
            Assert.That(0, Is.EqualTo(conv.GpsUtc));
            Assert.That(42.23, Is.EqualTo(conv.TtUt1));
            Assert.That(-0.05, Is.EqualTo(conv.Ut1Utc));

            // Tests for time just before the last one
            // Should return the last but one entry
            dt = new DateTime(2010, 3, 1);
            conv = conversion.GetConverter(dt);
            Assert.That(15, Is.EqualTo(conv.TaiUtc));
            Assert.That(14, Is.EqualTo(conv.GpsUtc));
            Assert.That(66.5, Is.EqualTo(conv.TtUt1));
            Assert.That(-0.3, Is.EqualTo(conv.Ut1Utc));

        }

        [Test]
        public void TestGMST()
        {
            AstroTime time = new AstroTime(new DateTime(2003, 1, 1));
            DateTime gmst = time.GMST;
            Assert.That(gmst.Hour, Is.EqualTo(6));
            Assert.That(gmst.Minute, Is.EqualTo(40));
            Assert.That(gmst.Second, Is.EqualTo(56));
            Assert.That(gmst.Millisecond, Is.EqualTo(954));


        }


    }
}
