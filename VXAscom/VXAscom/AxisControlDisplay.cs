using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ASCOM.VXAscom
{
    //using Axis;

    [DefaultBindingProperty("Axis")]
    public partial class AxisControlDisplay : UserControl
    {
        public AxisControlDisplay()
        {
            InitializeComponent();
        }

        Axis.AxisControl _axis;
        public Axis.AxisControl Axis
        {
            get
            {
                return _axis;
            }
            set
            {
                _axis = value;
                if (value != null && !this.DesignMode)
                {
                    axisControlDisplayBindingSource.DataSource = this;
                }
            }
        }
    }
}
