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
            this.angleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.minutesTextBox = new System.Windows.Forms.TextBox();
            this.secondsTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.angleBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // degreesTextBox
            // 
            this.degreesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.angleBindingSource, "Deg", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.degreesTextBox.Location = new System.Drawing.Point(35, 0);
            this.degreesTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.degreesTextBox.Name = "degreesTextBox";
            this.degreesTextBox.Size = new System.Drawing.Size(30, 20);
            this.degreesTextBox.TabIndex = 2;
            this.degreesTextBox.Text = "+270";
            this.degreesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // angleBindingSource
            // 
            this.angleBindingSource.DataSource = typeof(AAnet.Angle);
            // 
            // minutesTextBox
            // 
            this.minutesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.angleBindingSource, "Minutes", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "00"));
            this.minutesTextBox.Location = new System.Drawing.Point(65, 0);
            this.minutesTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.minutesTextBox.Name = "minutesTextBox";
            this.minutesTextBox.Size = new System.Drawing.Size(22, 20);
            this.minutesTextBox.TabIndex = 4;
            this.minutesTextBox.Text = "00";
            this.minutesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // secondsTextBox
            // 
            this.secondsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.angleBindingSource, "Seconds", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "00.00"));
            this.secondsTextBox.Location = new System.Drawing.Point(87, 0);
            this.secondsTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.secondsTextBox.Name = "secondsTextBox";
            this.secondsTextBox.Size = new System.Drawing.Size(49, 20);
            this.secondsTextBox.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.secondsTextBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.minutesTextBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.degreesTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblName, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(136, 20);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Margin = new System.Windows.Forms.Padding(0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "label1";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NewAngleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "NewAngleControl";
            this.Size = new System.Drawing.Size(136, 20);
            ((System.ComponentModel.ISupportInitialize)(this.angleBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource angleBindingSource;
        private System.Windows.Forms.TextBox degreesTextBox;
        private System.Windows.Forms.TextBox minutesTextBox;
        private System.Windows.Forms.TextBox secondsTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblName;
    }
}
