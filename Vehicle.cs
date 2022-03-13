using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace WPF_Vehicle_Simulator
{
    static public class VehicleCollection
    {
        static public List<Vehicle> Collection = new List<Vehicle>();
        static public List<ProgressBar> BarCollection = new List<ProgressBar>();
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
        DispatcherTimer disTmr = new DispatcherTimer();
        public int timerCount = 0;

        public double Distance { get; set; }
        public double Time { get; set; }
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
            Time = GetTime(road);

            disTmr.Tick += new EventHandler(disTmr_Tick);
            disTmr.Interval = new TimeSpan(0, 0, 1);
            disTmr.Start();
        }

        public void disTmr_Tick(object sender, EventArgs e)
        {
            timerCount++;
        }

        public double GetTime(Road road)
        {
            double time = 0;
            foreach (var item in road.myWeather.WeatherCollection)
            {
                double range = item.range;
                double speed = 110000; // Default speed is 110 km/h
                double speedRatio = item.WBWeather.SpeedRatio;

                time += range / (speed * speedRatio);
            }
            return time;
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
        public override string ToString()
        {
            return $"Ride of vehilce #{vehicle.ID} | Start: {StartPoint} | End: {EndPoint} | Time: {Math.Round(Time, 2)}| {timerCount}m\n";
        }
    }
    public class Vehicle
    {
        public List<Ride> ride = new List<Ride>();
        public int ID { get; set; }
        public bool Lights { get; set; }
        public Vehicle()
        {
            ID = AllID.IDVehiclesCounter;
            AllID.IDVehiclesCounter++;
            Lights = false;
        }


        public override string ToString()
        {
            bool isRide = false;

            try
            {
                int rideID = VehicleCollection.Collection[ID - 1].ride.Count - 1;
                if (VehicleCollection.Collection[ID - 1].ride[rideID].Distance > 0)
                {
                    isRide = true;
                }
            }
            catch (Exception)
            {
                isRide = false;
            }
            return $"Vehicle #{ID} | Lights: {Lights} | Ride: {isRide} \n";
        }
    }
}
