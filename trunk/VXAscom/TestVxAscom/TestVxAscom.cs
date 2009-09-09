using System;
using ASCOM.Interface;
using ASCOM.Helper;


namespace ASCOM
{
	class ClientTest
	{
        static void Main(string[] args)
        {

            //Helper.Util U = new Helper.Util();

            Console.WriteLine("\r\nTelescope:");
            ITelescope T = new VXAscom.Telescope();
            T.SetupDialog();
            //Console.WriteLine("  Current LST = " + T.SiderealTime);
            //IAxisRates AxR = T.AxisRates(TelescopeAxes.axisPrimary);
            //Console.WriteLine("  " + AxR.Count + " rates");
            //if (AxR.Count == 0)
            //    Console.WriteLine("  Empty AxisRates!");
            //else
            //    foreach (IRate r in AxR)
            //        Console.WriteLine("  Max=" + r.Maximum + " Min=" + r.Minimum);
            //ITrackingRates TrR = T.TrackingRates;
            //if (TrR.Count == 0)
            //    Console.WriteLine("  Empty TrackingRates!");
            //else
            //    foreach (DriveRates dr in TrR)
            //        Console.WriteLine("  DriveRate=" + dr);


            //Console.Write("\r\nPress enter to quit...");
            //Console.ReadLine();
        }
	}
}
