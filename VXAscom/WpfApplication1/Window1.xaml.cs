using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ASCOM.Utilities;
using ASCOM.Interface;
using ASCOM.DriverAccess;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        private static ASCOM.Utilities.Util util = new ASCOM.Utilities.Util();

        internal string progId = "ASCOM.VXAscom.Telescope";
        public Telescope Driver { get; set; }
        public Window1()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Chooser choose = new Chooser();
                choose.DeviceType = "Telescope";
                string ProgId = choose.Choose(progId);
                if (ProgId != "")
                {

                    Driver = new Telescope(ProgId);

                    txtTelescopName.Text = Driver.Name;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
