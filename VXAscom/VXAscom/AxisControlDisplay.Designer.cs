namespace ASCOM.VXAscom
{
    using Axis;

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
            System.Windows.Forms.Label accUpdateLabel;
            System.Windows.Forms.Label accLimitLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.accLimitTextBox = new System.Windows.Forms.TextBox();
            this.axisControlDisplayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.accUpdateTextBox = new System.Windows.Forms.TextBox();
            this.accelerationTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            accelerationLabel = new System.Windows.Forms.Label();
            accUpdateLabel = new System.Windows.Forms.Label();
            accLimitLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axisControlDisplayBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // accelerationLabel
            // 
            accelerationLabel.AutoSize = true;
            accelerationLabel.Location = new System.Drawing.Point(7, 25);
            accelerationLabel.Name = "accelerationLabel";
            accelerationLabel.Size = new System.Drawing.Size(69, 13);
            accelerationLabel.TabIndex = 2;
            accelerationLabel.Text = "Acceleration:";
            // 
            // accUpdateLabel
            // 
            accUpdateLabel.AutoSize = true;
            accUpdateLabel.Location = new System.Drawing.Point(7, 51);
            accUpdateLabel.Name = "accUpdateLabel";
            accUpdateLabel.Size = new System.Drawing.Size(69, 13);
            accUpdateLabel.TabIndex = 3;
            accUpdateLabel.Text = "Update Freq:";
            // 
            // accLimitLabel
            // 
            accLimitLabel.AutoSize = true;
            accLimitLabel.Location = new System.Drawing.Point(11, 77);
            accLimitLabel.Name = "accLimitLabel";
            accLimitLabel.Size = new System.Drawing.Size(63, 13);
            accLimitLabel.TabIndex = 6;
            accLimitLabel.Text = "Lower Limit:";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(accLimitLabel);
            this.groupBox1.Controls.Add(this.accLimitTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(accUpdateLabel);
            this.groupBox1.Controls.Add(this.accUpdateTextBox);
            this.groupBox1.Controls.Add(accelerationLabel);
            this.groupBox1.Controls.Add(this.accelerationTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acceleration";
            // 
            // accLimitTextBox
            // 
            this.accLimitTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.axisControlDisplayBindingSource, "Axis.AccLimit", true));
            this.accLimitTextBox.Location = new System.Drawing.Point(80, 74);
            this.accLimitTextBox.Name = "accLimitTextBox";
            this.accLimitTextBox.Size = new System.Drawing.Size(40, 20);
            this.accLimitTextBox.TabIndex = 7;
            // 
            // axisControlDisplayBindingSource
            // 
            this.axisControlDisplayBindingSource.DataSource = typeof(ASCOM.VXAscom.AxisControlDisplay);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "msec";
            // 
            // accUpdateTextBox
            // 
            this.accUpdateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.axisControlDisplayBindingSource, "Axis.AccUpdate", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N1"));
            this.accUpdateTextBox.Location = new System.Drawing.Point(80, 48);
            this.accUpdateTextBox.Name = "accUpdateTextBox";
            this.accUpdateTextBox.Size = new System.Drawing.Size(40, 20);
            this.accUpdateTextBox.TabIndex = 4;
            // 
            // accelerationTextBox
            // 
            this.accelerationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.axisControlDisplayBindingSource, "Axis.Acceleration", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.accelerationTextBox.Location = new System.Drawing.Point(80, 22);
            this.accelerationTextBox.Name = "accelerationTextBox";
            this.accelerationTextBox.Size = new System.Drawing.Size(40, 20);
            this.accelerationTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "x tracking/s";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "x tracking";
            // 
            // AxisControlDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "AxisControlDisplay";
            this.Size = new System.Drawing.Size(561, 234);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axisControlDisplayBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox accelerationTextBox;
        private System.Windows.Forms.BindingSource axisControlDisplayBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox accUpdateTextBox;
        private System.Windows.Forms.TextBox accLimitTextBox;
        private System.Windows.Forms.Label label3;
    }
}
