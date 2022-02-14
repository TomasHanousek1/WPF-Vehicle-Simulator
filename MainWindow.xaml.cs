﻿using System;
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
        }

        private void btnVehicles_Click(object sender, RoutedEventArgs e)
        {

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
    public enum TypeOfRoute { Default, Bridge = 5, Tunnel = 10}

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
        public static string GetCommandsList()
        {
            string s = "";
            foreach (var item in Commands)
            {
                s += item.ToString();
            }
            return s;
        }
        public static void GetCommand(Command command)
        {
            Commands.Add(command);
        }
        public static string ClearConsole(string s)
        {
           return s = "";
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

    public static class YourCommand
    {
        public static void CommandInfo(string s) // add split string to command + other parts
        {
            
        }
    }
}
