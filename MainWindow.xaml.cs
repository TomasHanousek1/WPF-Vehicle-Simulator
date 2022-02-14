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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Vehicle_Simulator
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnNewVehicle_Click(object sender, RoutedEventArgs e)
        {
            Vehicle vehicle = new Vehicle();
            VehicleCollection.Collection.Add(vehicle);
            MessageBox.Show("Vehicle created");
        }

        private void btnVehicles_Click(object sender, RoutedEventArgs e)
        {
            foreach (var vehicle in VehicleCollection.Collection)
            {
                txtLog.Text += vehicle.ToString();
            }
        }

        private void btnWeather_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnServices_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    /// <summary>
    /// Vehicles collections to save data
    /// </summary>
    static public class VehicleCollection
    {
        static public List<Vehicle> Collection = new List<Vehicle>();
    }

    /// <summary>
    /// Static class to save ID count
    /// </summary>
    public static class AllID
    {
        public static int IDVehiclesCounter = 1;
    }

    /// <summary>
    /// Enum of route types
    /// </summary>
    public enum TypeOfRoute { Default, Bridge = 5, Tunnel = 10 }

    public class Vehicle
    {
        public int ID { get; set; }
        public double Speed { get; set; }
        public double Location { get; set; }

        private TypeOfRoute route;
        public TypeOfRoute CurrentRoute
        {
            get { return route; }
            set { route = value; }
            //set -> CurrentRoute = TypeOfRoute.Normal;
            //get -> TypeOfRoute theRoute = CurrentRoute;
        }
        public Vehicle()
        {
            ID = AllID.IDVehiclesCounter;
            Speed = 0.0;
            route = TypeOfRoute.Default;

            //Location = defult/set
            AllID.IDVehiclesCounter++;
        }

        public override string ToString()
        {
            return $"Vehicle #{ID} \n";
        }
    }

    /*public class AutonomusVehicle : Vehicle
    {
    }*/
}
