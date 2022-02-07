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

            VehicleCollection vehicleCollection = new VehicleCollection();
            vehicleCollection.Collection = new List<Vehicle>();
            //Vehicle x = new Vehicle("čauky");
            //vehicleCollection.Collection.Add(x);
            
        }
    }

    public class VehicleCollection
    {
        public List<Vehicle> Collection;
    }
    public class Vehicle
    {
        public int ID { get; set; }
        public double Speed { get; set; }
        public double Location { get; set; }

        public Vehicle(int id)
        {
            ID = id;
        }
    }
}
