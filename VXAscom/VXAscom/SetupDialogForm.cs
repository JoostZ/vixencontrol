using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;


using ASCOM.Utilities;

namespace ASCOM.VXAscom
{
    [ComVisible(false)]					// Form not registered for COM!
    public partial class SetupDialogForm : Form
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private ObservationLocation iLocation;

        private List<IUpdatable> _updateList = new List<IUpdatable>();

        /// <summary>
        /// List of serial ports available on the system
        /// </summary>
        private string[] Ports
        {
            get;
            set;
        }

        /// <summary>
        /// The (serial) connection to the controller
        /// </summary>
        /// <remarks>Could be null if the user did not select a serial port</remarks>
        public Serial Connection
        {
            get;
            set;
        }

        // List of supported baud rates
        private SerialSpeed[] baudList = {
                SerialSpeed.ps300,
                SerialSpeed.ps1200,
                SerialSpeed.ps4800,
                SerialSpeed.ps9600,
                SerialSpeed.ps14400,
                SerialSpeed.ps19200,
                SerialSpeed.ps28800,
                SerialSpeed.ps38400,
                SerialSpeed.ps57600,
                SerialSpeed.ps115200
            };

        public LocalSiderialTime LST
        {
            get;
            set;
        }

        public Telescope Driver {get;set;}
        public bool Tracking
        {
            get
            {
                return Driver.Tracking;
            }
            set
            {
                Driver.Tracking = value;
            }
        }

        public AAnet.Angle TestAngle { get; set; }
        public SetupDialogForm(Telescope aTelescope)
        {
            iLocation = ObservationLocation.Location;
            LST = LocalSiderialTime.LST;
            _updateList.Add(LST);
            iLocation.Longitude = -4.12345;

            RaAxis = aTelescope.RaAxis;
            Driver = aTelescope;

            InitializeComponent();
            //txtLST.DataBindings.Add("Text", iLST, "LAST_String", false, System.Windows.Forms.DataSourceUpdateMode.Never, null, "T");
            ctrlLon.DataBindings.Add("Value", iLocation, "Longitude", false, System.Windows.Forms.DataSourceUpdateMode.Never);

            Connection = Driver.Controller.Connection;

            // Create a list of serial ports on the system
            Ports = SerialPort.GetPortNames();
            comboPorts.Items.Add("Select a port");
            comboPorts.Items.AddRange(Ports);
            if (Connection != null)
            {
                string portName = String.Format("COM{0}", Connection.Port);
                comboPorts.SelectedItem = portName;
            }
            else
            {
                comboPorts.SelectedIndex = 0;
            }

            foreach (SerialSpeed speed in baudList)
            {
                int value = (int)speed;
                comboBaudRate.Items.Add(value.ToString());
            }

            if (Connection != null)
            {
                string selectedItem = ((Int16)Connection.Speed).ToString();
                comboBaudRate.SelectedItem = selectedItem;
            }
            else
            {
                comboBaudRate.SelectedIndex = 3; // default is 9600 baud
            }


            this.setupDialogFormBindingSource.DataSource = this;
            this.TestAngle = AAnet.Angle.FromDegrees(24.12345);

        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            ;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        Axis.AxisControl _raAxis;
        public Axis.AxisControl RaAxis
        {
            get
            {
                return _raAxis;
            }
            set
            {
                _raAxis = value;
                if (_updateList.IndexOf(_raAxis) == -1)
                {
                    _updateList.Add(_raAxis);
                }
            }
        }
        private void BrowseToAscom(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://ascom-standards.org/");
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        public bool HasConnection
        {
            get
            {
                return Connection != null;
            }
        }

        private void comboPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = comboPorts.SelectedIndex;
            if (idx <= 0)
            {
                Connection = null;
                comboBaudRate.Enabled = false;
                btnConnect.Enabled = false;
                return;
            }

            if (Connection == null)
            {
                Connection = new Serial();
                Driver.Controller.Connection = Connection;
            }
            string portName = comboPorts.SelectedItem.ToString().Remove(0, 3); //Removing the COM part
            Connection.Port = Convert.ToInt16(portName);
            comboBaudRate.Enabled = true;
            btnConnect.Enabled = true;
        }

        private void comboBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Connection != null)
            {
                int idx = comboBaudRate.SelectedIndex;
                Connection.Speed = baudList[idx];
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connection.Connected = true;
            Driver.Controller.Connection = Connection;
            chkConnected.Checked = true;
            Tracking = false;
        }

        private void tmrAutoUpdate_Tick(object sender, EventArgs e)
        {
            foreach (IUpdatable item in _updateList)
            {
                //item.Update();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (IUpdatable item in _updateList)
            {
                item.Update();
            }
        }

        private void SetupDialogForm_Load(object sender, EventArgs e)
        {
            axisControlDisplayBindingSource.DataSource = RaAxis;
            tmrAutoUpdate.Start();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SetupDialogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrAutoUpdate.Stop();
            tmrAutoUpdate.Dispose();
        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            RaAxis.LoadStatus();
        }
    }
}
