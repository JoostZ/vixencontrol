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
    public partial class AxisControlDisplay : UserControl
    {
        internal AxisControlDisplay()
        {
            InitializeComponent();

            axisControlDisplayBindingSource.DataSource = this;
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
                    //.DataBindings.Add("Text", _axis, "Acceleration");
                }
            }
        }

    }
}
