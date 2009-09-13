/**
 * @file Form1.cs
 * 
 * This is the User definition of the main form
 * 
 * @mainpage Telescope Control
 * 
 * This program is intended to assist in developing the software in the
 * microcontroler 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
//using NLog;

namespace TestConfig
{
    using Boxdorfer;

    public partial class Form1 : Form
    {
        private const string  Version = "1.400"; ///< The version of the program
                                                 ///
        //private static Logger logger = LogManager.GetCurrentClassLogger();

        
        //private delegate void SetTextCallback(byte[] aByte);
        private BoxdorferSerial iSerial;

        //private void HandleByte(byte[] aByte)
        //{
        //    // InvokeRequired required compares the thread ID of the
        //    // calling thread to the thread ID of the creating thread.
        //    // If these threads are different, it returns true.
        //    if (this.InvokeRequired)
        //    {
        //        SetTextCallback d = new SetTextCallback(HandleByte);
        //        this.Invoke(d, new object[] { aByte });
        //    }
        //    else
        //    {
        //        this.iSerial.HandleByte(aByte);
        //    }
        //}

        private int _missedCommunication = 0;

        /**
         * @brief 
         * Property count of Missed Communication attempts with the controler
         */
        public int MissedCommunication
        {
            get
            {
                return _missedCommunication;
            }
            set
            {
                _missedCommunication = value;
            }
        }

        private SerialPort port = null;

        public SerialPort ComPort
        {
            get
            {
                return port;
            }
            set
            {
                port = value;
            }
        }

        public bool Connected
        {
            get
            {
                return ComPort != null && ComPort.IsOpen;
            }
        }

        public event EventHandler MissedCommunicationChanged;
        public event EventHandler ConnectedChanged;
        public event EventHandler TimerRunningChanged;

        private void OnMissedCommunicationChanged()
        {
            if (MissedCommunicationChanged != null)
            {
                MissedCommunicationChanged(this, EventArgs.Empty);
            }
        }

        private void OnConnectedChanged()
        {
            if (ConnectedChanged != null)
            {
                ConnectedChanged(this, EventArgs.Empty);
            }
        }
        private void OnTimerRunningChanged()
        {
            if (TimerRunningChanged != null)
            {
                TimerRunningChanged(this, EventArgs.Empty);
            }
        }
        
        private string[] comPorts;

        public string[] Ports
        {
            get
            {
                return comPorts;
            }
            set
            {
                comPorts = value;
            }
        }

        private BoxdorferLong raFast;
        private BoxdorferLong raCurrentPos;
        private BoxdorferLong raTargetPos;
        private BoxdorferLong raAcceleration;
        private BoxdorferLong raAccelerationUpdate;
        private BoxdorferLong raCurrentSpeed;
        private BoxdorferLong raAccelerationLowerLimit;
        private BoxdorferLong raBacklash;
        private BoxdorferLong atmelVersion;

        private List<ISynchronizable> commands = new List<ISynchronizable>(); 

        public bool TimerRunning
        {
            get
            {
                return tmrAutoUpdate.Enabled;
            }
            set
            {
                tmrAutoUpdate.Interval = Convert.ToInt16(txtRaTimerInterval.Text);
                tmrAutoUpdate.Enabled = value;
                OnTimerRunningChanged();
            }
        }

        public Form1()
        {
            InitializeComponent();
            //logger.Debug("Initializing Form1");
            Ports = SerialPort.GetPortNames();
            comboPorts.Items.Add("Select a port");
            comboPorts.Items.AddRange(Ports);
            comboPorts.SelectedIndex = 0;

            txtMissed.DataBindings.Add("Text", this, "MissedCommunication");

            groupRA.DataBindings.Add("Enabled", this, "Connected");
            grpSynch.DataBindings.Add("Enabled", this, "Connected");
            //grpRaAcceleration.DataBindings.Add("Enabled", this, "Connected");

            atmelVersion = new BoxdorferLong(0, BoxdorferSerial.getVersion);
            txtVersion.DataBindings.Add("Text", atmelVersion, "Value");
            txtMyVersion.Text = Version;

            raFast = new BoxdorferLong(BoxdorferSerial.writeRALimit, 
                                       BoxdorferSerial.readRALimit);
            commands.Add(raFast);
            txtFastSpeed.DataBindings.Add("Text", raFast, "Value");

            // TODO: Handle radio controls for microsteps

            raBacklash = new BoxdorferLong(BoxdorferSerial.writeRaBacklash, BoxdorferSerial.readRaBacklash);
            commands.Add(raBacklash);
            txtRaBacklash.DataBindings.Add("Text", raBacklash, "Value");

            // Acceleration
            raAcceleration = new BoxdorferLong(BoxdorferSerial.writeRaAcceleration,
                                                BoxdorferSerial.readRaAcceleration);

            commands.Add(raAcceleration);
            txtRaAccelaration.DataBindings.Add("Text", raAcceleration, "Value");

            raAccelerationUpdate = new BoxdorferLong(BoxdorferSerial.writeRaAccelerationUpdate,
                                                     BoxdorferSerial.readRaAccelerationUpdate);
            commands.Add(raAccelerationUpdate);
            txtRaUpdatePeriod.DataBindings.Add("Text", raAccelerationUpdate, "Value");

            raAccelerationLowerLimit = new RaAccLowerLimit();
            commands.Add(raAccelerationLowerLimit);
            txtRaAccLL.DataBindings.Add("Text", raAccelerationLowerLimit, "Value");

            // Current position
            raCurrentPos = new BoxdorferLong(0, BoxdorferSerial.readRaCurrentPos);
            commands.Add(raCurrentPos);
            txtRaCurrentPos.DataBindings.Add("Text", raCurrentPos, "Value");
            raCurrentPos.ValueChanged += new EventHandler(raCurrentPos_ValueChanged);

            raCurrentSpeed = new BoxdorferLong(0, BoxdorferSerial.readRaCurrentAccleration);
            commands.Add(raCurrentSpeed);
            txtCurrentRaSpeed.DataBindings.Add("Text", raCurrentSpeed, "Value");

            raTargetPos = new BoxdorferLong(BoxdorferSerial.writeRaTargetPosition, BoxdorferSerial.readRaTargetPosition);
            commands.Add(raTargetPos);
            txtRaTargetPos.DataBindings.Add("Text", raTargetPos, "Value");

            txtRaTimerInterval.DataBindings.Add("ReadOnly", this, "TimerRunning");

            if (chkRaCurrentAuto.Checked)
            {
                TimerRunning = true;
            }
            else
            {
                TimerRunning = false;
            }

        
        }

        
        void SynchronizeRead()
        {

            //iSerial.Flush();
            foreach (ISynchronizable theComand in commands)
            {
                theComand.Read(iSerial);
            }
        }

        //void ComPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{

        //    byte[] data = new byte[ComPort.BytesToRead];
        //    for (int i = 0; i < data.Length; i++)
        //    {
        //        data[i] = (byte)ComPort.ReadByte();
        //    }
            
        //    this.HandleByte(data);
            

        //    //throw new Exception("The method or operation is not implemented.");
        //}

        private void comboPorts_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ComPort != null)
            {
                ComPort.Close();
                OnConnectedChanged();
            }

            int idx = comboPorts.SelectedIndex;
            if (idx <= 0)
            {
                ComPort = null;
                butEditSerial.Enabled = false;
                return;
            }

            string portName = comboPorts.SelectedItem.ToString();
            ComPort = new SerialPort(portName);

            //ComPort.DataReceived += new SerialDataReceivedEventHandler(ComPort_DataReceived);
            butEditSerial.Enabled = true;
            ComPort.Open();
            OnConnectedChanged();
            iSerial = new BoxdorferSerial(ComPort, this);

            atmelVersion.Read(iSerial);
            SynchronizeRead();

        }

        private void butEditSerial_Click(object sender, EventArgs e)
        {
            Form dlg = new SerialEditor(ComPort);
            dlg.ShowDialog();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ComPort != null)
            {
                //readingThread.Abort();
                //readingThread.Join();
                ComPort.Close();
                ComPort.Dispose();
            }
        }

        private void btnLoadFastSpeed_Click(object sender, EventArgs e)
        {
            raFast.Read(iSerial);
        }

        private void btnWriteFastSpeed_Click(object sender, EventArgs e)
        {
            raFast.Write(iSerial);
        }

        private long lastPosition = 0;
        private const float trackingSpeed = 19.252588f;

        void raCurrentPos_ValueChanged(object sender, EventArgs e)
        {
            long nPulses = raCurrentPos.Value - lastPosition;
            lastPosition = raCurrentPos.Value;
            int speed = (int)(nPulses / (0.001 * tmrAutoUpdate.Interval) / trackingSpeed);
            //txtCurrentRaSpeed.Text = speed.ToString();


        }


        private void tmrAutoUpdate_Tick(object sender, EventArgs e)
        {
            lastPosition = raCurrentPos.Value;
            raCurrentPos.Read(iSerial);
            raCurrentSpeed.Read(iSerial);
        }

        private void btnSynchLoad_Click(object sender, EventArgs e)
        {
            SynchronizeRead();
        }

        private void chkRaCurrentAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRaCurrentAuto.Checked)
            {
                TimerRunning = true;
            }
            else
            {
                TimerRunning = false;
            }
        }

        private void txtRaTimerInterval_Validated(object sender, EventArgs e)
        {
            tmrAutoUpdate.Interval = Convert.ToInt16(txtRaTimerInterval.Text);
        }

        private void chkRaTracking_CheckedChanged(object sender, EventArgs e)
        {
            if (iSerial == null)
            {
                return;
            }

            BoxdorferCommand theCommand;
            if (chkRaTracking.Checked)
            {
                theCommand = new BoxdorferCommand(BoxdorferSerial.writeOnOn);
            }
            else
            {
                theCommand = new BoxdorferCommand(BoxdorferSerial.writeOnOff);
            }
            iSerial.AddCommand(theCommand);
        }

        private void backgroundSerial_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            int nBytes = (int)e.Argument;

            ComPort.ReadTimeout = 400;
            byte[] result = new byte[nBytes];
            for (int i = 0; i < nBytes; i++)
            {
                result[i] = (byte)ComPort.ReadByte();
            }

            e.Result = result;
        }

        private void backgroundSerial_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                iSerial.Flush();
                MissedCommunication += 1;
                OnMissedCommunicationChanged();
                //MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled 
                // the operation.
                // Note that due to a race condition in 
                // the DoWork event handler, the Cancelled
                // flag may not have been set, even though
                // CancelAsync was called.
                MessageBox.Show("Canceled");
            }
            else
            {
                iSerial.HandleByte(e.Result as byte[]);
            }
        }

        private void btnRaPosLoad_Click(object sender, EventArgs e)
        {
            raCurrentPos.Read(iSerial);
            raCurrentSpeed.Read(iSerial);
        }

        private void chkRaFast_CheckedChanged(object sender, EventArgs e)
        {
            if (iSerial == null)
            {
                return;
            }

            BoxdorferCommand theCommand;
            if (chkRaFast.Checked)
            {
                theCommand = new BoxdorferCommand(BoxdorferSerial.writeFastOn);
            }
            else
            {
                theCommand = new BoxdorferCommand(BoxdorferSerial.writeFastOff);
            }
            iSerial.AddCommand(theCommand);
        }

        private void rdRaCtrlRight_CheckedChanged(object sender, EventArgs e)
        {
            if (iSerial == null)
            {
                return;
            }

            BoxdorferCommand theCommand;
            if (rdRaCtrlRight.Checked)
            {
                theCommand = new BoxdorferCommand(BoxdorferSerial.writeRightOn);
            }
            else
            {
                theCommand = new BoxdorferCommand(BoxdorferSerial.writeRightOff);
            }
            iSerial.AddCommand(theCommand);
        }

        private void rdRaCtrlLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (iSerial == null)
            {
                return;
            }

            BoxdorferCommand theCommand;
            if (rdRaCtrlLeft.Checked)
            {
                theCommand = new BoxdorferCommand(BoxdorferSerial.writeLeftOn);
            }
            else
            {
                theCommand = new BoxdorferCommand(BoxdorferSerial.writeLeftOff);
            }
            iSerial.AddCommand(theCommand);
        }

        

        private void btnRaLoadAcceleration_Click(object sender, EventArgs e)
        {
            raAcceleration.Read(iSerial);
        }

        private void btnRaWriteAccelaration_Click(object sender, EventArgs e)
        {
            raAcceleration.Write(iSerial);
        }


        private void btnGetVersion_Click(object sender, EventArgs e)
        {
            atmelVersion.Read(iSerial);
        }

        private void btnRaAccelerationLoadUpdate_Click(object sender, EventArgs e)
        {
            raAccelerationUpdate.Read(iSerial);
        }

        private void btnRaAccelerationWriteUpdate_Click(object sender, EventArgs e)
        {
            raAccelerationUpdate.Write(iSerial);
        }

        private void btnRaAccLLLoad_Click(object sender, EventArgs e)
        {
            raAccelerationLowerLimit.Read(iSerial);
        }

        private void btnRaAccLLWrite_Click(object sender, EventArgs e)
        {
            raAccelerationLowerLimit.Write(iSerial);
        }

        private void btnRaTargetLoad_Click(object sender, EventArgs e)
        {
            raTargetPos.Read(iSerial);
        }

        private void btnRaTargetWrite_Click(object sender, EventArgs e)
        {
            raTargetPos.Write(iSerial);
        }

        private void btnRaBacklashLoad_Click(object sender, EventArgs e)
        {
            raBacklash.Read(iSerial);
        }

        private void btnRaBacklashWrite_Click(object sender, EventArgs e)
        {
            raBacklash.Write(iSerial);
        }

        private void btnResetCurrPos_Click(object sender, EventArgs e)
        {
            if (iSerial == null)
            {
                return;
            }

            BoxdorferCommand theCommand = new BoxdorferCommand(BoxdorferSerial.resetRaCurrentPos);
            
            iSerial.AddCommand(theCommand);
            raCurrentPos.Read(iSerial);
        }

        private void btnRaGotoStart_Click(object sender, EventArgs e)
        {
            if (iSerial == null)
            {
                return;
            }

            raTargetPos.Write(iSerial);
            BoxdorferCommand theCommand;
            theCommand = new BoxdorferCommand(BoxdorferSerial.writeRaGotoStart);
            iSerial.AddCommand(theCommand);
        }

        private void btnRaGotoStop_Click(object sender, EventArgs e)
        {
            if (iSerial == null)
            {
                return;
            }

            BoxdorferCommand theCommand;
            theCommand = new BoxdorferCommand(BoxdorferSerial.writeRaGotoStop);
            iSerial.AddCommand(theCommand);
        }

    }
}