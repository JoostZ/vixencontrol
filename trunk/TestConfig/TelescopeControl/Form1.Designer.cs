namespace TelescopeControl
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboPorts = new System.Windows.Forms.ComboBox();
            this.butEditSerial = new System.Windows.Forms.Button();
            this.fastSpeedBox = new System.Windows.Forms.GroupBox();
            this.btnWriteFastSpeed = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLoadFastSpeed = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurrentRaSpeed = new System.Windows.Forms.TextBox();
            this.txtFastSpeed = new System.Windows.Forms.TextBox();
            this.groupRA = new System.Windows.Forms.GroupBox();
            this.grpBacklash = new System.Windows.Forms.GroupBox();
            this.btnRaBacklashWrite = new System.Windows.Forms.Button();
            this.btnRaBacklashLoad = new System.Windows.Forms.Button();
            this.txtRaBacklash = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkRaCurrentAuto = new System.Windows.Forms.CheckBox();
            this.txtRaTimerInterval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRaPosLoad = new System.Windows.Forms.Button();
            this.grpRaAcceleration = new System.Windows.Forms.GroupBox();
            this.btnRaAccLLWrite = new System.Windows.Forms.Button();
            this.btnRaAccLLLoad = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRaAccLL = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnRaAccelerationWriteUpdate = new System.Windows.Forms.Button();
            this.btnRaAccelerationLoadUpdate = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtRaUpdatePeriod = new System.Windows.Forms.TextBox();
            this.btnRaWriteAccelaration = new System.Windows.Forms.Button();
            this.btnRaLoadAcceleration = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRaAccelaration = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkRaFast = new System.Windows.Forms.CheckBox();
            this.chkRaTracking = new System.Windows.Forms.CheckBox();
            this.rdRaCtrlRight = new System.Windows.Forms.RadioButton();
            this.rdRaCtrlOff = new System.Windows.Forms.RadioButton();
            this.rdRaCtrlLeft = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRaGotoStop = new System.Windows.Forms.Button();
            this.btnRaGotoStart = new System.Windows.Forms.Button();
            this.btnResetCurrPos = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRaTargetPos = new System.Windows.Forms.TextBox();
            this.txtRaCurrentPos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpRaMicroSteps = new System.Windows.Forms.GroupBox();
            this.btnRaMicroWrite = new System.Windows.Forms.Button();
            this.btnRaMicroLoad = new System.Windows.Forms.Button();
            this.rBtnRaMicro3 = new System.Windows.Forms.RadioButton();
            this.rBtnRaMicro2 = new System.Windows.Forms.RadioButton();
            this.rBtnRaMicro1 = new System.Windows.Forms.RadioButton();
            this.rBtnRaMicro0 = new System.Windows.Forms.RadioButton();
            this.tmrAutoUpdate = new System.Windows.Forms.Timer(this.components);
            this.grpSynch = new System.Windows.Forms.GroupBox();
            this.btnSynchLoad = new System.Windows.Forms.Button();
            this.btnSynchWrite = new System.Windows.Forms.Button();
            this.backgroundSerial = new System.ComponentModel.BackgroundWorker();
            this.txtMissed = new System.Windows.Forms.TextBox();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGetVersion = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMyVersion = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fastSpeedBox.SuspendLayout();
            this.groupRA.SuspendLayout();
            this.grpBacklash.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.grpRaAcceleration.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpRaMicroSteps.SuspendLayout();
            this.grpSynch.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboPorts
            // 
            this.comboPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPorts.FormattingEnabled = true;
            this.comboPorts.Location = new System.Drawing.Point(12, 12);
            this.comboPorts.Name = "comboPorts";
            this.comboPorts.Size = new System.Drawing.Size(121, 21);
            this.comboPorts.TabIndex = 0;
            this.comboPorts.SelectedIndexChanged += new System.EventHandler(this.comboPorts_SelectedIndexChanged);
            // 
            // butEditSerial
            // 
            this.butEditSerial.AutoSize = true;
            this.butEditSerial.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.butEditSerial.Enabled = false;
            this.butEditSerial.Location = new System.Drawing.Point(150, 10);
            this.butEditSerial.Name = "butEditSerial";
            this.butEditSerial.Size = new System.Drawing.Size(35, 23);
            this.butEditSerial.TabIndex = 1;
            this.butEditSerial.Text = "Edit";
            this.butEditSerial.UseVisualStyleBackColor = true;
            this.butEditSerial.Click += new System.EventHandler(this.butEditSerial_Click);
            // 
            // fastSpeedBox
            // 
            this.fastSpeedBox.Controls.Add(this.btnWriteFastSpeed);
            this.fastSpeedBox.Controls.Add(this.label6);
            this.fastSpeedBox.Controls.Add(this.btnLoadFastSpeed);
            this.fastSpeedBox.Controls.Add(this.label5);
            this.fastSpeedBox.Controls.Add(this.label1);
            this.fastSpeedBox.Controls.Add(this.txtCurrentRaSpeed);
            this.fastSpeedBox.Controls.Add(this.txtFastSpeed);
            this.fastSpeedBox.Location = new System.Drawing.Point(19, 10);
            this.fastSpeedBox.Name = "fastSpeedBox";
            this.fastSpeedBox.Size = new System.Drawing.Size(310, 86);
            this.fastSpeedBox.TabIndex = 2;
            this.fastSpeedBox.TabStop = false;
            this.fastSpeedBox.Text = "FastSpeed";
            // 
            // btnWriteFastSpeed
            // 
            this.btnWriteFastSpeed.Location = new System.Drawing.Point(100, 47);
            this.btnWriteFastSpeed.Name = "btnWriteFastSpeed";
            this.btnWriteFastSpeed.Size = new System.Drawing.Size(75, 23);
            this.btnWriteFastSpeed.TabIndex = 3;
            this.btnWriteFastSpeed.Text = "Write";
            this.btnWriteFastSpeed.UseVisualStyleBackColor = true;
            this.btnWriteFastSpeed.Click += new System.EventHandler(this.btnWriteFastSpeed_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(195, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Current Speed";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLoadFastSpeed
            // 
            this.btnLoadFastSpeed.Location = new System.Drawing.Point(7, 47);
            this.btnLoadFastSpeed.Name = "btnLoadFastSpeed";
            this.btnLoadFastSpeed.Size = new System.Drawing.Size(75, 23);
            this.btnLoadFastSpeed.TabIndex = 2;
            this.btnLoadFastSpeed.Text = "Load";
            this.btnLoadFastSpeed.UseVisualStyleBackColor = true;
            this.btnLoadFastSpeed.Click += new System.EventHandler(this.btnLoadFastSpeed_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(245, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "0.1 tracking";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X tracking speed";
            // 
            // txtCurrentRaSpeed
            // 
            this.txtCurrentRaSpeed.Location = new System.Drawing.Point(198, 50);
            this.txtCurrentRaSpeed.Name = "txtCurrentRaSpeed";
            this.txtCurrentRaSpeed.ReadOnly = true;
            this.txtCurrentRaSpeed.Size = new System.Drawing.Size(41, 20);
            this.txtCurrentRaSpeed.TabIndex = 6;
            // 
            // txtFastSpeed
            // 
            this.txtFastSpeed.Location = new System.Drawing.Point(7, 20);
            this.txtFastSpeed.Name = "txtFastSpeed";
            this.txtFastSpeed.Size = new System.Drawing.Size(75, 20);
            this.txtFastSpeed.TabIndex = 0;
            this.txtFastSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupRA
            // 
            this.groupRA.AutoSize = true;
            this.groupRA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupRA.Controls.Add(this.grpBacklash);
            this.groupRA.Controls.Add(this.groupBox4);
            this.groupRA.Controls.Add(this.grpRaAcceleration);
            this.groupRA.Controls.Add(this.groupBox2);
            this.groupRA.Controls.Add(this.groupBox1);
            this.groupRA.Controls.Add(this.grpRaMicroSteps);
            this.groupRA.Controls.Add(this.fastSpeedBox);
            this.groupRA.Location = new System.Drawing.Point(12, 115);
            this.groupRA.Name = "groupRA";
            this.groupRA.Size = new System.Drawing.Size(358, 588);
            this.groupRA.TabIndex = 3;
            this.groupRA.TabStop = false;
            this.groupRA.Text = "RA";
            // 
            // grpBacklash
            // 
            this.grpBacklash.Controls.Add(this.btnRaBacklashWrite);
            this.grpBacklash.Controls.Add(this.btnRaBacklashLoad);
            this.grpBacklash.Controls.Add(this.txtRaBacklash);
            this.grpBacklash.Location = new System.Drawing.Point(218, 102);
            this.grpBacklash.Name = "grpBacklash";
            this.grpBacklash.Size = new System.Drawing.Size(134, 80);
            this.grpBacklash.TabIndex = 8;
            this.grpBacklash.TabStop = false;
            this.grpBacklash.Text = "Backlash";
            // 
            // btnRaBacklashWrite
            // 
            this.btnRaBacklashWrite.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRaBacklashWrite.Location = new System.Drawing.Point(66, 42);
            this.btnRaBacklashWrite.Name = "btnRaBacklashWrite";
            this.btnRaBacklashWrite.Size = new System.Drawing.Size(54, 23);
            this.btnRaBacklashWrite.TabIndex = 2;
            this.btnRaBacklashWrite.Text = "Write";
            this.btnRaBacklashWrite.UseVisualStyleBackColor = true;
            this.btnRaBacklashWrite.Click += new System.EventHandler(this.btnRaBacklashWrite_Click);
            // 
            // btnRaBacklashLoad
            // 
            this.btnRaBacklashLoad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRaBacklashLoad.Location = new System.Drawing.Point(11, 42);
            this.btnRaBacklashLoad.Name = "btnRaBacklashLoad";
            this.btnRaBacklashLoad.Size = new System.Drawing.Size(49, 23);
            this.btnRaBacklashLoad.TabIndex = 1;
            this.btnRaBacklashLoad.Text = "Load";
            this.btnRaBacklashLoad.UseVisualStyleBackColor = true;
            this.btnRaBacklashLoad.Click += new System.EventHandler(this.btnRaBacklashLoad_Click);
            // 
            // txtRaBacklash
            // 
            this.txtRaBacklash.Location = new System.Drawing.Point(11, 15);
            this.txtRaBacklash.Name = "txtRaBacklash";
            this.txtRaBacklash.Size = new System.Drawing.Size(100, 20);
            this.txtRaBacklash.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkRaCurrentAuto);
            this.groupBox4.Controls.Add(this.txtRaTimerInterval);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.btnRaPosLoad);
            this.groupBox4.Location = new System.Drawing.Point(19, 448);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(275, 55);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Status";
            // 
            // chkRaCurrentAuto
            // 
            this.chkRaCurrentAuto.AutoSize = true;
            this.chkRaCurrentAuto.Checked = true;
            this.chkRaCurrentAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRaCurrentAuto.Location = new System.Drawing.Point(6, 21);
            this.chkRaCurrentAuto.Name = "chkRaCurrentAuto";
            this.chkRaCurrentAuto.Size = new System.Drawing.Size(83, 17);
            this.chkRaCurrentAuto.TabIndex = 2;
            this.chkRaCurrentAuto.Text = "AutoUpdate";
            this.chkRaCurrentAuto.UseVisualStyleBackColor = true;
            this.chkRaCurrentAuto.CheckedChanged += new System.EventHandler(this.chkRaCurrentAuto_CheckedChanged);
            // 
            // txtRaTimerInterval
            // 
            this.txtRaTimerInterval.Location = new System.Drawing.Point(95, 19);
            this.txtRaTimerInterval.Name = "txtRaTimerInterval";
            this.txtRaTimerInterval.Size = new System.Drawing.Size(41, 20);
            this.txtRaTimerInterval.TabIndex = 3;
            this.txtRaTimerInterval.Text = "100";
            this.txtRaTimerInterval.Validated += new System.EventHandler(this.txtRaTimerInterval_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "mSec";
            // 
            // btnRaPosLoad
            // 
            this.btnRaPosLoad.Location = new System.Drawing.Point(184, 17);
            this.btnRaPosLoad.Name = "btnRaPosLoad";
            this.btnRaPosLoad.Size = new System.Drawing.Size(75, 23);
            this.btnRaPosLoad.TabIndex = 5;
            this.btnRaPosLoad.Text = "Load";
            this.btnRaPosLoad.UseVisualStyleBackColor = true;
            this.btnRaPosLoad.Click += new System.EventHandler(this.btnRaPosLoad_Click);
            // 
            // grpRaAcceleration
            // 
            this.grpRaAcceleration.AutoSize = true;
            this.grpRaAcceleration.Controls.Add(this.btnRaAccLLWrite);
            this.grpRaAcceleration.Controls.Add(this.btnRaAccLLLoad);
            this.grpRaAcceleration.Controls.Add(this.label12);
            this.grpRaAcceleration.Controls.Add(this.txtRaAccLL);
            this.grpRaAcceleration.Controls.Add(this.label11);
            this.grpRaAcceleration.Controls.Add(this.btnRaAccelerationWriteUpdate);
            this.grpRaAcceleration.Controls.Add(this.btnRaAccelerationLoadUpdate);
            this.grpRaAcceleration.Controls.Add(this.label10);
            this.grpRaAcceleration.Controls.Add(this.lblUpdate);
            this.grpRaAcceleration.Controls.Add(this.txtRaUpdatePeriod);
            this.grpRaAcceleration.Controls.Add(this.btnRaWriteAccelaration);
            this.grpRaAcceleration.Controls.Add(this.btnRaLoadAcceleration);
            this.grpRaAcceleration.Controls.Add(this.label4);
            this.grpRaAcceleration.Controls.Add(this.txtRaAccelaration);
            this.grpRaAcceleration.Location = new System.Drawing.Point(19, 188);
            this.grpRaAcceleration.Name = "grpRaAcceleration";
            this.grpRaAcceleration.Size = new System.Drawing.Size(333, 130);
            this.grpRaAcceleration.TabIndex = 6;
            this.grpRaAcceleration.TabStop = false;
            this.grpRaAcceleration.Text = "Acceleration";
            // 
            // btnRaAccLLWrite
            // 
            this.btnRaAccLLWrite.Location = new System.Drawing.Point(245, 88);
            this.btnRaAccLLWrite.Name = "btnRaAccLLWrite";
            this.btnRaAccLLWrite.Size = new System.Drawing.Size(55, 23);
            this.btnRaAccLLWrite.TabIndex = 13;
            this.btnRaAccLLWrite.Text = "Write";
            this.btnRaAccLLWrite.UseVisualStyleBackColor = true;
            this.btnRaAccLLWrite.Click += new System.EventHandler(this.btnRaAccLLWrite_Click);
            // 
            // btnRaAccLLLoad
            // 
            this.btnRaAccLLLoad.Location = new System.Drawing.Point(184, 88);
            this.btnRaAccLLLoad.Name = "btnRaAccLLLoad";
            this.btnRaAccLLLoad.Size = new System.Drawing.Size(55, 23);
            this.btnRaAccLLLoad.TabIndex = 12;
            this.btnRaAccLLLoad.Text = "Load";
            this.btnRaAccLLLoad.UseVisualStyleBackColor = true;
            this.btnRaAccLLLoad.Click += new System.EventHandler(this.btnRaAccLLLoad_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(122, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "x Tracking";
            // 
            // txtRaAccLL
            // 
            this.txtRaAccLL.Location = new System.Drawing.Point(70, 90);
            this.txtRaAccLL.Name = "txtRaAccLL";
            this.txtRaAccLL.Size = new System.Drawing.Size(46, 20);
            this.txtRaAccLL.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "LowerLimit";
            // 
            // btnRaAccelerationWriteUpdate
            // 
            this.btnRaAccelerationWriteUpdate.Location = new System.Drawing.Point(245, 57);
            this.btnRaAccelerationWriteUpdate.Name = "btnRaAccelerationWriteUpdate";
            this.btnRaAccelerationWriteUpdate.Size = new System.Drawing.Size(55, 23);
            this.btnRaAccelerationWriteUpdate.TabIndex = 8;
            this.btnRaAccelerationWriteUpdate.Text = "Write";
            this.btnRaAccelerationWriteUpdate.UseVisualStyleBackColor = true;
            this.btnRaAccelerationWriteUpdate.Click += new System.EventHandler(this.btnRaAccelerationWriteUpdate_Click);
            // 
            // btnRaAccelerationLoadUpdate
            // 
            this.btnRaAccelerationLoadUpdate.Location = new System.Drawing.Point(184, 57);
            this.btnRaAccelerationLoadUpdate.Name = "btnRaAccelerationLoadUpdate";
            this.btnRaAccelerationLoadUpdate.Size = new System.Drawing.Size(55, 23);
            this.btnRaAccelerationLoadUpdate.TabIndex = 7;
            this.btnRaAccelerationLoadUpdate.Text = "Load";
            this.btnRaAccelerationLoadUpdate.UseVisualStyleBackColor = true;
            this.btnRaAccelerationLoadUpdate.Click += new System.EventHandler(this.btnRaAccelerationLoadUpdate_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(122, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "x 10 mSec";
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Location = new System.Drawing.Point(6, 62);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(42, 13);
            this.lblUpdate.TabIndex = 5;
            this.lblUpdate.Text = "Update";
            // 
            // txtRaUpdatePeriod
            // 
            this.txtRaUpdatePeriod.Location = new System.Drawing.Point(74, 59);
            this.txtRaUpdatePeriod.Name = "txtRaUpdatePeriod";
            this.txtRaUpdatePeriod.Size = new System.Drawing.Size(42, 20);
            this.txtRaUpdatePeriod.TabIndex = 4;
            // 
            // btnRaWriteAccelaration
            // 
            this.btnRaWriteAccelaration.Location = new System.Drawing.Point(245, 28);
            this.btnRaWriteAccelaration.Name = "btnRaWriteAccelaration";
            this.btnRaWriteAccelaration.Size = new System.Drawing.Size(55, 23);
            this.btnRaWriteAccelaration.TabIndex = 3;
            this.btnRaWriteAccelaration.Text = "Write";
            this.btnRaWriteAccelaration.UseVisualStyleBackColor = true;
            this.btnRaWriteAccelaration.Click += new System.EventHandler(this.btnRaWriteAccelaration_Click);
            // 
            // btnRaLoadAcceleration
            // 
            this.btnRaLoadAcceleration.Location = new System.Drawing.Point(184, 28);
            this.btnRaLoadAcceleration.Name = "btnRaLoadAcceleration";
            this.btnRaLoadAcceleration.Size = new System.Drawing.Size(55, 23);
            this.btnRaLoadAcceleration.TabIndex = 2;
            this.btnRaLoadAcceleration.Text = "Load";
            this.btnRaLoadAcceleration.UseVisualStyleBackColor = true;
            this.btnRaLoadAcceleration.Click += new System.EventHandler(this.btnRaLoadAcceleration_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "x 0.01 Tracking / sec";
            // 
            // txtRaAccelaration
            // 
            this.txtRaAccelaration.Location = new System.Drawing.Point(10, 30);
            this.txtRaAccelaration.Name = "txtRaAccelaration";
            this.txtRaAccelaration.Size = new System.Drawing.Size(52, 20);
            this.txtRaAccelaration.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkRaFast);
            this.groupBox2.Controls.Add(this.chkRaTracking);
            this.groupBox2.Controls.Add(this.rdRaCtrlRight);
            this.groupBox2.Controls.Add(this.rdRaCtrlOff);
            this.groupBox2.Controls.Add(this.rdRaCtrlLeft);
            this.groupBox2.Location = new System.Drawing.Point(19, 509);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 60);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control";
            // 
            // chkRaFast
            // 
            this.chkRaFast.AutoSize = true;
            this.chkRaFast.Location = new System.Drawing.Point(146, 33);
            this.chkRaFast.Name = "chkRaFast";
            this.chkRaFast.Size = new System.Drawing.Size(46, 17);
            this.chkRaFast.TabIndex = 4;
            this.chkRaFast.Text = "Fast";
            this.chkRaFast.UseVisualStyleBackColor = true;
            this.chkRaFast.CheckedChanged += new System.EventHandler(this.chkRaFast_CheckedChanged);
            // 
            // chkRaTracking
            // 
            this.chkRaTracking.AutoSize = true;
            this.chkRaTracking.Location = new System.Drawing.Point(146, 10);
            this.chkRaTracking.Name = "chkRaTracking";
            this.chkRaTracking.Size = new System.Drawing.Size(68, 17);
            this.chkRaTracking.TabIndex = 3;
            this.chkRaTracking.Text = "Tracking";
            this.chkRaTracking.UseVisualStyleBackColor = true;
            this.chkRaTracking.CheckedChanged += new System.EventHandler(this.chkRaTracking_CheckedChanged);
            // 
            // rdRaCtrlRight
            // 
            this.rdRaCtrlRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdRaCtrlRight.AutoSize = true;
            this.rdRaCtrlRight.Location = new System.Drawing.Point(93, 20);
            this.rdRaCtrlRight.Name = "rdRaCtrlRight";
            this.rdRaCtrlRight.Size = new System.Drawing.Size(23, 23);
            this.rdRaCtrlRight.TabIndex = 2;
            this.rdRaCtrlRight.Text = ">";
            this.rdRaCtrlRight.UseVisualStyleBackColor = true;
            this.rdRaCtrlRight.CheckedChanged += new System.EventHandler(this.rdRaCtrlRight_CheckedChanged);
            // 
            // rdRaCtrlOff
            // 
            this.rdRaCtrlOff.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdRaCtrlOff.AutoSize = true;
            this.rdRaCtrlOff.Checked = true;
            this.rdRaCtrlOff.Location = new System.Drawing.Point(58, 20);
            this.rdRaCtrlOff.Name = "rdRaCtrlOff";
            this.rdRaCtrlOff.Size = new System.Drawing.Size(23, 23);
            this.rdRaCtrlOff.TabIndex = 1;
            this.rdRaCtrlOff.TabStop = true;
            this.rdRaCtrlOff.Text = "0";
            this.rdRaCtrlOff.UseVisualStyleBackColor = true;
            // 
            // rdRaCtrlLeft
            // 
            this.rdRaCtrlLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdRaCtrlLeft.AutoSize = true;
            this.rdRaCtrlLeft.Location = new System.Drawing.Point(19, 20);
            this.rdRaCtrlLeft.Name = "rdRaCtrlLeft";
            this.rdRaCtrlLeft.Size = new System.Drawing.Size(23, 23);
            this.rdRaCtrlLeft.TabIndex = 0;
            this.rdRaCtrlLeft.Text = "<";
            this.rdRaCtrlLeft.UseVisualStyleBackColor = true;
            this.rdRaCtrlLeft.CheckedChanged += new System.EventHandler(this.rdRaCtrlLeft_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.btnRaGotoStop);
            this.groupBox1.Controls.Add(this.btnRaGotoStart);
            this.groupBox1.Controls.Add(this.btnResetCurrPos);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtRaTargetPos);
            this.groupBox1.Controls.Add(this.txtRaCurrentPos);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(19, 328);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 112);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Position";
            // 
            // btnRaGotoStop
            // 
            this.btnRaGotoStop.Location = new System.Drawing.Point(166, 70);
            this.btnRaGotoStop.Name = "btnRaGotoStop";
            this.btnRaGotoStop.Size = new System.Drawing.Size(75, 23);
            this.btnRaGotoStop.TabIndex = 16;
            this.btnRaGotoStop.Text = "Abort";
            this.btnRaGotoStop.UseVisualStyleBackColor = true;
            this.btnRaGotoStop.Click += new System.EventHandler(this.btnRaGotoStop_Click);
            // 
            // btnRaGotoStart
            // 
            this.btnRaGotoStart.Location = new System.Drawing.Point(166, 41);
            this.btnRaGotoStart.Name = "btnRaGotoStart";
            this.btnRaGotoStart.Size = new System.Drawing.Size(75, 23);
            this.btnRaGotoStart.TabIndex = 15;
            this.btnRaGotoStart.Text = "Goto";
            this.btnRaGotoStart.UseVisualStyleBackColor = true;
            this.btnRaGotoStart.Click += new System.EventHandler(this.btnRaGotoStart_Click);
            // 
            // btnResetCurrPos
            // 
            this.btnResetCurrPos.Location = new System.Drawing.Point(166, 17);
            this.btnResetCurrPos.Name = "btnResetCurrPos";
            this.btnResetCurrPos.Size = new System.Drawing.Size(75, 23);
            this.btnResetCurrPos.TabIndex = 14;
            this.btnResetCurrPos.Text = "Reset";
            this.btnResetCurrPos.UseVisualStyleBackColor = true;
            this.btnResetCurrPos.Click += new System.EventHandler(this.btnResetCurrPos_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Target";
            // 
            // txtRaTargetPos
            // 
            this.txtRaTargetPos.Location = new System.Drawing.Point(60, 46);
            this.txtRaTargetPos.Name = "txtRaTargetPos";
            this.txtRaTargetPos.Size = new System.Drawing.Size(100, 20);
            this.txtRaTargetPos.TabIndex = 9;
            // 
            // txtRaCurrentPos
            // 
            this.txtRaCurrentPos.Location = new System.Drawing.Point(60, 17);
            this.txtRaCurrentPos.Name = "txtRaCurrentPos";
            this.txtRaCurrentPos.ReadOnly = true;
            this.txtRaCurrentPos.Size = new System.Drawing.Size(100, 20);
            this.txtRaCurrentPos.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Current";
            // 
            // grpRaMicroSteps
            // 
            this.grpRaMicroSteps.Controls.Add(this.btnRaMicroWrite);
            this.grpRaMicroSteps.Controls.Add(this.btnRaMicroLoad);
            this.grpRaMicroSteps.Controls.Add(this.rBtnRaMicro3);
            this.grpRaMicroSteps.Controls.Add(this.rBtnRaMicro2);
            this.grpRaMicroSteps.Controls.Add(this.rBtnRaMicro1);
            this.grpRaMicroSteps.Controls.Add(this.rBtnRaMicro0);
            this.grpRaMicroSteps.Enabled = false;
            this.grpRaMicroSteps.Location = new System.Drawing.Point(19, 102);
            this.grpRaMicroSteps.Name = "grpRaMicroSteps";
            this.grpRaMicroSteps.Size = new System.Drawing.Size(193, 79);
            this.grpRaMicroSteps.TabIndex = 3;
            this.grpRaMicroSteps.TabStop = false;
            this.grpRaMicroSteps.Text = "Microsteps";
            // 
            // btnRaMicroWrite
            // 
            this.btnRaMicroWrite.Location = new System.Drawing.Point(112, 43);
            this.btnRaMicroWrite.Name = "btnRaMicroWrite";
            this.btnRaMicroWrite.Size = new System.Drawing.Size(75, 23);
            this.btnRaMicroWrite.TabIndex = 5;
            this.btnRaMicroWrite.Text = "Write";
            this.btnRaMicroWrite.UseVisualStyleBackColor = true;
            // 
            // btnRaMicroLoad
            // 
            this.btnRaMicroLoad.Location = new System.Drawing.Point(112, 13);
            this.btnRaMicroLoad.Name = "btnRaMicroLoad";
            this.btnRaMicroLoad.Size = new System.Drawing.Size(75, 23);
            this.btnRaMicroLoad.TabIndex = 4;
            this.btnRaMicroLoad.Text = "Load";
            this.btnRaMicroLoad.UseVisualStyleBackColor = true;
            // 
            // rBtnRaMicro3
            // 
            this.rBtnRaMicro3.AutoSize = true;
            this.rBtnRaMicro3.Location = new System.Drawing.Point(55, 43);
            this.rBtnRaMicro3.Name = "rBtnRaMicro3";
            this.rBtnRaMicro3.Size = new System.Drawing.Size(48, 17);
            this.rBtnRaMicro3.TabIndex = 3;
            this.rBtnRaMicro3.TabStop = true;
            this.rBtnRaMicro3.Text = "1/16";
            this.rBtnRaMicro3.UseVisualStyleBackColor = true;
            // 
            // rBtnRaMicro2
            // 
            this.rBtnRaMicro2.AutoSize = true;
            this.rBtnRaMicro2.Location = new System.Drawing.Point(55, 19);
            this.rBtnRaMicro2.Name = "rBtnRaMicro2";
            this.rBtnRaMicro2.Size = new System.Drawing.Size(42, 17);
            this.rBtnRaMicro2.TabIndex = 2;
            this.rBtnRaMicro2.TabStop = true;
            this.rBtnRaMicro2.Text = "1/8";
            this.rBtnRaMicro2.UseVisualStyleBackColor = true;
            // 
            // rBtnRaMicro1
            // 
            this.rBtnRaMicro1.AutoSize = true;
            this.rBtnRaMicro1.Location = new System.Drawing.Point(7, 43);
            this.rBtnRaMicro1.Name = "rBtnRaMicro1";
            this.rBtnRaMicro1.Size = new System.Drawing.Size(42, 17);
            this.rBtnRaMicro1.TabIndex = 1;
            this.rBtnRaMicro1.Text = "1/4";
            this.rBtnRaMicro1.UseVisualStyleBackColor = true;
            // 
            // rBtnRaMicro0
            // 
            this.rBtnRaMicro0.AutoSize = true;
            this.rBtnRaMicro0.Checked = true;
            this.rBtnRaMicro0.Location = new System.Drawing.Point(7, 19);
            this.rBtnRaMicro0.Name = "rBtnRaMicro0";
            this.rBtnRaMicro0.Size = new System.Drawing.Size(42, 17);
            this.rBtnRaMicro0.TabIndex = 0;
            this.rBtnRaMicro0.TabStop = true;
            this.rBtnRaMicro0.Text = "1/2";
            this.rBtnRaMicro0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rBtnRaMicro0.UseVisualStyleBackColor = true;
            // 
            // tmrAutoUpdate
            // 
            this.tmrAutoUpdate.Tick += new System.EventHandler(this.tmrAutoUpdate_Tick);
            // 
            // grpSynch
            // 
            this.grpSynch.AutoSize = true;
            this.grpSynch.Controls.Add(this.btnSynchLoad);
            this.grpSynch.Enabled = false;
            this.grpSynch.Location = new System.Drawing.Point(251, 12);
            this.grpSynch.Name = "grpSynch";
            this.grpSynch.Size = new System.Drawing.Size(87, 97);
            this.grpSynch.TabIndex = 4;
            this.grpSynch.TabStop = false;
            this.grpSynch.Text = "Synchronize";
            // 
            // btnSynchLoad
            // 
            this.btnSynchLoad.Location = new System.Drawing.Point(6, 29);
            this.btnSynchLoad.Name = "btnSynchLoad";
            this.btnSynchLoad.Size = new System.Drawing.Size(75, 23);
            this.btnSynchLoad.TabIndex = 1;
            this.btnSynchLoad.Text = "Load";
            this.btnSynchLoad.UseVisualStyleBackColor = true;
            this.btnSynchLoad.Click += new System.EventHandler(this.btnSynchLoad_Click);
            // 
            // btnSynchWrite
            // 
            this.btnSynchWrite.Enabled = false;
            this.btnSynchWrite.Location = new System.Drawing.Point(257, 70);
            this.btnSynchWrite.Name = "btnSynchWrite";
            this.btnSynchWrite.Size = new System.Drawing.Size(75, 23);
            this.btnSynchWrite.TabIndex = 0;
            this.btnSynchWrite.Text = "Write";
            this.btnSynchWrite.UseVisualStyleBackColor = true;
            // 
            // backgroundSerial
            // 
            this.backgroundSerial.WorkerSupportsCancellation = true;
            this.backgroundSerial.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundSerial_DoWork);
            this.backgroundSerial.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundSerial_RunWorkerCompleted);
            // 
            // txtMissed
            // 
            this.txtMissed.Location = new System.Drawing.Point(192, 12);
            this.txtMissed.Name = "txtMissed";
            this.txtMissed.ReadOnly = true;
            this.txtMissed.Size = new System.Drawing.Size(53, 20);
            this.txtMissed.TabIndex = 5;
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(84, 21);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size(51, 20);
            this.txtVersion.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Controller";
            // 
            // btnGetVersion
            // 
            this.btnGetVersion.Location = new System.Drawing.Point(152, 19);
            this.btnGetVersion.Name = "btnGetVersion";
            this.btnGetVersion.Size = new System.Drawing.Size(75, 23);
            this.btnGetVersion.TabIndex = 8;
            this.btnGetVersion.Text = "Get";
            this.btnGetVersion.UseVisualStyleBackColor = true;
            this.btnGetVersion.Click += new System.EventHandler(this.btnGetVersion_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Program";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtMyVersion);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.btnGetVersion);
            this.groupBox3.Controls.Add(this.txtVersion);
            this.groupBox3.Location = new System.Drawing.Point(12, 38);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(233, 71);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Version Info";
            // 
            // txtMyVersion
            // 
            this.txtMyVersion.Location = new System.Drawing.Point(84, 45);
            this.txtMyVersion.Name = "txtMyVersion";
            this.txtMyVersion.ReadOnly = true;
            this.txtMyVersion.Size = new System.Drawing.Size(51, 20);
            this.txtMyVersion.TabIndex = 10;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Ports";
            this.bindingSource1.DataSource = typeof(TelescopeControl.Form1);
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(TelescopeControl.Form1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(402, 714);
            this.Controls.Add(this.txtMissed);
            this.Controls.Add(this.btnSynchWrite);
            this.Controls.Add(this.grpSynch);
            this.Controls.Add(this.groupRA);
            this.Controls.Add(this.butEditSerial);
            this.Controls.Add(this.comboPorts);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Telescope Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.fastSpeedBox.ResumeLayout(false);
            this.fastSpeedBox.PerformLayout();
            this.groupRA.ResumeLayout(false);
            this.groupRA.PerformLayout();
            this.grpBacklash.ResumeLayout(false);
            this.grpBacklash.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.grpRaAcceleration.ResumeLayout(false);
            this.grpRaAcceleration.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpRaMicroSteps.ResumeLayout(false);
            this.grpRaMicroSteps.PerformLayout();
            this.grpSynch.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.ComboBox comboPorts;
        private System.Windows.Forms.Button butEditSerial;
        private System.Windows.Forms.GroupBox fastSpeedBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFastSpeed;
        private System.Windows.Forms.Button btnWriteFastSpeed;
        private System.Windows.Forms.Button btnLoadFastSpeed;
        private System.Windows.Forms.GroupBox groupRA;
        private System.Windows.Forms.GroupBox grpRaMicroSteps;
        private System.Windows.Forms.RadioButton rBtnRaMicro2;
        private System.Windows.Forms.RadioButton rBtnRaMicro1;
        private System.Windows.Forms.RadioButton rBtnRaMicro0;
        private System.Windows.Forms.Button btnRaMicroWrite;
        private System.Windows.Forms.Button btnRaMicroLoad;
        private System.Windows.Forms.RadioButton rBtnRaMicro3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRaCurrentPos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRaTimerInterval;
        private System.Windows.Forms.CheckBox chkRaCurrentAuto;
        private System.Windows.Forms.Timer tmrAutoUpdate;
        private System.Windows.Forms.GroupBox grpSynch;
        private System.Windows.Forms.Button btnSynchLoad;
        private System.Windows.Forms.Button btnSynchWrite;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdRaCtrlRight;
        private System.Windows.Forms.RadioButton rdRaCtrlOff;
        private System.Windows.Forms.RadioButton rdRaCtrlLeft;
        private System.Windows.Forms.CheckBox chkRaFast;
        private System.Windows.Forms.CheckBox chkRaTracking;
        public System.ComponentModel.BackgroundWorker backgroundSerial;
        private System.Windows.Forms.GroupBox grpRaAcceleration;
        private System.Windows.Forms.Button btnRaWriteAccelaration;
        private System.Windows.Forms.Button btnRaLoadAcceleration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRaAccelaration;
        private System.Windows.Forms.Button btnRaPosLoad;
        private System.Windows.Forms.TextBox txtMissed;
        private System.Windows.Forms.TextBox txtCurrentRaSpeed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnGetVersion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtMyVersion;
        private System.Windows.Forms.TextBox txtRaUpdatePeriod;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Button btnRaAccelerationWriteUpdate;
        private System.Windows.Forms.Button btnRaAccelerationLoadUpdate;
        private System.Windows.Forms.Button btnRaAccLLWrite;
        private System.Windows.Forms.Button btnRaAccLLLoad;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRaAccLL;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRaTargetPos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnResetCurrPos;
        private System.Windows.Forms.GroupBox grpBacklash;
        private System.Windows.Forms.Button btnRaBacklashWrite;
        private System.Windows.Forms.Button btnRaBacklashLoad;
        private System.Windows.Forms.TextBox txtRaBacklash;
        private System.Windows.Forms.Button btnRaGotoStop;
        private System.Windows.Forms.Button btnRaGotoStart;
    }
}

