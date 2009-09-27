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
using ASCOM.DriverAccess;

namespace TestVxAscomGui
{
    public partial class Form1 : Form, INotifyPropertyChanged 
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static ASCOM.Helper.Util util = new ASCOM.Helper.Util();

        internal string progId = "ASCOM.VXAscom.Telescope";
        public Telescope Driver {get;set;}

        public Form1()
        {
            InitializeComponent();
            Driver = new Telescope(progId);
            form1BindingSource.DataSource = this;
            RaMoveRate = 10.5;
        }

        public string RaString
        {
            get
            {
                return util.HoursToHMS(Driver.RightAscension, ":", ":", "", 1);
            }
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
            NotifyPropertyChanged("LSTString");
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
    }
}
