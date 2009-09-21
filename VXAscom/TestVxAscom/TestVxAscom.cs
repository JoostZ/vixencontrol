using System;
using ASCOM.Interface;
using ASCOM.Helper;
using ASCOM.DriverAccess;

using NLog;

namespace ASCOM
{
	class ClientTest
	{
        //private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

            Console.WriteLine("\r\nTelescope:");
            logger.Debug("Starting application");
            Telescope T;

            string ProgId = Telescope.Choose("");
            if (ProgId != "")
            {


                T = new Telescope(ProgId);


                //VXAscom.SetupDialogForm F = new VXAscom.SetupDialogForm();
                //T.SetupDialog();
                Console.WriteLine(" {0}", T.Connected);
                T.Connected = true;
            }
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
