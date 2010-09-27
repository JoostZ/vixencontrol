using System;
using System.ComponentModel;

using ASCOM.Utilities;

namespace ASCOM.VXAscom
{
    using NUnit.Framework;

    /**
     * @brief
     * Stores and gives access to the location of the telescope
     * 
     * @note
     * This is a singleton
     */
    class ObservationLocation : INotifyPropertyChanged
    {
        private Utilities.Profile iProfile;
        private Utilities.Util iHelper;
        private String iProgID;

        public ObservationLocation()
        {
            iProfile = new Utilities.Profile();
            iProfile.DeviceType = "Telescope";
            iHelper = new Utilities.Util();
            iProgID = Telescope.ProgId;

            if (iProfile.IsRegistered(Telescope.ProgId))
            {
                String storedLongitude;

                storedLongitude = iProfile.GetValue(iProgID, "Longitude", "");

                if (storedLongitude.Length != 0)
                {
                    iLongitude = Convert.ToDouble(storedLongitude);
                }
                else
                {
                    iLongitude = 0;
                }
            }
            else
            {
                iLongitude = 0;
            }
        }

        private static ObservationLocation sLocation = null;

        public static ObservationLocation Location
        {
            get
            {
                if (sLocation == null)
                {
                    sLocation = new ObservationLocation();
                }
                return sLocation;
            }
        }

        internal static void Reset()
        {
            sLocation = null;
        }

        double iLongitude;

        public double Longitude
        {
            get
            {
                return iLongitude;
            }
            set
            {
                if (iLongitude != value)
                {
                    iLongitude = value;
                    Utilities.Profile theProfile = new Utilities.Profile();
                    theProfile.DeviceType = "Telescope";
                    theProfile.WriteValue(iProgID, "Longitude", Convert.ToString(iLongitude), "");
                    NotifyPropertyChanged("Longitude");
                }

            }
        }

        public String Longitude_String
        {
            get
            {
                String result;
                double theLongitude = Longitude;
                if (theLongitude > 0)
                {
                    result = "E";
                }
                else
                {
                    result = "W";
                    theLongitude = -theLongitude;
                }
                return iHelper.DegreesToDMS(theLongitude, "°", "'", "''", 3) + result;
            }
        }

        TimeSpan iOffset = new TimeSpan();

        public DateTime UTC
        {
            get
            {
                return DateTime.UtcNow.Add(iOffset);
            }
            set
            {
                iOffset = value.Subtract(DateTime.UtcNow);
                //NotifyPropertyChanged("UTC");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }

#if DEBUG

    [TestFixture]
    public class TestObservationLocation
    {
        class NotifyHandler
        {
            public int nLongitudeChanges = 0;
            public int nUtcChanges = 0;

            public NotifyHandler(INotifyPropertyChanged aHandler)
            {
                nLongitudeChanges = 0;
                aHandler.PropertyChanged += new PropertyChangedEventHandler(NotifiedHandler);
            }

            public void NotifiedHandler(object src, PropertyChangedEventArgs args)
            {
                if (args.PropertyName == "Longitude")
                {
                    nLongitudeChanges++;
                }
                else if (args.PropertyName == "UTC")
                {
                    nUtcChanges++;
                }
            }
        }

        [Test]
        public void IsSingleton()
        {
            //Telescope.RegisterASCOM(typeof(Telescope)); 

            Utilities.Profile theProfile = new Utilities.Profile();
            theProfile.DeviceType = "Telescope";
            Assert.That(theProfile.IsRegistered(Telescope.ProgId));

            ObservationLocation theLocation = ObservationLocation.Location;
            Assert.That(theLocation != null);
            Assert.That(theLocation, Is.SameAs(ObservationLocation.Location));
        }

        [Test]
        public void TestProfile()
        {
            Telescope.RegisterASCOM(typeof(Telescope));

            Utilities.Profile theProfile = new Utilities.Profile();
            theProfile.DeviceType = "Telescope";
            Assert.That(theProfile.IsRegistered(Telescope.ProgId));
            ObservationLocation.Reset();
            try
            {
                theProfile.DeleteValue(Telescope.ProgId, "Longitude", "");
            }
            catch(Exception) {}

            ObservationLocation theLocation = ObservationLocation.Location;

            Assert.That(theLocation.Longitude, Is.EqualTo(0.0));

            theProfile.WriteValue(Telescope.ProgId, "Longitude", Convert.ToString(4.12345), "");
            double longitude = Convert.ToDouble(theProfile.GetValue(Telescope.ProgId, "Longitude", ""));
            Assert.That(longitude, Is.EqualTo(4.12345));
            ObservationLocation.Reset();
            theLocation = ObservationLocation.Location;
            Assert.That(theLocation.Longitude, Is.EqualTo(4.12345));

            ObservationLocation.Reset();
            theProfile.DeleteValue(Telescope.ProgId, "Longitude", "");
            theLocation = ObservationLocation.Location;

            Assert.That(theLocation.Longitude, Is.EqualTo(0.0));
        }

        [Test]
        public void TestLongitude()
        {
            Utilities.Profile theProfile = new Utilities.Profile();
            theProfile.DeviceType = "Telescope";

            theProfile.WriteValue(Telescope.ProgId, "Longitude", Convert.ToString(4.12345), "");
            ObservationLocation.Reset();
            ObservationLocation theLocation = ObservationLocation.Location;
            Assert.That(theLocation.Longitude, Is.EqualTo(4.12345).Within(0.00001));

            NotifyHandler theHandler = new NotifyHandler(theLocation);
            theLocation.Longitude = 12.54321;
            double storedLongitude = Convert.ToDouble(theProfile.GetValue(Telescope.ProgId, "Longitude", ""));
            Assert.That(theLocation.Longitude, Is.EqualTo(12.54321).Within(0.00001));
            Assert.That(storedLongitude,Is.EqualTo(12.54321).Within(0.00001));
            Assert.That(theHandler.nLongitudeChanges, Is.EqualTo(1));
        }

        [Test]
        public void TestUTC()
        {
            ObservationLocation.Reset();
            ObservationLocation theLocation = ObservationLocation.Location;
            Assert.That(theLocation.UTC, Is.EqualTo(DateTime.UtcNow));

            NotifyHandler theHandler = new NotifyHandler(theLocation);
            DateTime theDate = DateTime.UtcNow;
            theLocation.UTC = theDate.AddHours(2);
            DateTime theNewDate = theLocation.UTC;
            Assert.That(theNewDate.Date, Is.EqualTo(theDate.Date));
            Assert.That(theNewDate.Hour, Is.EqualTo(theDate.Hour + 2));
            Assert.That(theNewDate.Second, Is.EqualTo(theDate.Second));
            Assert.That(theNewDate.Minute, Is.EqualTo(theDate.Minute));
            Assert.That(theHandler.nUtcChanges, Is.EqualTo(1));
        }
    }
#endif
}
