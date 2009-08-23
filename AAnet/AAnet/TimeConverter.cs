using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace AAnet
{
    public class TimeConversion
    {
        List<KeyValuePair<DateTime, TimeConverter>> _list = new List<KeyValuePair<DateTime, TimeConverter>>();

        public TimeConversion(string[] aConverters)
        {
            string[] lastCorrections = new string[] {
                "0",
                "0",
                "0",
                "0"
            };
            char[] specialChars = new char[] {
                '?',
                '"'
            };

            char[] separator = new char[] { ' ' };
            foreach (String line in aConverters)
            {
                // Split of the date
                string[] fields = line.Split(separator, 2, StringSplitOptions.RemoveEmptyEntries);
                DateTime dt = DateTime.ParseExact(fields[0], "yyyy-MM-dd", null);

                // Split the remainder
                string[] corrections = fields[1].Split(separator, StringSplitOptions.RemoveEmptyEntries);
               
                int nElements = Math.Min(corrections.Length, 4);
                for (int i = 0; i < nElements; ++i)
                {
                    if (corrections[i] == "-")
                    {
                        lastCorrections[i] = "0";
                    }
                    else if (corrections[i].IndexOfAny(specialChars) < 0)
                    {
                        lastCorrections[i] = corrections[i];
                    }
                }

                _list.Add(new KeyValuePair<DateTime, TimeConverter>(dt, new TimeConverter(lastCorrections)));
            }
        }

        public TimeConverter GetConverter(DateTime aDT)
        {
            KeyValuePair<DateTime, TimeConverter> lastElement = _list.Last();
            if (aDT > _list.Last().Key)
            {
                return _list.Last().Value;
            }
            if (aDT <= _list.First().Key)
            {
                return _list.First().Value;
            }

            int i;
            for (i = 0; i <_list.Count; ++i)
            {
                if (aDT < _list[i].Key)
                {
                    break;
                }
            }
            // Found the first entry that is later then aDT
            Debug.Assert(i > 0 && i < _list.Count);
            return _list[i - 1].Value;
        }

    }
    /**
     * @brief
     * Give the offsets for the different time scale conversions
     */
    public class TimeConverter
    {
        private int _TaiUtc = 0; // TAI - UTC
        private int _GpsUtc = 0; // GPS - UTC
        private double _TtUt1 = 0; // TT - UT1;
        private double _Ut1Utc = 0; // UT1 - UTC;

        public TimeConverter(string[] aCorrections)
        {
            _TaiUtc = Convert.ToInt16(aCorrections[0]);
            _GpsUtc = Convert.ToInt16(aCorrections[1]);
            _TtUt1 = Convert.ToDouble(aCorrections[2]);
            _Ut1Utc = Convert.ToDouble(aCorrections[3]);

        }

        public double TaiUtc
        {
            get
            {
                return _TaiUtc;
            }
        }
        public double GpsUtc
        {
            get
            {
                return _GpsUtc;
            }
        }
        public double TtUt1
        {
            get
            {
                return _TtUt1;
            }
        }
        public double Ut1Utc
        {
            get
            {
                return _Ut1Utc;
            }
        }
    }
}
