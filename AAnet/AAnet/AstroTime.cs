using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAnet
{
    /**
     * @brief
     * Time as used in Astronomical Calculations.
     */
    public class AstroTime
    {
        private JulianDate _jd;
        private Nutation _nutation;

        public AstroTime(DateTime aDate)
        {
            Date = aDate;
        }

        public DateTime Date
        {
            get
            {
                return _jd.ToDateTime();
            }
            set
            {
                _jd = new JulianDate(value);
            }
        }

        public JulianDate JD
        {
            get
            {
                return _jd;
            }
            set
            {
                _jd = value;
            }
        }

        private static double JdToGMST(JulianDate aJD)
        {
            double Tu = aJD.BesselianCentury(JulianDate.J2000);
            double gmst = 24110.54841 + (8640184.812866  + (0.093104 - 6.2e-6 * Tu) * Tu) * Tu;
            return gmst;
        }

        public DateTime GMST {
            get {
                double days = JdToGMST(_jd) / (3600 * 24);
                days -= (int)days;
                days *= 24;
                int hours = (int)(days);
                days -= hours;
                days *= 60;
                int minutes = (int)days;
                days -= minutes;
                days *= 60;
                
                DateTime result = new DateTime(1, 1, 1, hours, minutes, 0);
                result.AddSeconds(days);
                return result;
            }
        }

        public DateTime GAST
        {
            get
            {
                DateTime result = new DateTime(GMST.Ticks);

                if (_nutation == null)
                {
                    _nutation = new Nutation(JD);
                }
                result.AddSeconds(_nutation.EquationOfEquinox);
                return result;
            }
        }
    }
}
