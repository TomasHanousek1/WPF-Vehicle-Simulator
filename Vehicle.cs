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

        public Vehicle(Destination startPoint, Destination endPoint)
        {
            ID = AllID.IDVehiclesCounter;
            AllID.IDVehiclesCounter++;
            StartPoint = startPoint;
            EndPoint = endPoint;
            Ride ride = new Ride(startPoint, endPoint);
        }
       
        /*public double[] GetRoute(double distance) // Vrátí pole o třech doublech --> {Délka normální cesty, délka všech mostů, délka všech tunelů dohromady}
        {
            return new double[]{160000, 20000, 20000 }; // 160 000m -> normální rychlost, 20 000 -> pomalejší rychlost, 20 000m -> nejpomalejší rychlost
        }*/

        /*public double GetTime(double[] route)
        {
            int normalSpeed = 130000; //m za h
            int bridgeSpeed = 80000;
            int tunnelSpeed = 50000;

            return route[0] / normalSpeed + route[1] / bridgeSpeed + route[2] / tunnelSpeed; 
        }// vypočítá za jak dlouhou dobu auto dojede do cíle přes všechny mostu a tunely (zatím bez meteo stanice)*/

        public override string ToString()
        {
            return $"Vehicle #{ID} | Start: {StartPoint} | End: {EndPoint} \n";
        }
    }
}
