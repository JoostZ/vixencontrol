namespace AngleDisplay
{
    public partial class AngleDisplay
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtIntPart = new System.Windows.Forms.TextBox();
            this.angleDisplayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtMinutePart = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSecondPart = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angleDisplayBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtIntPart, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMinutePart, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSecondPart, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 6, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(155, 20);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(0, 3);
            this.lblName.Margin = new System.Windows.Forms.Padding(0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "label1";
            // 
            // txtIntPart
            // 
            this.txtIntPart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtIntPart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIntPart.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.angleDisplayBindingSource, "IntPart", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.txtIntPart.Location = new System.Drawing.Point(35, 0);
            this.txtIntPart.Margin = new System.Windows.Forms.Padding(0);
            this.txtIntPart.Name = "txtIntPart";
            this.txtIntPart.Size = new System.Drawing.Size(25, 20);
            this.txtIntPart.TabIndex = 1;
            this.txtIntPart.Text = "000";
            // 
            // angleDisplayBindingSource
            // 
            this.angleDisplayBindingSource.DataSource = typeof(AngleDisplay);
            this.angleDisplayBindingSource.Position = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "h";
            // 
            // txtMinutePart
            // 
            this.txtMinutePart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtMinutePart.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.angleDisplayBindingSource, "MinutePart", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "00"));
            this.txtMinutePart.Location = new System.Drawing.Point(73, 0);
            this.txtMinutePart.Margin = new System.Windows.Forms.Padding(0);
            this.txtMinutePart.Name = "txtMinutePart";
            this.txtMinutePart.Size = new System.Drawing.Size(21, 20);
            this.txtMinutePart.TabIndex = 3;
            this.txtMinutePart.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(9, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "\'";
            // 
            // txtSecondPart
            // 
            this.txtSecondPart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSecondPart.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.angleDisplayBindingSource, "SecondPart", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N3"));
            this.txtSecondPart.Location = new System.Drawing.Point(103, 0);
            this.txtSecondPart.Margin = new System.Windows.Forms.Padding(0);
            this.txtSecondPart.Name = "txtSecondPart";
            this.txtSecondPart.Size = new System.Drawing.Size(41, 20);
            this.txtSecondPart.TabIndex = 5;
            this.txtSecondPart.Text = "00.000";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "\'\'";
            // 
            // AngleDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AngleDisplay";
            this.Size = new System.Drawing.Size(158, 23);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angleDisplayBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtIntPart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMinutePart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSecondPart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource angleDisplayBindingSource;
    }
}
