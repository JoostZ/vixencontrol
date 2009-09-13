using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ASCOM.VXAscom
{
    using Axis;

    [DefaultBindingProperty("Axis")]
    public partial class AxisControlDisplay : UserControl
    {
        internal AxisControlDisplay()
        {
            InitializeComponent();
            //axisControlBindingSource.DataSource = this.Axis;
        }

        AxisControl _axis;
        public AxisControl Axis
        {
            get
            {
                return _axis;
            }
            set
            {
                _axis = value;
                if (value != null)
                {
                    axisControlBindingSource.DataSource = this.Axis;
                }
            }
        }

    }
}
