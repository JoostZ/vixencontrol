using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ASCOM.VXAscom
{
    [ComVisible(false)]					// Form not registered for COM!
    public partial class SetupDialogForm : Form
    {
        private ObservationLocation iLocation;
        private LocalSiderialTime iLST;

        public SetupDialogForm()
        {
            iLocation = ObservationLocation.Location;
            iLST = LocalSiderialTime.LST;
            iLocation.Longitude = -4.12345;

            InitializeComponent();
            txtLST.DataBindings.Add("Text", iLST, "LAST_String", false, System.Windows.Forms.DataSourceUpdateMode.Never, null, "T");
            ctrlLon.DataBindings.Add("Value", iLocation, "Longitude", false, System.Windows.Forms.DataSourceUpdateMode.Never);
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
    }
}