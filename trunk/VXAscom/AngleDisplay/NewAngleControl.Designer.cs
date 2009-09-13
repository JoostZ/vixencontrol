namespace AngleDisplay
{
    partial class NewAngleControl
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
            this.degreesTextBox = new System.Windows.Forms.TextBox();
            this.minutesTextBox = new System.Windows.Forms.TextBox();
            this.secondsTextBox = new System.Windows.Forms.TextBox();
            this.angleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.angleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // degreesTextBox
            // 
            this.degreesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.angleBindingSource, "Deg", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.degreesTextBox.Location = new System.Drawing.Point(0, 3);
            this.degreesTextBox.Name = "degreesTextBox";
            this.degreesTextBox.Size = new System.Drawing.Size(30, 20);
            this.degreesTextBox.TabIndex = 2;
            this.degreesTextBox.Text = "+270";
            this.degreesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // minutesTextBox
            // 
            this.minutesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.angleBindingSource, "Minutes", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "00"));
            this.minutesTextBox.Location = new System.Drawing.Point(36, 3);
            this.minutesTextBox.Name = "minutesTextBox";
            this.minutesTextBox.Size = new System.Drawing.Size(22, 20);
            this.minutesTextBox.TabIndex = 4;
            this.minutesTextBox.Text = "00";
            this.minutesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // secondsTextBox
            // 
            this.secondsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.angleBindingSource, "Seconds", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.secondsTextBox.Location = new System.Drawing.Point(64, 3);
            this.secondsTextBox.Name = "secondsTextBox";
            this.secondsTextBox.Size = new System.Drawing.Size(49, 20);
            this.secondsTextBox.TabIndex = 8;
            // 
            // angleBindingSource
            // 
            this.angleBindingSource.DataSource = typeof(AAnet.Angle);
            // 
            // NewAngleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.degreesTextBox);
            this.Controls.Add(this.minutesTextBox);
            this.Controls.Add(this.secondsTextBox);
            this.Name = "NewAngleControl";
            this.Size = new System.Drawing.Size(116, 26);
            ((System.ComponentModel.ISupportInitialize)(this.angleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource angleBindingSource;
        private System.Windows.Forms.TextBox degreesTextBox;
        private System.Windows.Forms.TextBox minutesTextBox;
        private System.Windows.Forms.TextBox secondsTextBox;
    }
}
