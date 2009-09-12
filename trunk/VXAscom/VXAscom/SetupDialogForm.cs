using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;


using ASCOM.Helper;

namespace ASCOM.VXAscom
{
    [ComVisible(false)]					// Form not registered for COM!
    public partial class SetupDialogForm : Form
    {
        private ObservationLocation iLocation;
        private LocalSiderialTime iLST;

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
        private PortSpeed[] baudList = {
                PortSpeed.ps300,
                PortSpeed.ps1200,
                PortSpeed.ps4800,
                PortSpeed.ps9600,
                PortSpeed.ps14400,
                PortSpeed.ps19200,
                PortSpeed.ps28800,
                PortSpeed.ps38400,
                PortSpeed.ps57600,
                PortSpeed.ps115200
            };

        public SetupDialogForm()
        {
            iLocation = ObservationLocation.Location;
            iLST = LocalSiderialTime.LST;
            iLocation.Longitude = -4.12345;

            InitializeComponent();
            txtLST.DataBindings.Add("Text", iLST, "LAST_String", false, System.Windows.Forms.DataSourceUpdateMode.Never, null, "T");
            ctrlLon.DataBindings.Add("Value", iLocation, "Longitude", false, System.Windows.Forms.DataSourceUpdateMode.Never);

            Connection = null;

            // Create a list of serial ports on the system
            Ports = SerialPort.GetPortNames();
            comboPorts.Items.Add("Select a port");
            comboPorts.Items.AddRange(Ports);
            comboPorts.SelectedIndex = 0;

            

            foreach (PortSpeed speed in baudList)
            {
                int value = (int)speed;
                comboBaudRate.Items.Add(value.ToString());
            }
            comboBaudRate.SelectedIndex = 3; // default is 9600 baud

        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Dispose();
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

        private void comboPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = comboPorts.SelectedIndex;
            if (idx <= 0)
            {
                Connection = null;
                comboBaudRate.Enabled = false;
                return;
            }

            if (Connection == null)
            {
                Connection = new Serial();
            }
            string portName = comboPorts.SelectedItem.ToString().Remove(0, 3); //Removing the COM part
            Connection.Port = Convert.ToInt16(portName);
            comboBaudRate.Enabled = true;
        }

        private void comboBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Connection != null)
            {
                int idx = comboBaudRate.SelectedIndex;
                Connection.Speed = baudList[idx];
            }
        }
    }
}