using System.Collections.Generic;

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

    public enum TypeOfRoute { Default, Bridge, Tunnel }
    public enum Destination
    {
        Prague,
        Brno,
        Ostrava
    }
    public class Vehicle
    {
        public double Distance { get; set; }
        public int ID { get; set; }
        public double Speed { get; set; }

        private TypeOfRoute route;
        public TypeOfRoute CurrentRoute
        {
            get { return route; }
            set { route = value; }
            //set -> CurrentRoute = TypeOfRoute.Normal;
            //get -> TypeOfRoute theRoute = CurrentRoute;
        }

        public Destination StartPoint { get; set; }
        public Destination EndPoint { get; set; }

        public Vehicle(Destination startPoint, Destination endPoint)
        {
            ID = AllID.IDVehiclesCounter;
            Speed = 0.0;
            route = TypeOfRoute.Default;
            StartPoint = startPoint;
            EndPoint = endPoint;
            Distance = GetDistance(StartPoint, EndPoint);
            AllID.IDVehiclesCounter++;
        }
        public double GetDistance(Destination startPoint, Destination endPoint)
        {
            if ((startPoint == Destination.Prague || startPoint == Destination.Brno) && (endPoint == Destination.Prague || endPoint == Destination.Brno))
            {
                return 200;
            }
            else if ((startPoint == Destination.Brno || startPoint == Destination.Ostrava) && (endPoint == Destination.Ostrava || endPoint == Destination.Brno))
            {
                return 170;
            }
            else if ((startPoint == Destination.Prague || startPoint == Destination.Ostrava) && (endPoint == Destination.Ostrava || endPoint == Destination.Prague))
            {
                return 370;
            }
            return 0;
        }

        public override string ToString()
        {
            return $"Vehicle #{ID} | Start: {StartPoint} | End: {EndPoint} | Distance: {Distance}\n";
        }
    }
}
