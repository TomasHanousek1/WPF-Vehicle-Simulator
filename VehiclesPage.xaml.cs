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
        }

        private void btnCheckVehicles_Click(object sender, RoutedEventArgs e)
        {
            foreach (var vehicle in VehicleCollection.Collection)
            {
                txtLog.Text += vehicle.ToString();
            }
        }

        private void btnCreateVehicle_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxStart.SelectedItem != null && comboBoxEnd.SelectedItem != null)
            {
                if (comboBoxStart.SelectedItem != comboBoxEnd.SelectedItem)
                {
                    Vehicle vehicle = new Vehicle((Destionation)comboBoxStart.SelectedItem, (Destionation)comboBoxEnd.SelectedItem);
                    VehicleCollection.Collection.Add(vehicle);
                    MessageBox.Show("Vehicle created");
                }
                else
                {
                    MessageBox.Show("Start point is the same as end point");
                }
            }
            else
            {
                MessageBox.Show("Point not selected");
            }
        }
    }
}
