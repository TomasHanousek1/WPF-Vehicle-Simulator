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
            //Location = defult/set
            AllID.IDVehiclesCounter++;
        }

        public override string ToString()
        {
            return $"Vehicle #{ID} | Start: {StartPoint} | End: {EndPoint} \n";
        }
    }
}
