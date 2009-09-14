namespace ASCOM.VXAscom
{
    partial class AxisControlDisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label accelerationLabel;
            System.Windows.Forms.Label accLimitLabel;
            System.Windows.Forms.Label accUpdateLabel;
            System.Windows.Forms.Label angleLabel;
            System.Windows.Forms.Label backlashLabel;
            System.Windows.Forms.Label isTrackingLabel;
            System.Windows.Forms.Label trackingRateLabel;
            this.axisControlDisplayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accelerationTextBox = new System.Windows.Forms.TextBox();
            this.accLimitTextBox = new System.Windows.Forms.TextBox();
            this.accUpdateTextBox = new System.Windows.Forms.TextBox();
            this.angleNewAngleControl = new AngleDisplay.NewAngleControl();
            this.backlashTextBox = new System.Windows.Forms.TextBox();
            this.isTrackingCheckBox = new System.Windows.Forms.CheckBox();
            this.trackingRateTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            accelerationLabel = new System.Windows.Forms.Label();
            accLimitLabel = new System.Windows.Forms.Label();
            accUpdateLabel = new System.Windows.Forms.Label();
            angleLabel = new System.Windows.Forms.Label();
            backlashLabel = new System.Windows.Forms.Label();
            isTrackingLabel = new System.Windows.Forms.Label();
            trackingRateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axisControlDisplayBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // accelerationLabel
            // 
            accelerationLabel.AutoSize = true;
            accelerationLabel.Location = new System.Drawing.Point(6, 22);
            accelerationLabel.Name = "accelerationLabel";
            accelerationLabel.Size = new System.Drawing.Size(69, 13);
            accelerationLabel.TabIndex = 1;
            accelerationLabel.Text = "Acceleration:";
            // 
            // accLimitLabel
            // 
            accLimitLabel.AutoSize = true;
            accLimitLabel.Location = new System.Drawing.Point(6, 48);
            accLimitLabel.Name = "accLimitLabel";
            accLimitLabel.Size = new System.Drawing.Size(53, 13);
            accLimitLabel.TabIndex = 3;
            accLimitLabel.Text = "Acc Limit:";
            // 
            // accUpdateLabel
            // 
            accUpdateLabel.AutoSize = true;
            accUpdateLabel.Location = new System.Drawing.Point(6, 74);
            accUpdateLabel.Name = "accUpdateLabel";
            accUpdateLabel.Size = new System.Drawing.Size(67, 13);
            accUpdateLabel.TabIndex = 5;
            accUpdateLabel.Text = "Acc Update:";
            // 
            // angleLabel
            // 
            angleLabel.AutoSize = true;
            angleLabel.Location = new System.Drawing.Point(28, 122);
            angleLabel.Name = "angleLabel";
            angleLabel.Size = new System.Drawing.Size(37, 13);
            angleLabel.TabIndex = 7;
            angleLabel.Text = "Angle:";
            // 
            // backlashLabel
            // 
            backlashLabel.AutoSize = true;
            backlashLabel.Location = new System.Drawing.Point(28, 157);
            backlashLabel.Name = "backlashLabel";
            backlashLabel.Size = new System.Drawing.Size(54, 13);
            backlashLabel.TabIndex = 11;
            backlashLabel.Text = "Backlash:";
            // 
            // isTrackingLabel
            // 
            isTrackingLabel.AutoSize = true;
            isTrackingLabel.Location = new System.Drawing.Point(28, 185);
            isTrackingLabel.Name = "isTrackingLabel";
            isTrackingLabel.Size = new System.Drawing.Size(63, 13);
            isTrackingLabel.TabIndex = 13;
            isTrackingLabel.Text = "Is Tracking:";
            // 
            // trackingRateLabel
            // 
            trackingRateLabel.AutoSize = true;
            trackingRateLabel.Location = new System.Drawing.Point(28, 213);
            trackingRateLabel.Name = "trackingRateLabel";
            trackingRateLabel.Size = new System.Drawing.Size(78, 13);
            trackingRateLabel.TabIndex = 15;
            trackingRateLabel.Text = "Tracking Rate:";
            // 
            // axisControlDisplayBindingSource
            // 
            this.axisControlDisplayBindingSource.DataSource = typeof(ASCOM.VXAscom.AxisControlDisplay);
            // 
            // accelerationTextBox
            // 
            this.accelerationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.axisControlDisplayBindingSource, "Axis.Acceleration", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.accelerationTextBox.Location = new System.Drawing.Point(90, 19);
            this.accelerationTextBox.Name = "accelerationTextBox";
            this.accelerationTextBox.Size = new System.Drawing.Size(55, 20);
            this.accelerationTextBox.TabIndex = 2;
            // 
            // accLimitTextBox
            // 
            this.accLimitTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.axisControlDisplayBindingSource, "Axis.AccLimit", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.accLimitTextBox.Location = new System.Drawing.Point(90, 45);
            this.accLimitTextBox.Name = "accLimitTextBox";
            this.accLimitTextBox.Size = new System.Drawing.Size(55, 20);
            this.accLimitTextBox.TabIndex = 4;
            // 
            // accUpdateTextBox
            // 
            this.accUpdateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.axisControlDisplayBindingSource, "Axis.AccUpdate", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N1"));
            this.accUpdateTextBox.Location = new System.Drawing.Point(90, 71);
            this.accUpdateTextBox.Name = "accUpdateTextBox";
            this.accUpdateTextBox.Size = new System.Drawing.Size(55, 20);
            this.accUpdateTextBox.TabIndex = 6;
            // 
            // angleNewAngleControl
            // 
            this.angleNewAngleControl.AutoSize = true;
            this.angleNewAngleControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.angleNewAngleControl.DataBindings.Add(new System.Windows.Forms.Binding("Angle", this.axisControlDisplayBindingSource, "Axis.Angle", true));
            this.angleNewAngleControl.Location = new System.Drawing.Point(112, 122);
            this.angleNewAngleControl.Name = "angleNewAngleControl";
            this.angleNewAngleControl.Size = new System.Drawing.Size(116, 26);
            this.angleNewAngleControl.TabIndex = 8;
            // 
            // backlashTextBox
            // 
            this.backlashTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.axisControlDisplayBindingSource, "Axis.Backlash", true));
            this.backlashTextBox.Location = new System.Drawing.Point(112, 154);
            this.backlashTextBox.Name = "backlashTextBox";
            this.backlashTextBox.Size = new System.Drawing.Size(116, 20);
            this.backlashTextBox.TabIndex = 12;
            // 
            // isTrackingCheckBox
            // 
            this.isTrackingCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.axisControlDisplayBindingSource, "Axis.IsTracking", true));
            this.isTrackingCheckBox.Location = new System.Drawing.Point(112, 180);
            this.isTrackingCheckBox.Name = "isTrackingCheckBox";
            this.isTrackingCheckBox.Size = new System.Drawing.Size(116, 24);
            this.isTrackingCheckBox.TabIndex = 14;
            this.isTrackingCheckBox.Text = "checkBox1";
            this.isTrackingCheckBox.UseVisualStyleBackColor = true;
            // 
            // trackingRateTextBox
            // 
            this.trackingRateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.axisControlDisplayBindingSource, "Axis.TrackingRate", true));
            this.trackingRateTextBox.Location = new System.Drawing.Point(112, 210);
            this.trackingRateTextBox.Name = "trackingRateTextBox";
            this.trackingRateTextBox.Size = new System.Drawing.Size(116, 20);
            this.trackingRateTextBox.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(accelerationLabel);
            this.groupBox1.Controls.Add(this.accUpdateTextBox);
            this.groupBox1.Controls.Add(this.accelerationTextBox);
            this.groupBox1.Controls.Add(accUpdateLabel);
            this.groupBox1.Controls.Add(accLimitLabel);
            this.groupBox1.Controls.Add(this.accLimitTextBox);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 110);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acceleration";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tracking/sec";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tracking";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "msec";
            // 
            // AxisControlDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(angleLabel);
            this.Controls.Add(this.angleNewAngleControl);
            this.Controls.Add(backlashLabel);
            this.Controls.Add(this.backlashTextBox);
            this.Controls.Add(isTrackingLabel);
            this.Controls.Add(this.isTrackingCheckBox);
            this.Controls.Add(trackingRateLabel);
            this.Controls.Add(this.trackingRateTextBox);
            this.Name = "AxisControlDisplay";
            this.Size = new System.Drawing.Size(237, 233);
            ((System.ComponentModel.ISupportInitialize)(this.axisControlDisplayBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource axisControlDisplayBindingSource;
        private System.Windows.Forms.TextBox accelerationTextBox;
        private System.Windows.Forms.TextBox accLimitTextBox;
        private System.Windows.Forms.TextBox accUpdateTextBox;
        private AngleDisplay.NewAngleControl angleNewAngleControl;
        private System.Windows.Forms.TextBox backlashTextBox;
        private System.Windows.Forms.CheckBox isTrackingCheckBox;
        private System.Windows.Forms.TextBox trackingRateTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;

    }
}
