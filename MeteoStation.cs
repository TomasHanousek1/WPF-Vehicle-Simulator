using System.Collections.Generic;
using System;
using System.Diagnostics;
namespace WPF_Vehicle_Simulator
{
    public class MeteoStation
    {

    }
    public class WeatherList
    {
        public List<WeatherBlock> WeatherCollection = new List<WeatherBlock>();
        Random rn = new Random();
        public WeatherList(double distance)
        {
            Distance = distance;

            GetWeather();
        }
        public double Distance { get; set; }
        private void GetWeather()
        {
            int numWeathers = rn.Next(5, 12);
            double startdistance = 0;
            int startNumW = 0;
            for (int i = 0; i < numWeathers; numWeathers--)
            {
                if (numWeathers == 1)
                {
                    WeatherBlock weather;
                    do
                    {
                        weather = new WeatherBlock(startdistance, Distance, numWeathers); //weather previus type
                    } while (WeatherCollection[startNumW - 1].WBWeather.MyWeather == weather.WBWeather.MyWeather);
                    WeatherCollection.Add(weather);
                }
                else
                {
                    if (startdistance == 0)
                    {
                        WeatherBlock weather = new WeatherBlock(startdistance, Coe(startdistance, numWeathers), numWeathers); //weather previus type
                        WeatherCollection.Add(weather);
                        startdistance = weather.end;
                        startNumW++;
                    }
                    else
                    {
                        WeatherBlock weather;
                        do
                        {
                            weather = new WeatherBlock(startdistance, Coe(startdistance, numWeathers), numWeathers); //weather previus type
                        } while (WeatherCollection[startNumW - 1].WBWeather.MyWeather == weather.WBWeather.MyWeather);
                        WeatherCollection.Add(weather);
                        startdistance = weather.end;
                        startNumW++;
                    }
                }
            }
        }

        private double Coe(double startdistance, int numWeathers)
        {
            double locDis = Distance - startdistance;
            double Coee = rn.Next((int)(locDis / numWeathers / 2), (int)(locDis / numWeathers * 2));

            return Coee;
        }
    }
    public class WeatherBlock
    {
        //Random rn = new Random();
        public double range, start, end;
        public WeatherBlock(double startDistance,double endDistance, int weatherNum)
        {
            WBWeather = new Weather();
            if (weatherNum == 1)
            {
                range = (endDistance - startDistance);
            }
            else
            {
                SetRange(startDistance, endDistance);
            }
            start = startDistance;
            end = startDistance + range;
        }
        public Weather WBWeather { get; set; }

        private double SetRange(double mystart, double maxend) // getting range of WeatherBlock
        {
            //int accuracy = 10000;
            //range = rn.Next(1, accuracy) * (maxend - mystart) / accuracy;
            range = maxend;
            return range;
        }
    }
    public class Weather
    {
        public enum WeatherType { Default, Sunny, Rainy, Freeze, Snowfall } // type of weather
        private Random rn = new Random();
        public Weather()
        {
            MyWeather = (WeatherType)(rn.Next(0, 4)); // random weather
            SetAttributes(MyWeather);
        }    
        public WeatherType MyWeather { get; set; }
        public double Temperature { get; set; }
        public double SpeedRatio { get; set; }

        private void SetAttributes(WeatherType weather) // get all attributes of weather
        {
            switch (weather)
            {
                case WeatherType.Default:
                    Temperature = 20;
                    SpeedRatio = 1;
                    break;
                case WeatherType.Sunny:
                    Temperature = 27;
                    SpeedRatio = 1;
                    break;
                case WeatherType.Rainy:
                    Temperature = 17;
                    SpeedRatio = 0.9;
                    break;
                case WeatherType.Freeze:
                    Temperature = -4;
                    SpeedRatio = 0.5;
                    break;
                case WeatherType.Snowfall:
                    Temperature = -1;
                    SpeedRatio = 0.65;
                    break;
                default:
                    break;
            }
        }
        
    }
}
