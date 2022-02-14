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

    public enum TypeOfRoute { Default, Bridge = 5, Tunnel = 10 }
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

        public override string ToString()
        {
            return $"Vehicle #{ID} \n";
        }
    }
}
