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
    public partial class AngleDisplay : UserControl
    {
        public AngleDisplay()
        {
            InitializeComponent();

            lblName.DataBindings.Add("Text", this, "Label");

            //txtIntPart.DataBindings.Add("Text", this, "IntPart");
            //txtMinutePart.DataBindings.Add("Text", this, "MinutePart");
            //txtSecondPart.DataBindings.Add("Text", this, "SecondPart");
        }

        public int IntPart { get; set; }
        public int MinutePart { get; set; }
        public double SecondPart { get; set; }
        public bool IsPositive { get; set; }  


        [
        Category("ControlSpecific"),
        Description("Numerical value to be displayed")
        ]
        public double Value
        {
            get
            {
                double theValue = IntPart + (MinutePart + SecondPart / 60) / 60.0;
                if (!IsPositive)
                {
                    theValue *= -1;
                }
                return theValue;
            }
            set
            {
                double theValue = value;
                if (theValue < 0)
                {
                    IsPositive = false;
                    theValue = -theValue;
                }
                else
                {
                    IsPositive = true;
                }

                IntPart = (int)theValue;
                theValue -= IntPart;
                theValue *= 60;

                MinutePart = (int)theValue;
                theValue -= MinutePart;

                SecondPart = theValue * 60;
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
