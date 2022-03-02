using System.Collections.Generic;
using System.Windows;

namespace WPF_Vehicle_Simulator
{
    public class Road
    {
        public List<double> TunnelsList = new List<double>();
        public List<double> BridgesList = new List<double>();

        public WeatherList myWeather;
        public Road(double distance)
        {
            myWeather = new WeatherList(distance);
            Service service = new Service();
            GetTunnels(distance);
            GetBridges(distance);
        }

        public void GetTunnels(double distance)
        { 
            if (distance == 200000) // On the road from Prague to Brno there are 2 tunnels 
            {
                // 1. tunnel - 6000m long
                TunnelsList.Add(4000); // Start of tunnel
                TunnelsList.Add(10000); // End of tunnel
                //2. tunnel - 5000m long
                TunnelsList.Add(190000);
                TunnelsList.Add(195000);
            }
            if(distance == 170000) // Brno to Ostrava - 1 tunnel
            {
                TunnelsList.Add(90000);
                TunnelsList.Add(93000);
            }
            if(distance == 370000) // Prague to Ostrava - 3 tunnels
            {
                TunnelsList.Add(50000); 
                TunnelsList.Add(53000); 

                TunnelsList.Add(130000);
                TunnelsList.Add(131000);

                TunnelsList.Add(200000);
                TunnelsList.Add(202000);
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
}
