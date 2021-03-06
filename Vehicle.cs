using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public bool isRide { get; set; }
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
            isRide = true;

            disTmr.Tick += new EventHandler(disTmr_Tick);
            disTmr.Interval = new TimeSpan(0, 0, 1);
            disTmr.Start();
        }

        Random rn = new Random();
        public double currentDistance = 0;
        public void disTmr_Tick(object sender, EventArgs e)
        {
            if (vehicle.CanRide == true)
            {
                timerCount++;
                double weatherSpeedRatio = 1;
                double rodeTypeSpeedRatio = 1;
                double defaultSpeed = 1000; // m/s
                foreach (var item in road.myWeather.WeatherCollection)
                {
                    if (item.start <= currentDistance && item.end > currentDistance)
                    {
                        weatherSpeedRatio = item.WBWeather.SpeedRatio;
                        break;
                    }
                }
                foreach (var item in road.RodeObjects)
                {
                    if (item.Start <= currentDistance && item.End > currentDistance)
                    {
                        rodeTypeSpeedRatio = item.speedRatio;
                        if (item.type == "Tunnel")
                        {
                            vehicle.Lights = true;
                            weatherSpeedRatio = 1;
                        }
                    }
                }
                if (rodeTypeSpeedRatio == 1)
                {
                    vehicle.Lights = false;
                }
                currentDistance += (defaultSpeed * weatherSpeedRatio * rodeTypeSpeedRatio);
                if (currentDistance >= Distance)
                {
                    MessageBox.Show($"Vehicle #{vehicle.ID} arrived to the destionation!");
                    currentDistance = Distance;
                    isRide = false;
                    disTmr.Stop();
                }

                if (rn.Next(1, 8) == 7)
                {
                    VehicleErrors vehicleErrors = new VehicleErrors();
                    vehicle.HistoryOfErrors.Add(vehicleErrors);
                    vehicle.CanRide = vehicleErrors.CanRide;
                    if (vehicle.CanRide == false)
                    {
                        double distanceToService = FindNearService(currentDistance, road.services.serviceSpots);
                        Debug.WriteLine(distanceToService);
                    }
                }
            }
            else
            {
                disTmr.Stop(); 
            }

        }
        public double FindNearService(double yourPosition, List<ServiceSpot> serviceSpots)
        {
            double distanceToService;
            double previusMyDystance;

            foreach (var item in serviceSpots)
            {
                if (serviceSpots.Count == 1)
                {
                    distanceToService = Math.Abs(item.Position - yourPosition);
                    return distanceToService;
                }
                else
                {
                    previusMyDystance = Math.Abs(item.Position - yourPosition);
                    foreach (var service in serviceSpots)
                    {
                        distanceToService = Math.Abs(service.Position - yourPosition);
                        if (previusMyDystance < distanceToService)
                        {
                            previusMyDystance = distanceToService;
                        }
                    }
                    return previusMyDystance;
                }
            }
            return 0;
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
            return $"Ride of vehilce #{vehicle.ID} | Lights {vehicle.Lights}| Start: {StartPoint} | End: {EndPoint} | {timerCount}min: {currentDistance}m {currentDistance / Distance * 100}%\n";
        }
    }
    public class Vehicle
    {
        public List<VehicleErrors> HistoryOfErrors = new List<VehicleErrors>();
        public List<Ride> ride = new List<Ride>();
        public int ID { get; set; }
        public bool CanRide { get; set; }
        public bool Lights { get; set; }
        public Vehicle()
        {
            ID = AllID.IDVehiclesCounter;
            AllID.IDVehiclesCounter++;
            Lights = false;
            CanRide = true;
        }


        public override string ToString()
        {
            bool isRide = false;

            try
            {
                int rideID = VehicleCollection.Collection[ID - 1].ride.Count - 1;
                if (VehicleCollection.Collection[ID - 1].ride[rideID].isRide == true)
                {
                    isRide = true;
                }
            }
            catch (Exception)
            {
                isRide = false;
            }
            return $"Vehicle #{ID} | Lights: {Lights} | Vehicle on ride: {isRide} | Vehicle can ride: {CanRide}  \n";
        }
    }
}
