﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WPF_Vehicle_Simulator
{
    static public class VehicleCollection
    {
        static public List<Vehicle> Collection = new List<Vehicle>();
    }

    public static class AllID
    {
        public static int IDVehiclesCounter = 1;
    }

    public enum Destination
    {
        Prague,
        Brno,
        Ostrava
    }

    public class Ride
    {
        public double Distance { get; set; }
        public Road road;
        public Vehicle vehicle;

        public Destination StartPoint { get; set; }
        public Destination EndPoint { get; set; }
        public Ride(Destination startPoint, Destination endPoint, Vehicle vehicle1)
        {
            vehicle = vehicle1;
            StartPoint = startPoint;
            EndPoint = endPoint;
            Distance = GetDistance(startPoint, endPoint);
            road = new Road(Distance);
        }
        public override string ToString()
        {
            return $"Vehicle #{vehicle.ID} | Start: {StartPoint} | End: {EndPoint} \n";
        }
        public double GetDistance(Destination startPoint, Destination endPoint)
        {
            if ((startPoint == Destination.Prague || startPoint == Destination.Brno) && (endPoint == Destination.Prague || endPoint == Destination.Brno))
            {
                return 200000; // Distance in meters
            }
            else if ((startPoint == Destination.Brno || startPoint == Destination.Ostrava) && (endPoint == Destination.Ostrava || endPoint == Destination.Brno))
            {
                return 170000;
            }
            else if ((startPoint == Destination.Prague || startPoint == Destination.Ostrava) && (endPoint == Destination.Ostrava || endPoint == Destination.Prague))
            {
                return 370000;
            }
            return 0;
        }
    }
    public class Vehicle
    {
        public List<Ride> ride = new List<Ride>();
        public int ID { get; set; }
        public Vehicle()
        {
            ID = AllID.IDVehiclesCounter;
            AllID.IDVehiclesCounter++;
        }
        public override string ToString()
        {
            return $"Vehicle #{ID} \n";
        }
    }
}
