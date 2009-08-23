using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAnet
{
    /**
     * Helper class to manipulate and convert angles
     */
    public class Angle
    {
        double _radians;
        double _degrees;

        /**
         * Create an Angle object for 0 degrees
         */
        public Angle()
        {
            _radians = 0;
            _degrees = 0;
        }

        public Angle(Angle angle)
        {
            _radians = angle._radians;
            _degrees = angle._degrees;
        }

        public double Degrees
        {
            get
            {
                return _degrees;
            }
            set
            {
                _degrees = value;
                _radians = DegreesToRad(_degrees);
            }
        }

        public double Radians
        {
            get
            {
                return _radians;
            }
            set
            {
                _radians = value;
                _degrees = RadToDegrees(_radians);
            }
        }

        public double Seconds {
            get {
                double result = _degrees - (int)(_degrees);
                result *= 60;
                result -= (int)(result);
                result *= 60;
                return result;
            }
        }


        static public Angle FromDegrees(double degrees)
        {
            Angle result = new Angle();
            result.Degrees = degrees;
            return result;
        }

        static public Angle FromDegrees(int degree, int minutes, double seconds)
        {
            Angle result = new Angle();
            result.Degrees = degree + minutes / 60.0 + seconds / 3600;
            return result;
        }

        static public Angle Multiply(double value, Angle angle)
        {
            Angle result = new Angle(angle);
            result._degrees *= value;
            result._radians *= value;
            return result;
        }

        static public Angle Multiply(Angle angle, double value)
        {
            return Multiply(value, angle);
        }

        static public Angle operator *(double value, Angle angle)
        {
            return Multiply(value, angle);
        }

        static public Angle operator *(Angle angle, double value)
        {
            return Multiply(value, angle);
        }

        static public Angle Addition(Angle a1, Angle a2)
        {
            Angle result = new Angle();
            result.Degrees = a1.Degrees + a2.Degrees;
            return result;
        }

        static public Angle operator+(Angle a1, Angle a2)
        {
            return Addition(a1, a2);
        }

        static public double Sin(Angle a)
        {
            return Math.Sin(a.Radians);
        }

        static public double Cos(Angle a)
        {
            return Math.Cos(a.Radians);
        }

        public void AddSeconds(double seconds)
        {
            Degrees += seconds / 3600;
        }

        public double RadToDegrees(double rad)
        {
            return rad * 180.0 / Math.PI;
        }

        public double DegreesToRad(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
    }
}
