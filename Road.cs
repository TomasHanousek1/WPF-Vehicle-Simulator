﻿using System.Collections.Generic;
using System;
using System.Windows;

namespace WPF_Vehicle_Simulator
{
    public class Road
    {
        public List<Tunnel> TunnelsList = new List<Tunnel>();
        public List<double> BridgesList = new List<double>();

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
            if (distance == 200000) // On the road from Prague to Brno there are 3 bridges 
            {
                //1. bridge - 1000m long
                BridgesList.Add(1000); // Start of bridge
                BridgesList.Add(2000); // End of bridge
                //2. bridge
                BridgesList.Add(90000);
                BridgesList.Add(90500);
                //3. bridge
                BridgesList.Add(150000);
                BridgesList.Add(152000);
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
}
