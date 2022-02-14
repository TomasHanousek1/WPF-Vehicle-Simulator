using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Vehicle_Simulator
{
    /// <summary>
    /// Interakční logika pro VehiclesPage.xaml
    /// </summary>
    public partial class VehiclesPage : Window
    {
        public VehiclesPage()
        {
            InitializeComponent();
            Vehicle v1 = new Vehicle();
            Vehicle v2 = new Vehicle();
            Vehicle v3 = new Vehicle();
            VehicleCollection.Collection.Add(v1);
            VehicleCollection.Collection.Add(v2);
            VehicleCollection.Collection.Add(v3);
        }

        private void btnCheckVehicles_Click(object sender, RoutedEventArgs e)
        {
            foreach (var vehicle in VehicleCollection.Collection)
            {
                txtLog.Text += vehicle.ToString();
            }
        }
    }
}
