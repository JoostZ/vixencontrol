using System;
using System.Collections.Generic;
using System.Text;

using dnAnalytics.LinearAlgebra;
using AAnet;

namespace AstroCoordinates
{
#if DEBUG
    using NUnit.Framework;
    using NUnit.Framework.SyntaxHelpers;
#endif

    class Coordinate
    {
        private DenseVector iVector;
        private Angle iTheta;
        private Angle iPhi;

        public Coordinate(Angle aTheta, Angle aPhi)
        {
            iTheta = aTheta;
            iPhi = aPhi;

            InitVector();
        }

        public Coordinate(DenseVector aVector)
        {
            iVector = aVector;
            InitAngles();
        }

        public Angle Theta
        {
            get
            {
                return iTheta;
            }
            set
            {
                iTheta = value;
                InitVector();
            }
        }

        public Angle Phi
        {
            get
            {
                return iPhi;
            }
            set
            {
                iPhi = value;
                InitVector();
            }
        }

        public DenseVector Carthesian
        {
            get
            {
                return iVector;
            }
            set
            {
                iVector = value;
                InitAngles();
            }
        }

        private void InitAngles()
        {
            double theta = Math.Atan2(iVector[1], iVector[0]);
            iTheta = Angle.FromRadians(theta);
            iPhi = Angle.FromRadians(Math.Asin(iVector[2]));
        }


        private void InitVector()
        {
            iVector = ToVector(iTheta.Radians, iPhi.Radians);
        }

        private DenseVector ToVector(double aTheta, double aPhi)
        {
            double cosTheta = Math.Cos(aTheta);
            double sinTheta = Math.Sin(aTheta);
            double cosPhi = Math.Cos(aPhi);
            double sinPhi = Math.Sin(aPhi);

            double[] theVector = new double[3] {
                cosPhi * cosTheta, 
                cosPhi * sinTheta,
                sinPhi
            };

            return new DenseVector(theVector);
        }
    }

#if DEBUG

    [TestFixture]
    public class TestCoordinate
    {
        [Test]
        public void Creation()
        {
            Angle theTheta = Angle.FromRadians(0.69112174);
            Angle thePhi = Angle.FromRadians(0.14718022);

            Coordinate theCoordinate = new Coordinate(theTheta, thePhi);
            Assert.That(theCoordinate.Theta.Degrees , Is.EqualTo(theTheta.Degrees).Within(0.000001));
            Assert.That(theCoordinate.Phi.Degrees, Is.EqualTo(thePhi.Degrees ).Within(0.0000001));
            Assert.That(theCoordinate.Carthesian[0], Is.EqualTo(0.76220092).Within(0.00000001));
            Assert.That(theCoordinate.Carthesian[1], Is.EqualTo(0.63051067).Within(0.00000001));
            Assert.That(theCoordinate.Carthesian[2], Is.EqualTo(0.14664943).Within(0.00000001));

            double[] theVector = new double[3] {0.49796223, 0.63051067, 0.59539065};
            theCoordinate.Carthesian = new DenseVector(theVector);
            Assert.That(theCoordinate.Theta.Degrees, Is.EqualTo(51.6992).Within(0.0001));
            Assert.That(theCoordinate.Phi.Degrees, Is.EqualTo(36.5405).Within(0.0001));
        }
    }

#endif
}
