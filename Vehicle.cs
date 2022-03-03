using System.Collections.Generic;
using System.Windows;

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
        public Ride(Destination startPoint, Destination endPoint)
        {
            Distance = GetDistance(startPoint, endPoint);
            road = new Road(Distance);           
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
        public int ID { get; set; }
        public double Time { get; set; }

        public Destination StartPoint { get; set; }
        public Destination EndPoint { get; set; }

        public Ride ride;
        public Vehicle(Destination startPoint, Destination endPoint)
        {
            ID = AllID.IDVehiclesCounter;
            AllID.IDVehiclesCounter++;
            StartPoint = startPoint;
            EndPoint = endPoint;
            ride = new Ride(startPoint, endPoint);
        }
              

        public override string ToString()
        {
            return $"Vehicle #{ID} | Start: {StartPoint} | End: {EndPoint} \n";
        }
    }
}
