using System.Collections.Generic;
using System;
namespace WPF_Vehicle_Simulator
{

    public class Services
    {
        double Distance;
        public List<ServiceSpot> serviceSpots = new List<ServiceSpot>();

        public Services(double distance, List<RodeObject> rodeTypes)
        {
            Distance = distance;
            GetServiceOnRode(rodeTypes);
        }

        Random rn = new Random();
        public void GetServiceOnRode(List<RodeObject> rodeTypes)
        {
            int numServices = rn.Next(1, Convert.ToInt32(Distance / 90000)); // 1 in 90km
            double Location = 0;
            int startNumW = 0;
            for (int i = 0; i < numServices; numServices--, startNumW++)
            {
                bool serviceAdded = false;
                double nowLocation = rn.Next((int)Location + (int)(Distance / 100), (int)Distance / numServices);
                ServiceSpot service = new ServiceSpot(nowLocation);
                foreach (var item in rodeTypes)
                {
                    if ((item.Start > nowLocation && item.End > nowLocation) || (nowLocation > rodeTypes[rodeTypes.Count - 1].End))
                    {
                        serviceSpots.Add(service);
                        serviceAdded = true;
                        break;
                    }

                }
                if (serviceAdded)
                {
                    Location = nowLocation;
                }
                else
                {
                    numServices++;
                    startNumW--;
                }
            }
        }
        public override string ToString()
        {
            string s = "";
            foreach (var item in serviceSpots)
            {
                s += item.ToString();
            }
            return s;
        }
    }


    public class ServiceSpot
    {
        public double Position;
        public ServiceSpot(double position)
        {
            Position = position;
        }
        public override string ToString()
        {
            string s = "";
            s += $" Service | Position {Position}m\n";
            return s;

        }

    }

    public class VehicleErrors
    {
        Random rn = new Random();
        public bool CanRide { get; set; }
        public List<VehicleError> vehicleErrorsCollection = new List<VehicleError>();
        public VehicleErrors()
        {
            GetErrors();
            CanRide = CanGetToService();
        }

        private void GetErrors()
        {
            int numErrors = rn.Next(1, 3);
            for (int i = 0; i < numErrors; numErrors--)
            {
                VehicleError vehicleError = new VehicleError();
                vehicleErrorsCollection.Add(vehicleError);
                // Tady udělat Event
            }
        }
        
        private bool CanGetToService()
        {
            bool can = true;
            foreach (var item in vehicleErrorsCollection)
            {
                if (item.IsCarRideable == false)
                {
                    can = false;
                    break;
                }
            }
            return can;
        }
       
        public override string ToString()
        {
            string s = "";
            s += $"Car can ride: {CanRide}\n";
            foreach (var item in vehicleErrorsCollection)
            {
                s += $"Error{item.ErrorCode}\n";
            }
            return s;
        }
    }

    public class VehicleError
    {
        public delegate void WehicleErrors();
        public event WehicleErrors MyErrors;

        public bool IsCarRideable;
        public ErrorCodeType ErrorCode { get; set; }
        public enum ErrorCodeType { Small = 1, Glass, Wheel, Window, Lights, Motor}
        public VehicleError()
        {
            MyErrors += GetError;

            MyErrors?.Invoke();
        }

        public void GetError()
        {
            Random rn = new Random();
            ErrorCode = (ErrorCodeType)rn.Next(1, 7);
            IsCarRideable = CanGoToService(ErrorCode);
        }

        public bool CanGoToService(ErrorCodeType error)
        {
            bool canRide;
            switch (error)
            {
                case ErrorCodeType.Small:
                    canRide = true;
                    break;
                case ErrorCodeType.Glass:
                    canRide = false;
                    break;
                case ErrorCodeType.Wheel:
                    canRide = false;
                    break;
                case ErrorCodeType.Window:
                    canRide = true;
                    break;
                case ErrorCodeType.Lights:
                    canRide = true;
                    break;
                case ErrorCodeType.Motor:
                    canRide = false;
                    break;
                default:
                    canRide = true;
                    break;
            }
            return canRide;
        }
    }
}
