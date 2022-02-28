using System.Collections.Generic;
using System;
using System.Diagnostics;
namespace WPF_Vehicle_Simulator
{

    public class MeteoStation
    {

    }
    public class Rode
    {

    }
    public class WeatherList
    {
        public List<WeatherBlock> WeatherCollection = new List<WeatherBlock>();
        public double Distance { get; set; }
        Random rn = new Random();
        public int NumWeathers;
        public WeatherList(double distance)
        {
            Distance = distance;
            NumWeathers = rn.Next(1, 5);
            GetWeatherOnRode();
        }
        public void GetWeatherOnRode()
        {
            double startdistance = 0;
            for (int i = 0; i < NumWeathers; i++)
            {
                WeatherBlock weather = new WeatherBlock(startdistance, Distance, Weather.WeatherType.Default); //weather previus type
                WeatherCollection.Add(weather);
                startdistance = weather.end;
            }
        }
    }
    public class WeatherBlock
    {
        Random rn = new Random();
        public double range, start, end;
        public Weather MyWeather { get; set; }
        public WeatherBlock(double startDistance,double endDistance, Weather.WeatherType previusType)
        {
            MyWeather = new Weather();
            SetRange(startDistance, endDistance);
            start = startDistance;
            end = startDistance + range;
        }
      
        private double SetRange(double mystart, double maxend)
        {
            int accuracy = 10000;
            range = rn.Next(1, accuracy) * (maxend - mystart) / accuracy;

            return range;
        }
    }
    public class Weather
    {
        Random rn = new Random();
        private double speedRatio;
        double SpeedRatio
        {
            get => speedRatio;
            set
            {
                if (MyWeather == WeatherType.Default)
                {
                    speedRatio = 1;
                }
                else if (MyWeather == WeatherType.Freez)
                {
                    speedRatio = 0.7;
                }
                else if (MyWeather == WeatherType.Rain)
                {
                    speedRatio = 0.8;
                }
            }
        }
        public Weather()
        {
            MyWeather = (WeatherType)(rn.Next(0, 2));
            double s = SpeedRatio;
           
            
        }
        public enum WeatherType { Default, Rain, Freez }    
        WeatherType MyWeather { get; set; }
        public double Temperature { get; set; }
        
        public double GetTemperature(WeatherType weather)
        {
            return Temperature;
        }
        
    }
}
