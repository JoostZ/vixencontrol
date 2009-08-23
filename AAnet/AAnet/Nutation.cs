using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAnet
{
    public class Nutation
    {
        struct coeff
        {
            public int[] coefficients;
            public double[] S;
            public double[] C;

            public coeff(int l1, int l2, int l3, int l4, int l5, double S0, double S1, double C0, double C1)
            {
                coefficients = new int[5];
                coefficients[0] = l1;
                coefficients[1] = l2;
                coefficients[2] = l3;
                coefficients[3] = l4;
                coefficients[4] = l5;
                S = new double[2];
                S[0] = S0;
                S[1] = S1;
                C = new double[2];
                C[0] = C0;
                C[1] = C1;
            }

        }

        static readonly coeff[] coeffList = new coeff[] {
            new coeff(0, 0, 0, 0, 1, -171996, -174.2, 92025, 8.9),
 			new coeff(0, 0, 0, 0, 2, 2062, 0.2, -895, 0.5), 
			new coeff(-2, 0, 2, 0, 1, 46, 0, -24, 0), 
			new coeff(2, 0, -2, 0, 0, 11, 0, 0, 0), 
			new coeff(-2, 0, 2, 0, 2, -3, 0, 1, 0), 
			new coeff(1, -1, 0, -1, 0, -3, 0, 0, 0), 
			new coeff(0, -2, 2, -2, 1, -2, 0, 1, 0), 
			new coeff(2, 0, -2, 0, 1, 1, 0, 0, 0), 
			new coeff(0, 0, 2, -2, 2, -13187, -1.6, 5736, -3.1), 
			new coeff(0, 1, 0, 0, 0, 1426, -3.4, 54, -0.1), 
			new coeff(0, 1, 2, -2, 2, -517, 1.2, 224, -0.6), 
			new coeff(0, -1, 2, -2, 2, 217, -0.5, -95, 0.3), 
			new coeff(0, 0, 2, -2, 1, 129, 0.1, -70, 0), 
			new coeff(2, 0, 0, -2, 0, 48, 0, 1, 0), 
			new coeff(0, 0, 2, -2, 0, -22, 0, 0, 0), 
			new coeff(0, 2, 0, 0, 0, 17, -0.1, 0, 0), 
			new coeff(0, 1, 0, 0, 1, -15, 0, 9, 0), 
			new coeff(0, 2, 2, -2, 2, -16, 0.1, 7, 0), 
			new coeff(0, -1, 0, 0, 1, -12, 0, 6, 0), 
			new coeff(-2, 0, 0, 2, 1, -6, 0, 3, 0), 
			new coeff(0, -1, 2, -2, 1, -5, 0, 3, 0), 
			new coeff(2, 0, 0, -2, 1, 4, 0, -2, 0), 
			new coeff(0, 1, 2, -2, 1, 4, 0, -2, 0), 
			new coeff(1, 0, 0, -1, 0, -4, 0, 0, 0), 
			new coeff(2, 1, 0, -2, 0, 1, 0, 0, 0), 
			new coeff(0, 0, -2, 2, 1, 1, 0, 0, 0), 
			new coeff(0, 1, -2, 2, 0, -1, 0, 0, 0), 
			new coeff(0, 1, 0, 0, 2, 1, 0, 0, 0), 
			new coeff(-1, 0, 0, 1, 1, 1, 0, 0, 0), 
			new coeff(0, 1, 2, -2, 0, -1, 0, 0, 0), 
			new coeff(0, 0, 2, 0, 2, -2274, -0.2, 977, -0.5), 
			new coeff(1, 0, 0, 0, 0, 712, 0.1, -7, 0), 
			new coeff(0, 0, 2, 0, 1, -386, -0.4, 200, 0), 
			new coeff(1, 0, 2, 0, 2, -301, 0, 129, -0.1), 
			new coeff(1, 0, 0, -2, 0, -158, 0, -1, 0), 
			new coeff(-1, 0, 2, 0, 2, 123, 0, -53, 0), 
			new coeff(0, 0, 0, 2, 0, 63, 0, -2, 0), 
			new coeff(1, 0, 0, 0, 1, 63, 0.1, -33, 0), 
			new coeff(-1, 0, 0, 0, 1, -58, -0.1, 32, 0), 
			new coeff(-1, 0, 2, 2, 2, -59, 0, 26, 0), 
			new coeff(1, 0, 2, 0, 1, -51, 0, 27, 0), 
			new coeff(0, 0, 2, 2, 2, -38, 0, 16, 0), 
			new coeff(2, 0, 0, 0, 0, 29, 0, -1, 0), 
			new coeff(1, 0, 2, -2, 2, 29, 0, -12, 0), 
			new coeff(2, 0, 2, 0, 2, -31, 0, 13, 0), 
			new coeff(0, 0, 2, 0, 0, 26, 0, -1, 0), 
			new coeff(-1, 0, 2, 0, 1, 21, 0, -10, 0), 
			new coeff(-1, 0, 0, 2, 1, 16, 0, -8, 0), 
			new coeff(1, 0, 0, -2, 1, -13, 0, 7, 0), 
			new coeff(-1, 0, 2, 2, 1, -10, 0, 5, 0), 
			new coeff(1, 1, 0, -2, 0, -7, 0, 0, 0), 
			new coeff(0, 1, 2, 0, 2, 7, 0, -3, 0), 
			new coeff(0, -1, 2, 0, 2, -7, 0, 3, 0), 
			new coeff(1, 0, 2, 2, 2, -8, 0, 3, 0), 
			new coeff(1, 0, 0, 2, 0, 6, 0, 0, 0), 
			new coeff(2, 0, 2, -2, 2, 6, 0, -3, 0), 
			new coeff(0, 0, 0, 2, 1, -6, 0, 3, 0), 
			new coeff(0, 0, 2, 2, 1, -7, 0, 3, 0), 
			new coeff(1, 0, 2, -2, 1, 6, 0, -3, 0), 
			new coeff(0, 0, 0, -2, 1, -5, 0, 3, 0), 
			new coeff(1, -1, 0, 0, 0, 5, 0, 0, 0), 
			new coeff(2, 0, 2, 0, 1, -5, 0, 3, 0), 
			new coeff(0, 1, 0, -2, 0, -4, 0, 0, 0), 
			new coeff(1, 0, -2, 0, 0, 4, 0, 0, 0), 
			new coeff(0, 0, 0, 1, 0, -4, 0, 0, 0), 
			new coeff(1, 1, 0, 0, 0, -3, 0, 0, 0), 
			new coeff(1, 0, 2, 0, 0, 3, 0, 0, 0), 
			new coeff(1, -1, 2, 0, 2, -3, 0, 1, 0), 
			new coeff(-1, -1, 2, 2, 2, -3, 0, 1, 0), 
			new coeff(-2, 0, 0, 0, 1, -2, 0, 1, 0), 
			new coeff(3, 0, 2, 0, 2, -3, 0, 1, 0), 
			new coeff(0, -1, 2, 2, 2, -3, 0, 1, 0), 
			new coeff(1, 1, 2, 0, 2, 2, 0, -1, 0), 
			new coeff(-1, 0, 2, -2, 1, -2, 0, 1, 0), 
			new coeff(2, 0, 0, 0, 1, 2, 0, -1, 0), 
			new coeff(1, 0, 0, 0, 2, -2, 0, 1, 0), 
			new coeff(3, 0, 0, 0, 0, 2, 0, 0, 0), 
			new coeff(0, 0, 2, 1, 2, 2, 0, -1, 0), 
			new coeff(-1, 0, 0, 0, 2, 1, 0, -1, 0), 
			new coeff(1, 0, 0, -4, 0, -1, 0, 0, 0), 
			new coeff(-2, 0, 2, 2, 2, 1, 0, -1, 0), 
			new coeff(-1, 0, 2, 4, 2, -2, 0, 1, 0), 
			new coeff(2, 0, 0, -4, 0, -1, 0, 0, 0), 
			new coeff(1, 1, 2, -2, 2, 1, 0, -1, 0), 
			new coeff(1, 0, 2, 2, 1, -1, 0, 1, 0), 
			new coeff(-2, 0, 2, 4, 2, -1, 0, 1, 0), 
			new coeff(-1, 0, 4, 0, 2, 1, 0, 0, 0), 
			new coeff(1, -1, 0, -2, 0, 1, 0, 0, 0), 
			new coeff(2, 0, 2, -2, 1, 1, 0, -1, 0), 
			new coeff(2, 0, 2, 2, 2, -1, 0, 0, 0), 
			new coeff(1, 0, 0, 2, 1, -1, 0, 0, 0), 
			new coeff(0, 0, 4, -2, 2, 1, 0, 0, 0), 
			new coeff(3, 0, 2, -2, 2, 1, 0, 0, 0), 
			new coeff(1, 0, 2, -2, 0, -1, 0, 0, 0), 
			new coeff(0, 1, 2, 0, 1, 1, 0, 0, 0), 
			new coeff(-1, -1, 0, 2, 1, 1, 0, 0, 0), 
			new coeff(0, 0, -2, 0, 1, -1, 0, 0, 0), 
			new coeff(0, 0, 2, -1, 2, -1, 0, 0, 0), 
			new coeff(0, 1, 0, 2, 0, -1, 0, 0, 0), 
			new coeff(1, 0, -2, -2, 0, -1, 0, 0, 0), 
			new coeff(0, -1, 2, 0, 1, -1, 0, 0, 0), 
			new coeff(1, 1, 0, -2, 1, -1, 0, 0, 0), 
			new coeff(1, 0, -2, 2, 0, -1, 0, 0, 0), 
			new coeff(2, 0, 0, 2, 0, 1, 0, 0, 0), 
			new coeff(0, 0, 2, 4, 2, -1, 0, 0, 0), 
			new coeff(0, 1, 0, 1, 0, 1, 0, 0, 0)
        };

        struct correction
        {
            public int[] coefficients;
            public double LS;
            public double LC;
            public double OC;
            public double OS;

            public correction(int l1, int l2, int l3, int l4, int l5, double S0, double S1, double C0, double C1)
            {
                coefficients = new int[5];
                coefficients[0] = l1;
                coefficients[1] = l2;
                coefficients[2] = l3;
                coefficients[3] = l4;
                coefficients[4] = l5;
                LS = 0.00001 * S0;
                LC = 0.00001 * S1;
                OC = 0.00001 * C0;
                OS = 0.00001 * C1;
            }


        }
        static readonly correction[] correctionList = new correction[] {
            new correction(0, 0, 0, 0, 1, -725, 417, 213, 224),
            new correction(0, 1, 0, 0, 0, 523, 61, 208, -24),
            new correction(0, 0, 2, -2, 2, 102, -118, -41, -47),
            new correction(0, 0, 2, 0, 2, -81, 0, 32, 0)
        };

        double _T;
        double _d;
        //double _Omega;
        double _DeltaPsi;
        double _DeltaEpsilon;
        Angle _Epsilon;
        double _EE;

        public Nutation(JulianDate aJD)
        {
            _d = aJD - JulianDate.J2000;
            _T = _d / 36525;

            Angle c0 = Angle.FromDegrees(134, 57, 46.733);
            Angle c1 = Angle.FromDegrees(1325 * 360) + Angle.FromDegrees(198, 52, 2.633);
            Angle c2 = Angle.FromDegrees(0, 0, 31.310);
            Angle c3 = Angle.FromDegrees(0, 0, 0.064);
            Angle l = TimeSeries(_T, c0, c1, c2, c3);

            c0 = Angle.FromDegrees(357, 31, 39.804);
            c1 = Angle.FromDegrees(99 * 360) + Angle.FromDegrees(359, 3, 1.224);
            c2 = -1 * Angle.FromDegrees(0, 0, 0.577);
            c3 = -1 * Angle.FromDegrees(0, 0, 0.012);
            Angle lp = TimeSeries(_T, c0, c1, c2, c3);

            c0 = Angle.FromDegrees(93, 16, 18.877);
            c1 = Angle.FromDegrees(1342 * 360) + Angle.FromDegrees(82, 1, 3.137);
            c2 = -1 * Angle.FromDegrees(0, 0, 13.257);
            c3 = Angle.FromDegrees(0, 0, 0.011);
            Angle F = TimeSeries(_T, c0, c1, c2, c3);

            c0 = Angle.FromDegrees(297, 51, 1.307);
            c1 = Angle.FromDegrees(1236 * 360) + Angle.FromDegrees(307, 6, 41.328);
            c2 = -1 * Angle.FromDegrees(0, 0, 6.891);
            c3 = Angle.FromDegrees(0, 0, 0.019);
            Angle D = TimeSeries(_T, c0, c1, c2, c3);


            c0 = Angle.FromDegrees(125, 2, 40.280);
            c1 = -1 * (Angle.FromDegrees(5 * 360) + Angle.FromDegrees(134, 8, 10.539));
            c2 = Angle.FromDegrees(0, 0, 7.455);
            c3 = Angle.FromDegrees(0, 0, 0.008);
            Angle Omega = TimeSeries(_T, c0, c1, c2, c3);

            Angle[] FA = new Angle[] {
                l, lp, F, D, Omega
            };
            Angle _Epsilon0 = TimeSeries(_T, 
                             Angle.FromDegrees(23, 26, 21.488),
                             -1 * Angle.FromDegrees(0, 0, 46.8150),
                             -1 * Angle.FromDegrees(0, 0, 0.00059),
                             Angle.FromDegrees(0, 0, 0.001813));

            double deltaPsi = 0.0;
            double deltaEpsilon = 0.0;
            
            for (int i = 0; i < coeffList.Length; i++)
            {
                Angle Ai = new Angle();
                coeff coefficient = coeffList[i];

                double Si = (coefficient.S[0] + coefficient.S[1] * _T) / 10000.0;
                double Ci = (coefficient.C[0] + coefficient.C[1] * _T) / 10000.0;

                for (int j = 0; j < FA.Length; j++)
                {
                    Ai += FA[j] * coeffList[i].coefficients[j];
                }
                deltaPsi += Si * Angle.Sin(Ai);
                deltaEpsilon += Ci * Angle.Cos(Ai);
            }

            //for (int i = 0; i < correctionList.Length; i++)
            //{
            //    Angle Ai = new Angle();
            //    correction corr = correctionList[i];
            //    for (int j = 0; j < FA.Length; j++)
            //    {
            //        Ai += FA[j] * corr.coefficients[j];
            //    }
            //    deltaPsi += corr.LS * Angle.Sin(Ai) + corr.LC * Angle.Cos(Ai);
            //    deltaEpsilon += corr.OC * Angle.Cos(Ai) + corr.OS * Angle.Sin(Ai);
            //}

            _Epsilon = _Epsilon0 + Angle.FromDegrees(0, 0, deltaEpsilon);
            _EE = (deltaPsi * Angle.Cos(Epsilon) + 0.00264 * Angle.Sin(Omega) + 0.000063 * Angle.Sin(2.0 * Omega)) / 15.0;

            _DeltaPsi = deltaPsi;
            _DeltaEpsilon = deltaEpsilon;

            

        }

        private Angle TimeSeries(double T, Angle c0, Angle c1, Angle c2, Angle c3)
        {
            Angle result = new Angle(c0);
            result += c1 * T;
            result += c2 * (T * T);
            result += c3 * (T * T * T);
            return result;
        }

        private double ToRad(double aVal)
        {
            return Math.PI * aVal / 360;
        }

        private double FractionDegree( int deg, int min, double sec)
        {
            return deg + min / 60.0 + sec / 3600;
        }

        public double DeltaPsi
        {
            get
            {
                return _DeltaPsi;
            }
        }

        public double DeltaEpsilon
        {
            get
            {
                return _DeltaEpsilon;
            }
        }

        public Angle Epsilon {
            get
            {
                return _Epsilon;
            }
        }

        public double EquationOfEquinox {
            get {
                return _EE;
            }
        }

    }
}
