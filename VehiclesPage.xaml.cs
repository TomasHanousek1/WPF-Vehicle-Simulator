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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Vehicle_Simulator
{
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

        private void btnCreateRide_Click(object sender, RoutedEventArgs e)
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
                    txtLog.Clear();
                    int carID = Convert.ToInt32(idBox.Text) - 1;
                    Ride ride = new Ride(startDestination, endDestination, VehicleCollection.Collection[carID]);
                    VehicleCollection.Collection[carID].ride.Add(ride); // add to list in vehicles
                    foreach (var item in VehicleCollection.Collection[carID].ride)
                    {
                        txtLog.Text += item.ToString();
                        txtLog.Text += item.road.myWeather.ToString();
                    }
                    CreateProgressBar(ride.Time);
                    MessageBox.Show("Ride created");
                }
                else
                {
                    MessageBox.Show("Start destination is the same as end destination");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("ID is not valid");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)// just check for now
        {
            Vehicle vehicle = new Vehicle();
            VehicleCollection.Collection.Add(vehicle);
            MessageBox.Show("Vehicle created");
            /*txtLog.Clear();

            int carID = Convert.ToInt32(idBox.Text);
            txtLog.Text += "Car with id #" + carID;
            //txtLog.Text += VehicleCollection.Collection[Convert.ToInt32(carID - 1)].ride.road.myWeather.ToString();*/
        }

        public void CreateProgressBar(double time)
        {
            ProgressBar pb = new ProgressBar();
            pb.IsIndeterminate = false;
            pb.Orientation = Orientation.Horizontal;
            pb.Width = 300;
            pb.Height = 30;
            double speedFaster = 1000; // Progressbar will load 1000* faster
            Duration dur = new Duration(TimeSpan.FromHours(time / speedFaster));
            DoubleAnimation ani = new DoubleAnimation(100.0, dur);
            pb.BeginAnimation(ProgressBar.ValueProperty, ani);
            sbar.Items.Add(pb);
        }

        private void btnShowVehicle_Click(object sender, RoutedEventArgs e)
        {
            txtLog.Clear();
            sbar.Items.Clear();
            int carID = Convert.ToInt32(idBoxShow.Text) - 1;
            foreach (var item in VehicleCollection.Collection[carID].ride)
            {
                txtLog.Text += item.ToString();
                txtLog.Text += item.road.myWeather.ToString();
            }
        }
    }
}
