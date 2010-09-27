namespace TestVxAscomGui
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
            System.Windows.Forms.Label raStringLabel;
            System.Windows.Forms.Label lSTStringLabel;
            System.Windows.Forms.Label raMoveRateLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnSetup = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tmrAutoUpdate = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.naCtrlRA = new AngleDisplay.NewAngleControl();
            this.trackingCheckBox = new System.Windows.Forms.CheckBox();
            this.lSTStringTextBox = new System.Windows.Forms.TextBox();
            this.raStringTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkMoveRa = new System.Windows.Forms.CheckBox();
            this.raMoveRateTextBox = new System.Windows.Forms.TextBox();
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            raStringLabel = new System.Windows.Forms.Label();
            lSTStringLabel = new System.Windows.Forms.Label();
            raMoveRateLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // raStringLabel
            // 
            raStringLabel.AutoSize = true;
            raStringLabel.Location = new System.Drawing.Point(3, 46);
            raStringLabel.Name = "raStringLabel";
            raStringLabel.Size = new System.Drawing.Size(22, 13);
            raStringLabel.TabIndex = 0;
            raStringLabel.Text = "RA";
            // 
            // lSTStringLabel
            // 
            lSTStringLabel.AutoSize = true;
            lSTStringLabel.Location = new System.Drawing.Point(0, 20);
            lSTStringLabel.Name = "lSTStringLabel";
            lSTStringLabel.Size = new System.Drawing.Size(27, 13);
            lSTStringLabel.TabIndex = 2;
            lSTStringLabel.Text = "LST";
            // 
            // raMoveRateLabel
            // 
            raMoveRateLabel.AutoSize = true;
            raMoveRateLabel.Location = new System.Drawing.Point(5, 22);
            raMoveRateLabel.Name = "raMoveRateLabel";
            raMoveRateLabel.Size = new System.Drawing.Size(22, 13);
            raMoveRateLabel.TabIndex = 0;
            raMoveRateLabel.Text = "RA";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.btnSetup);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(111, 54);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnSetup
            // 
            this.btnSetup.Location = new System.Drawing.Point(21, 55);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(75, 23);
            this.btnSetup.TabIndex = 4;
            this.btnSetup.Text = "Setup";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(81, 19);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(196, 20);
            this.nameTextBox.TabIndex = 3;
            this.nameTextBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Telescope";
            // 
            // tmrAutoUpdate
            // 
            this.tmrAutoUpdate.Interval = 1000;
            this.tmrAutoUpdate.Tick += new System.EventHandler(this.tmrAutoUpdate_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.naCtrlRA);
            this.groupBox2.Controls.Add(this.trackingCheckBox);
            this.groupBox2.Controls.Add(lSTStringLabel);
            this.groupBox2.Controls.Add(this.lSTStringTextBox);
            this.groupBox2.Controls.Add(raStringLabel);
            this.groupBox2.Controls.Add(this.raStringTextBox);
            this.groupBox2.Location = new System.Drawing.Point(3, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 111);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Position";
            // 
            // naCtrlRA
            // 
            this.naCtrlRA.AutoSize = true;
            this.naCtrlRA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.naCtrlRA.DataBindings.Add(new System.Windows.Forms.Binding("Angle", this.form1BindingSource, "RA", true));
            this.naCtrlRA.Label = "RA";
            this.naCtrlRA.Location = new System.Drawing.Point(6, 78);
            this.naCtrlRA.Margin = new System.Windows.Forms.Padding(0);
            this.naCtrlRA.Name = "naCtrlRA";
            this.naCtrlRA.Size = new System.Drawing.Size(123, 20);
            this.naCtrlRA.TabIndex = 6;
            // 
            // trackingCheckBox
            // 
            this.trackingCheckBox.AutoSize = true;
            this.trackingCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.form1BindingSource, "Tracking", true));
            this.trackingCheckBox.Location = new System.Drawing.Point(150, 45);
            this.trackingCheckBox.Name = "trackingCheckBox";
            this.trackingCheckBox.Size = new System.Drawing.Size(68, 17);
            this.trackingCheckBox.TabIndex = 5;
            this.trackingCheckBox.Text = "Tracking";
            this.trackingCheckBox.UseVisualStyleBackColor = true;
            this.trackingCheckBox.CheckedChanged += new System.EventHandler(this.trackingCheckBox_CheckedChanged);
            // 
            // lSTStringTextBox
            // 
            this.lSTStringTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.form1BindingSource, "LstString", true));
            this.lSTStringTextBox.Location = new System.Drawing.Point(31, 17);
            this.lSTStringTextBox.Name = "lSTStringTextBox";
            this.lSTStringTextBox.ReadOnly = true;
            this.lSTStringTextBox.Size = new System.Drawing.Size(100, 20);
            this.lSTStringTextBox.TabIndex = 3;
            // 
            // raStringTextBox
            // 
            this.raStringTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.form1BindingSource, "RaString", true));
            this.raStringTextBox.Location = new System.Drawing.Point(31, 43);
            this.raStringTextBox.Name = "raStringTextBox";
            this.raStringTextBox.ReadOnly = true;
            this.raStringTextBox.Size = new System.Drawing.Size(100, 20);
            this.raStringTextBox.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkMoveRa);
            this.groupBox3.Controls.Add(raMoveRateLabel);
            this.groupBox3.Controls.Add(this.raMoveRateTextBox);
            this.groupBox3.Location = new System.Drawing.Point(3, 249);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(220, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MoveAxis";
            // 
            // chkMoveRa
            // 
            this.chkMoveRa.AutoSize = true;
            this.chkMoveRa.Location = new System.Drawing.Point(126, 21);
            this.chkMoveRa.Name = "chkMoveRa";
            this.chkMoveRa.Size = new System.Drawing.Size(61, 17);
            this.chkMoveRa.TabIndex = 2;
            this.chkMoveRa.Text = "Moving";
            this.chkMoveRa.UseVisualStyleBackColor = true;
            this.chkMoveRa.CheckedChanged += new System.EventHandler(this.chkMoveRa_CheckedChanged);
            // 
            // raMoveRateTextBox
            // 
            this.raMoveRateTextBox.Location = new System.Drawing.Point(33, 19);
            this.raMoveRateTextBox.Name = "raMoveRateTextBox";
            this.raMoveRateTextBox.Size = new System.Drawing.Size(87, 20);
            this.raMoveRateTextBox.TabIndex = 1;
            this.raMoveRateTextBox.Text = "15.3";
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(TestVxAscomGui.DriverData);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 408);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Test VXAscom";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.Timer tmrAutoUpdate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox raStringTextBox;
        private System.Windows.Forms.TextBox lSTStringTextBox;
        private System.Windows.Forms.CheckBox trackingCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox raMoveRateTextBox;
        private System.Windows.Forms.CheckBox chkMoveRa;
        private System.Windows.Forms.Button btnSelect;
        private AngleDisplay.NewAngleControl naCtrlRA;
    }
}

