using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AngleDisplay
{
    [DefaultBindingProperty("Angle")]
    public partial class NewAngleControl : UserControl
    {
        public NewAngleControl()
        {
            InitializeComponent();
            angleBindingSource.DataSource = this.Angle;
        }

        AAnet.Angle _angle;
        public AAnet.Angle Angle
        {
            get
            {
                return _angle;
            }
            set
            {
                _angle = value;
                angleBindingSource.DataSource = this.Angle;
            }
        }

        [
        Category("Appearance"),
        Description("The label shown at the left of the control")
        ]
        public String Label
        {
            get
            {
                return lblName.Text;
            }
            set
            {
                lblName.Text
                    = value;
            }
        }
    }
}
