using System.Collections.Generic;
using System;
using System.Windows;

namespace WPF_Vehicle_Simulator
{
    public class Road
    {
        public List<Tunnel> TunnelsList = new List<Tunnel>();
        public List<Bridge> BridgesList = new List<Bridge>();

        public WeatherList myWeather;
        public Road(double distance)
        {
            myWeather = new WeatherList(distance);
            Service service = new Service();
            GetTunnels(distance);
            GetBridges(distance);
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
                TunnelsList.Add(tunnel);
            }
        }
        
        public void GetBridges(double distance)
        {
            int numBridges = rn.Next(1, Convert.ToInt32(distance / 75000)); // max 1 tunnel on every 75Km
            double startDistance = 0; //start distance of current WeatherBlock
            double endDistance = 0;
            int startNumW = 0; //getting current number of WeatherBlock
            for (int i = 0; i < numBridges; numBridges--, startNumW++)
            {
                bool bridgeAdded = false;
                double nowStartDistance = rn.Next((int)endDistance + (int)(distance / 100), (int)distance / numBridges);
                double nowEndDistance = nowStartDistance + rn.Next(2000, 8000);
                Bridge bridge = new Bridge(nowStartDistance, nowEndDistance);
                foreach (var item in TunnelsList)
                {
                    if ((item.Start < nowStartDistance && item.End < nowEndDistance) || (item.Start > nowStartDistance && item.End > nowEndDistance))
                    {
                        BridgesList.Add(bridge);
                        bridgeAdded = true;
                        break;
                    }
                }
                if (bridgeAdded)
                {
                    startDistance = nowStartDistance;
                    endDistance = nowEndDistance;
                }
                else
                {
                    numBridges++;
                    startNumW--;
                }
            }
        }
    }
    public class Tunnel
    {
        public double speedRatio = 0.7;
        public double Start, Range, End;

        public Tunnel(double start, double end)
        {
            Start = start;
            Range = end - start;
            End = end;
        }
    }
    public class Bridge
    {
        public double speedRatio = 0.7;
        public double Start, Range, End;

        public Bridge(double start, double end)
        {
            Start = start;
            Range = end - start;
            End = end;
        }
    }
}
