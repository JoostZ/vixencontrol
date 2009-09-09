using System;
using System.Collections.Generic;
using System.Text;


namespace AstroCoordinates
{
    using NUnit.Framework;
    using NUnit.Framework.SyntaxHelpers;

    /**
     * @brief
     * Representation of an angle
     */
    public class Angle
    {
        private enum AngleType {
            degree,
            radian
        }

        private const double RadRatio = Math.PI / 180.0;

        public static Angle FromDegree(double aAngle)
        {
            return new Angle(aAngle, AngleType.degree);
        }

        public static Angle FromRadians(double aValue)
        {
            return new Angle(aValue, AngleType.radian);
        }

        private Angle(double aValue, AngleType aType)
        {
            switch (aType)
            {
                case AngleType.degree:
                    Degrees = aValue;
                    break;
                case AngleType.radian:
                    Radians = aValue;
                    break;
                default:
                // Throw exception
                    break;
            }
        }

        public Angle(Angle aOther)
        {
            _Degrees = aOther._Degrees;
            _Radians = aOther._Radians;
        }

        public double Degrees
        {
            get
            {
                return _Degrees;
            }

            set
            {
                _Degrees = value;
                _Radians = ToRadians(value);
            }
        }

        public double Radians
        {
            get
            {
                return _Radians;
            }
            set
            {
                _Radians = value;
                _Degrees = ToDegrees(value);
            }
        }

        private double _Radians;
        private double _Degrees;

        private double ToRadians(double aValue)
        {
            return aValue * RadRatio;
        }

        private double ToDegrees(double aValue)
        {
            return aValue / RadRatio;
        }

        public static Angle operator *(double aFactor, Angle aAngle)
        {
            Angle result = new Angle(aAngle);

            result._Radians *= aFactor;
            result._Degrees *= aFactor;

            return result;
        }

        public static Angle operator+(Angle lhs, Angle rhs)
        {
            Angle result = new Angle(lhs);

            result._Radians += rhs._Radians;
            result._Degrees += rhs._Degrees;

            return result;
        }
        public static Angle operator -(Angle lhs, Angle rhs)
        {
            Angle result = new Angle(lhs);

            result._Radians -= rhs._Radians;
            result._Degrees -= rhs._Degrees;

            return result;
        }
    }

#if DEBUG

    [TestFixture]
    public class TestAngle
    {
        [Test]
        public void Creation()
        {
            Angle theAngle = Angle.FromDegree(30.2);
            Assert.That(theAngle.Degrees, Is.EqualTo(30.2).Within(0.1)); 
            Assert.That(theAngle.Radians, Is.EqualTo(0.527089).Within(0.000001));

            theAngle = Angle.FromRadians(0.52);
            Assert.That(theAngle.Radians, Is.EqualTo(0.52).Within(0.01));
            Assert.That(theAngle.Degrees, Is.EqualTo(29.7938).Within(0.0001));
        }

        [Test]
        public void Add()
        {
            Angle theAngle1 = Angle.FromDegree(30.2);
            Angle theAngle2 = Angle.FromRadians(0.52);
            Angle result = theAngle1 + theAngle2;
            Assert.That(result.Degrees, Is.EqualTo(30.2 + 29.7938).Within(0.00001));
            Assert.That(result.Radians, Is.EqualTo(0.52 + 0.527089).Within(0.000001));
        }
    }

#endif
}
