using System.Collections.Generic;
using System;
using System.Windows;

namespace WPF_Vehicle_Simulator
{
    public class Road
    {
        public List<RodeObject> RodeObjects = new List<RodeObject>();

        public WeatherList myWeather;
        public Services services;
        public Road(double distance)
        {
            myWeather = new WeatherList(distance);
            GetTunnels(distance);
            GetBridges(distance);
            services = new Services(distance, RodeObjects);
        }

        private Random rn = new Random();
        private void GetTunnels(double distance)
        {
            int numTunnels = rn.Next(1, Convert.ToInt32(distance / 75000)); // max 1 tunnel on every 75Km
            double startDistance = 0; //start distance of current WeatherBlock
            double endDistance = 0;
            int startNumW = 0; //getting current number of WeatherBlock
            for (int i = 0; i < numTunnels; numTunnels--, startNumW++)
            {
                startDistance = rn.Next((int)endDistance + (int)(distance/100), (int)distance / numTunnels);
                endDistance = startDistance + rn.Next(2000, 8000);
                Tunnel tunnel = new Tunnel(startDistance, endDistance);
                RodeObjects.Add(tunnel);
            }
        }
        
        public void GetBridges(double distance)
        {
            int numBridges = rn.Next(1, Convert.ToInt32(distance / 75000)); // max 1 tunnel on every 75Km
            double endDistance = 0;
            int startNumW = 0; //getting current number of WeatherBlock
            for (int i = 0; i < numBridges; numBridges--, startNumW++)
            {
                bool bridgeAdded = false;
                double nowStartDistance = rn.Next((int)endDistance + (int)(distance / 100), (int)distance / numBridges);
                double nowEndDistance = nowStartDistance + rn.Next(2000, 8000);
                Bridge bridge = new Bridge(nowStartDistance, nowEndDistance);
                foreach (var item in RodeObjects)
                {
                    if (((item.Start > nowEndDistance) && (item.End > nowEndDistance)) || (nowStartDistance > RodeObjects[RodeObjects.Count - 1].End))
                    {
                        RodeObjects.Add(bridge);
                        bridgeAdded = true;
                        break;
                    }
                }
                if (bridgeAdded)
                {
                    endDistance = nowEndDistance;
                }
                else
                {
                    numBridges++;
                    startNumW--;
                }
            }
        }
        public override string ToString()
        {
            string s = "";
            s += 
                $"--------------------------------\n"
                + myWeather.ToString() +
                $"--------------------------------\n"
                ;
            foreach (var item in RodeObjects)
            {
                s += item.ToString();
            }

            s += $"--------------------------------\n" +
                    services.ToString() +
                $"--------------------------------\n";
            return s;
        }
    }
    public class Tunnel : RodeObject
    {
        public Tunnel(double start, double end) : base(start, end)
        {
            Start = start;
            Range = end - start;
            End = end;
            speedRatio = 0.6;
            type = "Tunnel";
        }
    }
    public class Bridge : RodeObject
    {
        public Bridge(double start, double end) : base(start,end)
        {
            Start = start;
            Range = end - start;
            End = end;
            speedRatio = 0.85;
            type = "Bridge";
        }
    }
    
    

    public class RodeObject
    {
        public string type;
        public double speedRatio;
        public double Start, Range, End;

        public RodeObject(double start, double end)
        {
            Start = start;
            Range = end - start;
            End = end;
        }

        public override string ToString()
        {
            return $"{type} | Start: {Start}m | End: {End}m | Range: {Range}m \n"; 
        }
    }
}
