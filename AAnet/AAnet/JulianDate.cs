using System;
using System.Collections.Generic;
using System.Text;

namespace AAnet
{
    public class JulianDate
    {
        public static readonly JulianDate J2000 = new JulianDate(2451545.0);

        public JulianDate(double aJD)
        {
            _Day = (long)aJD;
            _Fraction = aJD - _Day;
        }

        public JulianDate(JulianDate aJD)
        {
            _Day = aJD._Day;
            _Fraction = aJD._Fraction;
        }

        public JulianDate(DateTime aDate)
        {
            long Y = aDate.Year;
            long M = aDate.Month;
            long D = aDate.Day;

            long JD = (1461 * (Y + 4800 + (M - 14) / 12)) / 4;
            JD += (367 * (M - 2 - 12 * ((M - 14) / 12))) / 12;
            JD -= (3 * ((Y + 4900 + (M - 14) / 12) / 100)) / 4;
            JD += D - 32075;

            double  fraction = aDate.TimeOfDay.TotalDays - 0.5;
            if (fraction < 0.0)
            {
                fraction += 1;
                JD -= 1;
            }
            _Day = JD;
            _Fraction = fraction;            
        }

        public static implicit operator double(JulianDate aDate)
        {
            return aDate.ToDouble();
        }

        public double BesselianCentury(JulianDate aJD)
        {
            double days = this - aJD;
            return days / 36525;
        }

        public double ToDouble()
        {
            double result = _Day;
            result += _Fraction;
            return result;
        }

        public DateTime ToDateTime()
        {
            long L = _Day ;
            double F = _Fraction + 0.5;
            if (F >= 1.0) {
                F -= 1.0;
                L += 1;
            }

            L += 68569;
            long N = (4 * L) / 146097;
            L -= (146097 * N + 3) / 4;
            long I = (4000 * (L + 1)) / 1461001;
            L -= (1461 * I) / 4 - 31;
            long J = (80 * L) / 2447;
            int D = (int)(L - (2447 * J) / 80);
            L = J / 11;
            int M = (int)(J + 2 - 12 * L);
            int Y = (int)(100 * (N - 49) + I + L);

           DateTime result = new DateTime(Y, M, D);
           return result.AddDays(F);
        }

        public void AddSeconds(double aSeconds)
        {
            _Fraction += aSeconds / (3600 * 24);
            while (_Fraction >= 1)
            {
                _Fraction -= 1.0;
                _Day += 1;
            }
            while (_Fraction < 0)
            {
                _Fraction += 1.0;
                _Day -= 1;
            }
        }

        public double Subtract(JulianDate aJD)
        {
            _Day -= aJD._Day;
            _Fraction -= aJD._Fraction;
            if (_Fraction < 0.0)
            {
                _Fraction += 1.0;
                _Day -= 1;
            }
            return ToDouble();
        }

        public double Subtract(double aJD)
        {
            return ToDouble() - aJD;
        }

        public static double operator -(JulianDate aLhs, double aRhs)
        {
            return new JulianDate(aLhs).Subtract(aRhs);
        }

        public static double operator-(JulianDate aLhs, JulianDate aJD)
        {
            return new JulianDate(aLhs).Subtract(aJD);
        }

        private long _Day;
        private double _Fraction;
    }
}
