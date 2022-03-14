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
                double nowLocation = rn.Next((int)Location + (int)(Distance/ 100), (int)Distance / numServices);
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

    public class CarErrors
    {
        public CarErrors(ErrorCode errorCode)
        {
            CanGetToService(errorCode);
        }

        public enum ErrorCode {Default, Glass, Wheel}

        public bool getToService = false;

        private bool CanGetToService(ErrorCode errorCode)
        {
            if (true)
            {
                getToService = true;
            }
            return getToService;
        }
        public double FindNearService(double yourPosition, List<ServiceSpot> serviceSpots)
        {
            //vyhledat v listu
            double distance = 0;
            return distance;
        }
    }
}
