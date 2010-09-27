using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NLog;
using ASCOM;
using ASCOM.Utilities;
using ASCOM.DriverAccess;

namespace TestVxAscomGui
{
    public partial class Form1 : Form, INotifyPropertyChanged 
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static ASCOM.Utilities.Util util = new ASCOM.Utilities.Util();

        internal string progId = "ASCOM.VXAscom.Telescope";
        public Telescope Driver {get;set;}

        internal DriverData data = new DriverData();

        public Form1()
        {
            InitializeComponent();
            form1BindingSource.DataSource = data;
            //data.LST = Driver.SiderealTime;
            //data.RA = Driver.RightAscension;
            RaMoveRate = 1.0;
        }

        public double RA
        {
            get;
            set;
        }

        public string LSTString
        {
            get
            {
                return util.HoursToHMS(Driver.SiderealTime, ":", ":", "", 0);
            }
        }

        public double RaMoveRate { get; set; }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            Driver.SetupDialog();
        }

        private void tmrAutoUpdate_Tick(object sender, EventArgs e)
        {
            if (Driver == null)
            {
                return;
            }
            data.Update(Driver);
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            tmrAutoUpdate.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrAutoUpdate.Stop();
            tmrAutoUpdate.Dispose();
        }

        private void chkMoveRa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoveRa.Checked)
            {
                double rate = Convert.ToDouble(RaMoveRate);
                Driver.MoveAxis(ASCOM.Interface.TelescopeAxes.axisPrimary, rate);
            }
            else
            {
                Driver.MoveAxis(ASCOM.Interface.TelescopeAxes.axisPrimary, 0.0);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                Chooser choose = new Chooser();
                choose.DeviceType = "Telescope";
                string ProgId = choose.Choose(progId);
                if (ProgId != "")
                {
                    if (Driver != null)
                    {
                        Driver.Dispose();
                    }

                    Driver = new Telescope(ProgId);
                    btnSetup.Enabled = true;

                    nameTextBox.Text = Driver.Name;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void trackingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (data.Tracking != trackingCheckBox.Checked)
            {
                Driver.Tracking = trackingCheckBox.Checked;
            }
        }
    }
}
