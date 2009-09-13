namespace ASCOM.VXAscom
{
    partial class SetupDialogForm
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
            System.Windows.Forms.Label testAngleLabel;
            System.Windows.Forms.Label degreesLabel;
            System.Windows.Forms.Label raAxisLabel;
            System.Windows.Forms.Label raAxisLabel1;
            System.Windows.Forms.Label raAxisLabel2;
            System.Windows.Forms.Label raAxisLabel3;
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.picASCOM = new System.Windows.Forms.PictureBox();
            this.tmrAutoUpdate = new System.Windows.Forms.Timer(this.components);
            this.tabRaAxis = new System.Windows.Forms.TabPage();
            this.raAxisAxisControlDisplay = new AxisControlDisplay();
            this.tabBasic = new System.Windows.Forms.TabPage();
            this.degreesTextBox = new System.Windows.Forms.TextBox();
            this.testAngleNewAngleControl = new AngleDisplay.NewAngleControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.comboBaudRate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboPorts = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlLon = new AngleDisplay.HemiAngleDisplay();
            this.txtLST = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.setupDialogFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.axisControlBindingSource = new System.Windows.Forms.BindingSource(this.components);
            testAngleLabel = new System.Windows.Forms.Label();
            degreesLabel = new System.Windows.Forms.Label();
            raAxisLabel = new System.Windows.Forms.Label();
            raAxisLabel1 = new System.Windows.Forms.Label();
            raAxisLabel2 = new System.Windows.Forms.Label();
            raAxisLabel3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).BeginInit();
            this.tabRaAxis.SuspendLayout();
            this.tabBasic.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setupDialogFormBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisControlBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // testAngleLabel
            // 
            testAngleLabel.AutoSize = true;
            testAngleLabel.Location = new System.Drawing.Point(208, 125);
            testAngleLabel.Name = "testAngleLabel";
            testAngleLabel.Size = new System.Drawing.Size(61, 13);
            testAngleLabel.TabIndex = 5;
            testAngleLabel.Text = "Test Angle:";
            // 
            // degreesLabel
            // 
            degreesLabel.AutoSize = true;
            degreesLabel.Location = new System.Drawing.Point(286, 212);
            degreesLabel.Name = "degreesLabel";
            degreesLabel.Size = new System.Drawing.Size(50, 13);
            degreesLabel.TabIndex = 6;
            degreesLabel.Text = "Degrees:";
            // 
            // raAxisLabel
            // 
            raAxisLabel.AutoSize = true;
            raAxisLabel.Location = new System.Drawing.Point(5, 7);
            raAxisLabel.Name = "raAxisLabel";
            raAxisLabel.Size = new System.Drawing.Size(46, 13);
            raAxisLabel.TabIndex = 0;
            raAxisLabel.Text = "Ra Axis:";
            // 
            // raAxisLabel1
            // 
            raAxisLabel1.AutoSize = true;
            raAxisLabel1.Location = new System.Drawing.Point(76, 7);
            raAxisLabel1.Name = "raAxisLabel1";
            raAxisLabel1.Size = new System.Drawing.Size(46, 13);
            raAxisLabel1.TabIndex = 1;
            raAxisLabel1.Text = "Ra Axis:";
            // 
            // raAxisLabel2
            // 
            raAxisLabel2.AutoSize = true;
            raAxisLabel2.Location = new System.Drawing.Point(74, 19);
            raAxisLabel2.Name = "raAxisLabel2";
            raAxisLabel2.Size = new System.Drawing.Size(46, 13);
            raAxisLabel2.TabIndex = 0;
            raAxisLabel2.Text = "Ra Axis:";
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(492, 95);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(59, 24);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(492, 125);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(59, 25);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // picASCOM
            // 
            this.picASCOM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picASCOM.Image = global::ASCOM.VXAscom.Properties.Resources.ASCOM;
            this.picASCOM.Location = new System.Drawing.Point(503, 12);
            this.picASCOM.Name = "picASCOM";
            this.picASCOM.Size = new System.Drawing.Size(48, 56);
            this.picASCOM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picASCOM.TabIndex = 3;
            this.picASCOM.TabStop = false;
            this.picASCOM.DoubleClick += new System.EventHandler(this.BrowseToAscom);
            this.picASCOM.Click += new System.EventHandler(this.BrowseToAscom);
            // 
            // tmrAutoUpdate
            // 
            this.tmrAutoUpdate.Tick += new System.EventHandler(this.tmrAutoUpdate_Tick);
            // 
            // tabRaAxis
            // 
            this.tabRaAxis.AutoScroll = true;
            this.tabRaAxis.Controls.Add(raAxisLabel3);
            this.tabRaAxis.Controls.Add(this.raAxisAxisControlDisplay);
            this.tabRaAxis.Location = new System.Drawing.Point(4, 22);
            this.tabRaAxis.Name = "tabRaAxis";
            this.tabRaAxis.Padding = new System.Windows.Forms.Padding(3);
            this.tabRaAxis.Size = new System.Drawing.Size(475, 310);
            this.tabRaAxis.TabIndex = 1;
            this.tabRaAxis.Text = "RA Axis";
            this.tabRaAxis.UseVisualStyleBackColor = true;
            // 
            // tabBasic
            // 
            this.tabBasic.AutoScroll = true;
            this.tabBasic.Controls.Add(degreesLabel);
            this.tabBasic.Controls.Add(this.degreesTextBox);
            this.tabBasic.Controls.Add(testAngleLabel);
            this.tabBasic.Controls.Add(this.testAngleNewAngleControl);
            this.tabBasic.Controls.Add(this.groupBox1);
            this.tabBasic.Controls.Add(this.panel1);
            this.tabBasic.Location = new System.Drawing.Point(4, 22);
            this.tabBasic.Name = "tabBasic";
            this.tabBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabBasic.Size = new System.Drawing.Size(475, 310);
            this.tabBasic.TabIndex = 0;
            this.tabBasic.Text = "Basic";
            this.tabBasic.UseVisualStyleBackColor = true;
            // 
            // degreesTextBox
            // 
            this.degreesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.setupDialogFormBindingSource, "TestAngle.Degrees", true));
            this.degreesTextBox.Location = new System.Drawing.Point(342, 209);
            this.degreesTextBox.Name = "degreesTextBox";
            this.degreesTextBox.Size = new System.Drawing.Size(100, 20);
            this.degreesTextBox.TabIndex = 7;
            // 
            // testAngleNewAngleControl
            // 
            this.testAngleNewAngleControl.AutoSize = true;
            this.testAngleNewAngleControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.testAngleNewAngleControl.DataBindings.Add(new System.Windows.Forms.Binding("Angle", this.setupDialogFormBindingSource, "TestAngle", true));
            this.testAngleNewAngleControl.Location = new System.Drawing.Point(275, 125);
            this.testAngleNewAngleControl.Name = "testAngleNewAngleControl";
            this.testAngleNewAngleControl.Size = new System.Drawing.Size(116, 26);
            this.testAngleNewAngleControl.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.comboBaudRate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboPorts);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(205, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 113);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Connection";
            // 
            // btnConnect
            // 
            this.btnConnect.Enabled = false;
            this.btnConnect.Location = new System.Drawing.Point(17, 75);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // comboBaudRate
            // 
            this.comboBaudRate.FormattingEnabled = true;
            this.comboBaudRate.Location = new System.Drawing.Point(70, 41);
            this.comboBaudRate.Name = "comboBaudRate";
            this.comboBaudRate.Size = new System.Drawing.Size(77, 21);
            this.comboBaudRate.TabIndex = 3;
            this.comboBaudRate.SelectedIndexChanged += new System.EventHandler(this.comboBaudRate_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Baud Rate";
            // 
            // comboPorts
            // 
            this.comboPorts.FormattingEnabled = true;
            this.comboPorts.Location = new System.Drawing.Point(54, 14);
            this.comboPorts.Name = "comboPorts";
            this.comboPorts.Size = new System.Drawing.Size(93, 21);
            this.comboPorts.TabIndex = 0;
            this.comboPorts.SelectedIndexChanged += new System.EventHandler(this.comboPorts_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.ctrlLon);
            this.panel1.Controls.Add(this.txtLST);
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 218);
            this.panel1.TabIndex = 4;
            // 
            // ctrlLon
            // 
            this.ctrlLon.AutoSize = true;
            this.ctrlLon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlLon.ForeColor = System.Drawing.Color.Red;
            this.ctrlLon.Label = "Lon";
            this.ctrlLon.Location = new System.Drawing.Point(3, 37);
            this.ctrlLon.Name = "ctrlLon";
            this.ctrlLon.Size = new System.Drawing.Size(182, 26);
            this.ctrlLon.TabIndex = 2;
            this.ctrlLon.Value = 0;
            // 
            // txtLST
            // 
            this.txtLST.Location = new System.Drawing.Point(36, 11);
            this.txtLST.Name = "txtLST";
            this.txtLST.Size = new System.Drawing.Size(51, 20);
            this.txtLST.TabIndex = 1;
            this.txtLST.Text = "07:21:12";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "LST";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBasic);
            this.tabControl1.Controls.Add(this.tabRaAxis);
            this.tabControl1.Location = new System.Drawing.Point(3, 9);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(483, 336);
            this.tabControl1.TabIndex = 5;
            // 
            // setupDialogFormBindingSource
            // 
            this.setupDialogFormBindingSource.DataSource = typeof(ASCOM.VXAscom.SetupDialogForm);
            // 
            // axisControlBindingSource
            // 
            this.axisControlBindingSource.DataSource = typeof(ASCOM.VXAscom.Axis.AxisControl);
            // 
            // raAxisLabel3
            // 
            raAxisLabel3.AutoSize = true;
            raAxisLabel3.Location = new System.Drawing.Point(8, 9);
            raAxisLabel3.Name = "raAxisLabel3";
            raAxisLabel3.Size = new System.Drawing.Size(46, 13);
            raAxisLabel3.TabIndex = 0;
            raAxisLabel3.Text = "Ra Axis:";
            // 
            // raAxisAxisControlDisplay
            // 
            this.raAxisAxisControlDisplay.AutoScroll = true;
            this.raAxisAxisControlDisplay.AutoSize = true;
            this.raAxisAxisControlDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.raAxisAxisControlDisplay.Axis = null;
            this.raAxisAxisControlDisplay.DataBindings.Add(new System.Windows.Forms.Binding("Axis", this.setupDialogFormBindingSource, "RaAxis", true));
            this.raAxisAxisControlDisplay.Location = new System.Drawing.Point(60, 9);
            this.raAxisAxisControlDisplay.Name = "raAxisAxisControlDisplay";
            this.raAxisAxisControlDisplay.Size = new System.Drawing.Size(237, 287);
            this.raAxisAxisControlDisplay.TabIndex = 1;
            // 
            // SetupDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 345);
            this.Controls.Add(this.picASCOM);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupDialogForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VXAscom Setup";
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).EndInit();
            this.tabRaAxis.ResumeLayout(false);
            this.tabRaAxis.PerformLayout();
            this.tabBasic.ResumeLayout(false);
            this.tabBasic.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.setupDialogFormBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisControlBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.PictureBox picASCOM;
        private System.Windows.Forms.Timer tmrAutoUpdate;
        private System.Windows.Forms.BindingSource axisControlBindingSource;
        private System.Windows.Forms.BindingSource setupDialogFormBindingSource;
        private System.Windows.Forms.TabPage tabRaAxis;
        private System.Windows.Forms.TabPage tabBasic;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox comboBaudRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboPorts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private AngleDisplay.HemiAngleDisplay ctrlLon;
        private System.Windows.Forms.TextBox txtLST;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private AngleDisplay.NewAngleControl testAngleNewAngleControl;
        private System.Windows.Forms.TextBox degreesTextBox;
        private AxisControlDisplay raAxisAxisControlDisplay;
    }
}