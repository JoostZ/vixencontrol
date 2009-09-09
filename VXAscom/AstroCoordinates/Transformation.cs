using System;
using System.Collections.Generic;
using System.Text;

using dnAnalytics.LinearAlgebra;
using AAnet;

namespace AstroCoordinates
{
    using NUnit.Framework;
    using NUnit.Framework.SyntaxHelpers;

    class Transformation
    {
        private enum Axes
        {
            X, Y, Z
        }

        private DenseMatrix iMatrix;

        public double this[int row, int col]
        {
            get
            {
                return iMatrix[row, col];
            }
        }

        public Transformation()
        {
            iMatrix = new DenseMatrix(3);
            for (int i = 0; i < 3; i++)
            {
                iMatrix[i, i] = 1.0;
            }
        }

        public void RotateX(Angle aAngle)
        {
            Rotate(Axes.X, aAngle.Radians);
        }
        public void RotateY(Angle aAngle)
        {
            Rotate(Axes.Y, aAngle.Radians);
        }
        public void RotateZ(Angle aAngle)
        {
            Rotate(Axes.X, aAngle.Radians);
        }
        private void Rotate(Axes aAxis, double angle)
        {
            DenseMatrix theMatrix = new DenseMatrix(3);

            double cosAngle = Math.Cos(angle);
            double sinAngle = Math.Sin(angle);

            theMatrix[(int)aAxis, (int)aAxis] = 1;

            int xIdx = ((int)aAxis + 1) % 3;
            int yIdx = (xIdx + 1) % 3;

            theMatrix[xIdx, xIdx] = cosAngle;
            theMatrix[xIdx, yIdx] = -sinAngle;

            yIdx = xIdx;
            xIdx = (xIdx + 1) % 3;

            theMatrix[xIdx, xIdx] = cosAngle;
            theMatrix[xIdx, yIdx] = sinAngle;

            iMatrix = theMatrix * iMatrix;
        }

        public Coordinate Transform(Coordinate aCoordinate)
        {
            Vector theVector = aCoordinate.Carthesian;
            return new Coordinate(iMatrix * aCoordinate.Carthesian);
        }

        public void Transform(Transformation aTransformation)
        {
            iMatrix.Multiply(aTransformation.iMatrix);
        }

        public static Transformation RaDec2Ah(Angle aLattitude)
        {
            Transformation theTransformation = new Transformation();
            theTransformation.Rotate(Axes.Y, aLattitude.Radians - 0.5 * Math.PI);

            return theTransformation;
        }
    }
#if DEBUG

    [TestFixture]
    public class TestTransformation
    {
        [Test]
        public void Creation()
        {
            Transformation theTransform = new Transformation();
            theTransform.RotateY(Angle.FromRadians(0.88660302 - Math.PI / 2));

            Assert.That(theTransform[0, 0], Is.EqualTo(0.77492917).Within(0.00000001));
            Assert.That(theTransform[0, 1], Is.EqualTo(0.0));
            Assert.That(theTransform[0, 2], Is.EqualTo(-0.63204809).Within(0.00000001));
            Assert.That(theTransform[1, 0], Is.EqualTo(0.0));
            Assert.That(theTransform[1, 1], Is.EqualTo(1.0).Within(0.00000001));
            Assert.That(theTransform[1, 2], Is.EqualTo(0.0));
            Assert.That(theTransform[2, 0], Is.EqualTo(0.63204809).Within(0.00000001));
            Assert.That(theTransform[2, 1], Is.EqualTo(0.0).Within(0.00000001));
            Assert.That(theTransform[2, 2], Is.EqualTo(0.77492917).Within(0.00000001));

            

            
        }

        [Test]
        public void Transform()
        {
            Transformation theTransform = new Transformation();
            theTransform.RotateY(Angle.FromRadians(0.88660302 - Math.PI / 2));

            Angle theTheta = Angle.FromRadians(0.69112174);
            Angle thePhi = Angle.FromRadians(0.14718022);

            Coordinate theCoordinate = new Coordinate(theTheta, thePhi);
            theCoordinate = theTransform.Transform(theCoordinate);

            Assert.That(theCoordinate.Theta.Degrees, Is.EqualTo(51.6992).Within(0.0001));
            Assert.That(theCoordinate.Phi.Degrees, Is.EqualTo(36.5405).Within(0.0001));

            Angle theLatitude = Angle.FromRadians(0.88660302);
            theTransform = Transformation.RaDec2Ah(theLatitude); 
            theCoordinate = new Coordinate(theTheta, thePhi);
            theCoordinate = theTransform.Transform(theCoordinate);

            Assert.That(theCoordinate.Theta.Degrees, Is.EqualTo(51.6992).Within(0.0001));
            Assert.That(theCoordinate.Phi.Degrees, Is.EqualTo(36.5405).Within(0.0001));


        }

        [Test]
        public void ApparentToTrue()
        {
            Angle delta = Angle.FromRadians(-0.0026179939);
            Angle delta1 = Angle.FromRadians(0.0013962634);
            Angle delta2 = Angle.FromRadians(0.0034906585);

            Angle theta = Angle.FromRadians(1.08734012 + 0.0034906585);
            Angle phi = Angle.FromRadians(-0.93375115);

            Transformation theTransformation = new Transformation();
            theTransformation.RotateZ(delta1);
            theTransformation.RotateY(theta); ;
            theTransformation.RotateX(delta);
            theTransformation.RotateZ(phi);

            double[] list = new double[3] { 1, 0, 0 };
            Coordinate theCoordinate = new Coordinate(new DenseVector(list));
            theCoordinate = theTransformation.Transform(theCoordinate);
            Assert.That(theCoordinate.Carthesian[0], Is.EqualTo(0.27764743).Within(0.00000001));

        }
    }

#endif
}
