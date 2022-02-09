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
            Vehicle x = new Vehicle(1);
            vehicleCollection.Collection.Add(x);
            Vehicle xs = new Vehicle(2);
            vehicleCollection.Collection.Add(xs);
            Vehicle xss = new Vehicle(3);
            vehicleCollection.Collection.Add(xss);
            //ConsoleList consoleList = new ConsoleList();
            foreach (var item in ConsoleList.Commands)
            {
                testBlock.Text += item.ToString();
            }
            
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
            Speed = 0.0;
            GetCommand();
            //Location = defult/set
        }

        public void GetCommand()
        {
            Command command = new Command("CAR CREATE", "You created a car with id #" + ID);
            ConsoleList.Commands.Add(command);
        }
    }

    /*public class AutonomusVehicle : Vehicle
    {

    }*/

    /// <summary>
    /// Working with commands lists 
    /// </summary>
    public static class ConsoleList
    {
        public static List<Command> Commands = new List<Command>();

        /// <summary>
        /// Get List of your commands in string
        /// </summary>
        public static void GetCommandsList()
        {
            foreach (var item in Commands)
            {
                item.ToString();
            }
        }
        public static void GetCommand(Command command)
        {
            Commands.Add(command);
        }
    }

   //enum CommandType { } // type to choose list
    public class Command
    {
        public Command(string name, string content)
        {
            CreatedTime = DateTime.Now;
            Name = name;
            Content = content;
        }
        //CommandType CommandType { get; set; } // type to choose list
        DateTime CreatedTime { get; set; }
        string Name { get; set; }
        string Content { get; set; }
        public override string ToString()
        {
            return string.Format($"{CreatedTime} | {Name} | {Content}\n");
        }
    }
}
