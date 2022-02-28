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
            txtLog.Clear();
            foreach (var vehicle in VehicleCollection.Collection)
            {
                txtLog.Text += vehicle.ToString();
            }
        }

        private void btnCreateVehicle_Click(object sender, RoutedEventArgs e)
        {
            Destination startDestination = Destination.Prague; // Defaultně z Prahy do Brna
            Destination endDestination = Destination.Brno;

            if (comboBoxStart.SelectedValue == startPrague)
                startDestination = Destination.Prague;
            else if (comboBoxStart.SelectedValue == startBrno)
                startDestination = Destination.Brno;
            else if (comboBoxStart.SelectedValue == startOstrava)
                startDestination = Destination.Ostrava;

            if (comboBoxEnd.SelectedValue == endPrague)
                endDestination = Destination.Prague;
            else if (comboBoxEnd.SelectedValue == endBrno)
                endDestination = Destination.Brno;
            else if (comboBoxEnd.SelectedValue == endOstrava)
                endDestination = Destination.Ostrava;

            try
            {
                if (startDestination != endDestination)
                {
                    Vehicle vehicle = new Vehicle(startDestination, endDestination);
                    VehicleCollection.Collection.Add(vehicle);
                    MessageBox.Show("Vehicle created");
                }
                else
                {
                    MessageBox.Show("Start destination is the same as end destination");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
