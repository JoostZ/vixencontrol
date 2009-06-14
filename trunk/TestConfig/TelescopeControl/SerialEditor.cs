using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace TelescopeControl
{
    public partial class SerialEditor : Form
    {
        private SerialPort _port = null;

        public SerialEditor(SerialPort port)
        {
            _port = port;
            InitializeComponent();

            lblPort.Text = _port.PortName;
            txtBaud.Text = _port.BaudRate.ToString();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            _port.BaudRate = Convert.ToInt16(txtBaud.Text);
        }
    }
}