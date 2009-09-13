using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAnet
{
    /**
     * Helper class to manipulate and convert angles
     */
    public struct Angle
    {
        double _degrees;

        /**
         * @brief 
         * Copy constructor
         */
        public Angle(Angle angle)
        {
            _degrees = angle._degrees;
        }

        /**
      * @brief
      * The angle value in degrees
      */
        public double Degrees
        {
            get
            {
                return _degrees;
            }
            set
            {
                _degrees = value;
            }
        }

        

        /**
         * @brief
         * The angle value in radians
         */
        public double Radians
        {
            get
            {
                return DegreesToRad(_degrees);
            }
            set
            {
                _degrees = RadToDegrees(value);
            }
        }

        /**
         * @brief
         * The degrees part of the angle
         */
        public double Deg
        {
            get
            {
                return (int)_degrees;
            }
        }
        /**
         * @brief
         * The minutes part of the angle
         */
        public int Minutes
        {
            get
            {
                double degrees = _degrees;

                if (degrees < 0)
                {
                    degrees = -degrees;

                }
                double result = degrees - (int)(degrees);
                result *= 60;
                return (int)(result);
            }
        }

        /**
         * @brief
         * The seconds part of the angle
         */
        public double Seconds {
            get
            {
                double degrees = _degrees;

                if (degrees < 0)
                {
                    degrees = -degrees;
                }
                double result = degrees - (int)(degrees);
                result *= 60;
                result -= (int)(result);
                result *= 60;
                return result;
            }
        }

        /**
         * @brief
         * Create an Angle from the value given in degrees
         * 
         * @param degrees
         * The value with which to initialize the angle
         * 
         * @return
         * The constructed Angle
         */
        static public Angle FromDegrees(double degrees)
        {
            Angle result = new Angle();
            result.Degrees = degrees;
            return result;
        }

        /**
         * @brief
         * Create an Angle from the value given in degrees, minutes and seconds
         * 
         * @param degree
         * The degree part of the angle
         * 
         * @param minutes
         * The minute part of the angle
         * 
         * @param seconds
         * The seconds part of the angle
         * 
         * @return
         * The constructed Angle
         */
        static public Angle FromDegrees(int degree, int minutes, double seconds)
        {
            int sign = 1;
            if (degree < 0)
            {
                degree = -degree;
            }
            Angle result = new Angle();
            result.Degrees = sign * (degree + minutes / 60.0 + seconds / 3600);
            return result;
        }

        /**
         * @brief
         * Create an Angle from the value given in radians
         * 
         * @param radians
         * The value with which to initialize the angle
         * 
         * @return
         * The constructed Angle
         */
        static public Angle FromRadians(double radians)
        {
            Angle result = new Angle();
            result.Radians = radians;
            return result;
        }

        /**
         * @brief
         * Multiply an angle by a double value
         * 
         * @param value
         * The value to multiply angle with
         * 
         * @param angle
         * The angle to multiply with value
         * 
         * @return
         * The product of angle and value
         */
        static public Angle Multiply(double value, Angle angle)
        {
            Angle result = new Angle(angle);
            result._degrees *= value;
            return result;
        }

        /**
         * @brief
         * Multiply an angle by a double value
         * 
         * @param angle
         * The angle to multiply with value
         * 
         * @param value
         * The value to multiply angle with
         * 
         * @return
         * The product of angle and value
         */
        static public Angle Multiply(Angle angle, double value)
        {
            return Multiply(value, angle);
        }

        /**
         * @brief
         * Multiply an angle by a double value
         * 
         * @param value
         * The value to multiply angle with
         * 
         * @param angle
         * The angle to multiply with value 
         * 
         * @return
         * The product of angle and value
         */
        static public Angle operator *(double value, Angle angle)
        {
            return Multiply(value, angle);
        }

        /**
         * @brief
         * Multiply an angle by a double value
         * 
         * @param angle
         * The angle to multiply with value
         * 
         * @param value
         * The value to multiply angle with
         * 
         * @return
         * The product of angle and value
         */
        static public Angle operator *(Angle angle, double value)
        {
            return Multiply(value, angle);
        }

        /**
         * @brief
         * Add two angles
         * 
         * @param a1
         * The first of the two angles
         * 
         * @param
         * The second of the two angles
         * 
         * @return
         * The sum of the two angles
         */
        static public Angle Addition(Angle a1, Angle a2)
        {
            Angle result = new Angle();
            result.Degrees = a1.Degrees + a2.Degrees;
            return result;
        }

        /**
         * @brief
         * Add two angles
         * 
         * @param a1
         * The first of the two angles
         * 
         * @param
         * The second of the two angles
         * 
         * @return
         * The sum of the two angles
         */
        static public Angle operator+(Angle a1, Angle a2)
        {
            return Addition(a1, a2);
        }

        /// <summary>
        /// Subtract two angles
        /// </summary>
        /// <param name="a1">The first of two angles</param>
        /// <param name="a2">The second of the two angles</param>
        /// <returns>The difference of the two angles</returns>
        static public Angle Subtraction(Angle a1, Angle a2)
        {
            Angle result = new Angle();
            result.Degrees = a1.Degrees - a2.Degrees;
            return result;
        }

        /// <summary>
        /// Subtract two angles
        /// </summary>
        /// <param name="a1">The first of two angles</param>
        /// <param name="a2">The second of the two angles</param>
        /// <returns>The difference of the two angles</returns>
        static public Angle operator -(Angle a1, Angle a2)
        {
            return Subtraction(a1, a2);
        }

        /**
         * @brief
         * Calculate the sine of an angle
         * 
         * @param a
         * The angle from which to take the sine
         * 
         * @return
         * The sine of a
         */
        static public double Sin(Angle a)
        {
            return Math.Sin(a.Radians);
        }

        /**
         * @brief
         * Calculate the cosine of an angle
         * 
         * @param a
         * The angle from which to take the cosine
         * 
         * @return
         * The cosine of a
         */
        static public double Cos(Angle a)
        {
            return Math.Cos(a.Radians);
        }

        /// <summary>
        /// Inverse sine
        /// </summary>
        /// <param name="argument">The argument to take the inverse sine from</param>
        /// <returns>The reverse sine of the argument</returns>
        static public Angle Asin(double argument)
        {
            return FromRadians(Math.Asin(argument));
        }


        /// <summary>
        /// Inverse cosine
        /// </summary>
        /// <param name="argument">The argument to take the inverse cosine from</param>
        /// <returns>The reverse cosine of the argument</returns>
        static public Angle Acos(double argument)
        {
            return FromRadians(Math.Asin(argument));
        }

        /// <summary>
        /// Returns the angle whose tangent is the quotient of two specified numbers 
        /// </summary>
        /// <param name="y">The y-coordinate of a point</param>
        /// <param name="x">The x-coordinate of a point</param>
        /// <returns>The angle for which the tangent is y / x</returns>
        /// <remarks>See Math.Atan2 for more details</remarks>
        static public Angle Atan2(double y, double x)
        {
            return FromRadians(Math.Atan2(y, x));
        }
        /**
         * @brief
         * Helper function to convert from radians to degrees
         * 
         * @param rad
         * The radians to convert
         * 
         * @return
         * The number of degrees corresponding to rad
         */
        public double RadToDegrees(double rad)
        {
            return rad * 180.0 / Math.PI;
        }

        /**
         * @brief
         * Helper function to convert from degrees to radians
         * 
         * @param degrees
         * The degrees to convert
         * 
         * @return
         * The number of radians corresponding to degrees
         */
        public double DegreesToRad(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
    }
}
