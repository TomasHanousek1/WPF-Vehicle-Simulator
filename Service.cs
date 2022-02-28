using System.Collections.Generic;
using System;
namespace WPF_Vehicle_Simulator
{
    public class Service
    {
        int numService;
        public List<ServiceSpot> serviceSpots = new List<ServiceSpot>();

        public Service()
        {
            
        }

        public void GetServiceOnRode()
        {
            for (int i = 0; i < numService; i++)
            {
                ServiceSpot s = new ServiceSpot(0);
                serviceSpots.Add(s);
            }
        }       
    }

    public class ServiceSpot
    {
        public ServiceSpot(double serviceLocation)
        {
            this.serviceLocation = serviceLocation;
        }

        public double serviceLocation { get; set; }

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
