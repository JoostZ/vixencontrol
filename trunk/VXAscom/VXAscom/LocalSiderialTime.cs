using System;
using System.ComponentModel;

using ASCOM.Helper;


namespace ASCOM.VXAscom
{

    using NUnit.Framework;

    /**
     * @brief
     * Singleton object holding the current local Siderial Time.
     * 
     * During construction of the object the current Greenwhich Apparent Siderial Time (GAST) is calculated
     * accurately from the Date/Time in the ObservationLocation. It includes the nutation of longitude.
     * 
     * When later the current LST is needed, call Update() which will use the difference
     * in time with respect to the object creation time to update the LST.
     */
    public class LocalSiderialTime : INotifyPropertyChanged, IUpdatable
    {
        private ObservationLocation iLocation;
        internal DateTime iBaseUTC;
        internal double iBaseGAST;
        internal double iBaseLAST;
        internal double iTimeOffset;

        const double kSiderialSeconds = 1.002737908;

        /**
         * @brief 
         * Constructor
         * 
         * It is private since it should ONLY be constructed from the singleton
         * access function
         */
        internal LocalSiderialTime()
        {
            iLocation = ObservationLocation.Location;
            iBaseUTC = iLocation.UTC;
            iBaseGAST = GST(iBaseUTC);
            iBaseLAST = iBaseGAST + iLocation.Longitude * 24.0 / 360.0;
            iTimeOffset = 0;

            iLocation.PropertyChanged += new PropertyChangedEventHandler(NotifiedHandler);
       }

        private static LocalSiderialTime sLST = null;

        public static LocalSiderialTime LST
        {
            get
            {
                if (sLST == null)
                {
                    sLST = new LocalSiderialTime();
                }
                return sLST;
            }
        }

        public void Update()
        {
            // Calculate the difference between the actual time and our base time
            TimeSpan dt = iLocation.UTC.Subtract(iBaseUTC);
            iTimeOffset = dt.TotalHours;
            NotifyPropertyChanged("LAST");
            NotifyPropertyChanged("LAST_String");
        }

        /**
         * @brief
         * The Local Apparent Siderial Time
         * 
         * It is calculated from
         * * The BASE GAST stored in this object
         * * The time offset (in siderial time) since the creation of this object
         * * The longitude of the observation size
         * Note that the first two terms give the acual GAST and the last converts to LAST
         */
        public double LAST
        {
            get
            {
                double time = iBaseLAST + iTimeOffset;
                while (time < 0)
                {
                    time += 24;
                }
                while (time >= 24)
                {
                    time -= 24;
                }
                return time;
            }
        }

        public String LAST_String
        {
            get
            {
                Util helper = new UtilClass();
                return helper.HoursToHMS(LAST, ":", ":", "", 0);
            }
        }

        public double GAST
        {
            get
            {
                return iBaseGAST + iTimeOffset;
            }
        }

        /**
         * @brief
         * Calculate the Julian date expressed in centuries
         * 
         * @param
         * The Julian Date at 0h UTC
         */
        internal double JulianCentury(double JD)
        {
            return (JD - 2415020.0) / 36525;
        }

        /**
         * @brief
         * Calculate the mean Greenwhich Siderial Time for the given Julian Date
         * 
         * @param JD
         * Julian date at 0h UT
         * 
         * @note
         * The Julian Date MUST be at Midnight GMT
         */
        internal double GST0(double JD)
        {
            double T = JulianCentury(JD);
            double theta = 0.276919398 + T * (100.0021359 + T * 0.000001075);
            theta -= (int)theta;
            theta *= 24;

            return theta;
        }

        
        /**
         * @brief
         * Calculate the mean Greenwhich Siderial Time for the given GMT
         * 
         * @param aDate
         * Date and Time in UTC
         */
        internal double GST(DateTime aDate)
        {
            Helper2.UtilClass helper2 = new Helper2.UtilClass();
            double JD = helper2.DateUTCToJulian(aDate.Date);
            double gst0 = GST0(JD);

            double gst = gst0 + kSiderialSeconds * aDate.TimeOfDay.TotalHours;
            if (gst >= 24.0)
            {
                gst -= 24.0;
            }

            return gst;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }



        public void NotifiedHandler(object src, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "UTC")
            {
                // Base UTC has changed. Updat our base data
                iBaseUTC = iLocation.UTC;
                iBaseGAST = GST(iBaseUTC);
                iBaseLAST = iBaseGAST + iLocation.Longitude * 24.0 / 360.0;
            }
            else if (args.PropertyName == "Longitude")
            {
                iBaseLAST = iBaseGAST + iLocation.Longitude * 24.0 / 360.0;
            }
        }
    }

#if DEBUG

    [TestFixture]
    public class TestLocalSiderialTime
    {
        [Test]
        public void IsSingleton()
        {
            LocalSiderialTime theLST = LocalSiderialTime.LST;
            Assert.That(theLST != null);
            Assert.That(theLST, Is.SameAs(LocalSiderialTime.LST));
        }

        [Test]
        public void TestGST()
        {
            LocalSiderialTime theLST = LocalSiderialTime.LST;

            Assert.That(theLST.JulianCentury(2443825.5), Is.EqualTo(0.7886516085).Within(0.00000000005));
            Assert.That(theLST.GST0(2443825.5), Is.EqualTo(3.4503696).Within(0.0000005));

            DateTime theDate = new DateTime(1978, 11, 13, 4, 34, 0);
            Assert.That(theLST.GST(theDate), Is.EqualTo(8.0295394).Within(0.0000005));
        }

        [Test]
        public void TestLAST()
        {
            LocalSiderialTime theLST = LocalSiderialTime.LST;
            ObservationLocation theLocation = ObservationLocation.Location;

            theLocation.Longitude = 0.0;
            Assert.That(theLST.LAST, Is.EqualTo(theLST.GAST));

            double oldGAST = theLST.iBaseGAST;
            DateTime theDate = new DateTime(1978, 11, 13, 4, 34, 0);
            theLocation.UTC = theDate;

            Assert.That(theLST.LAST, Is.EqualTo(8.0295394).Within(0.0000005));

            theLocation.Longitude = 4.0; // 4 degrees east => +(4 / 15) hours;
            Assert.That(theLST.LAST, Is.EqualTo(theLST.GAST + (4.0 / 15)).Within(0.0000001));

        }
    
    }
#endif
}
