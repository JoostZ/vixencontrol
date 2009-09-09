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
    public partial class HemiAngleDisplay : UserControl
    {
        public HemiAngleDisplay()
        {
            InitializeComponent();
            angleDisplay.DataBindings.Add("Value", this, "Value");
        }

        [
        Category("Data"),
        Description("Value shown in the control")
        ]
        public double Value
        {
            get
            {
                return angleDisplay.Value;
            }
            set
            {
                angleDisplay.Value = value;
            }
        }
        [
        Category("Appearance"),
        Description("Name of the Angle")
        ]
        public String Label {
            get { return angleDisplay.Label; }
            set { angleDisplay.Label = value; }
        }
    }
}
