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
        /// <summary>
        /// List of WeatherBlocks in Rode
        /// </summary>
        public List<WeatherBlock> WeatherCollection = new List<WeatherBlock>(); 
        private Random rn = new Random();
        public WeatherList(double distance)
        {
            Distance = distance;
            GetWeather(); // Get weather on rode
        }
        public double Distance { get; set; } //distance of whole Rode
        private void GetWeather() // Get weather on rode
        {
            int numWeathers = rn.Next(5, 12);
            double startdistance = 0; //start distance of current WeatherBlock
            int startNumW = 0; //getting current number of WeatherBlock
            for (int i = 0; i < numWeathers; numWeathers--, startNumW++)
            {
                if (numWeathers == 1) //if its last WeatherBlock in Collection
                {
                    WeatherBlock weather;
                    do
                    {
                        weather = new WeatherBlock(startdistance, Distance, numWeathers); 
                    } while (WeatherCollection[startNumW - 1].WBWeather.MyWeather == weather.WBWeather.MyWeather); //do until previusBlock.WeatherType != nowBlock.WeatherType
                    WeatherCollection.Add(weather); // add to collection
                }
                else
                {
                    if (startdistance == 0)
                    {
                        WeatherBlock weather = new WeatherBlock(startdistance, Coe(startdistance, numWeathers), numWeathers);
                        WeatherCollection.Add(weather); // add to collection
                        startdistance = weather.end; //to get start of next WeatherBlock
                    }
                    else
                    {
                        WeatherBlock weather;
                        do
                        {
                            weather = new WeatherBlock(startdistance, Coe(startdistance, numWeathers), numWeathers); 
                        } while (WeatherCollection[startNumW - 1].WBWeather.MyWeather == weather.WBWeather.MyWeather); //do until previusBlock.WeatherType != nowBlock.WeatherType
                        WeatherCollection.Add(weather); // add to collection
                        startdistance = weather.end; //to get start of next WeatherBlock
                    }
                }
            }
        }

        private double Coe(double startdistance, int numWeathers) //getting end distance of next WeatherBlock
        {
            double locDis = Distance - startdistance;
            double Coee = rn.Next((int)(locDis / numWeathers / 2), (int)(locDis / numWeathers * 2));

            return Coee;
        }
        public override string ToString()
        {
            string s = "";
            s += $"Info about weather on rode \n";
            foreach (var item in WeatherCollection)
            {
                s += $"Start: {item.start}m | End: {item.end}m | Range: {item.start}m | Weather: {item.WBWeather.MyWeather} | Range: {item.WBWeather.Temperature}°C \n";
            }
            return s;
        }
    }

    /// <summary>
    /// Physical weather block
    /// </summary>
    public class WeatherBlock
    {
        public double range, start, end;
        public WeatherBlock(double startDistance,double endDistance, int weatherNum) 
        {
            WBWeather = new Weather(); // get weather in WeatherBlock
            if (weatherNum == 1)//if it is last WeatherBlock in WeatherBlockList
            {
                range = (endDistance - startDistance); // range = remaining distance from whole Ride distance
            }
            else
            {
                SetRange(endDistance);// set range of weatherblock
            }
            start = startDistance; // set start of block
            end = startDistance + range; //set end of block
        }

        /// <summary>
        /// Weather in WeatherBlock
        /// </summary>
        public Weather WBWeather { get; set; } 

        private double SetRange(double end) // getting range of WeatherBlock
        {
            //int accuracy = 10000;
            //range = rn.Next(1, accuracy) * (maxend - mystart) / accuracy;
            return range = end;
        }
    }

    /// <summary>
    /// Physical block weather
    /// </summary>
    public class Weather
    {
        /// <summary>
        /// Type of weather
        /// </summary>
        public enum WeatherType { Default, Sunny, Rainy, Freeze, Snowfall }
        private Random rn = new Random();
        public Weather()
        {
            MyWeather = (WeatherType)(rn.Next(0, 4)); // get random weather
            SetAttributes(MyWeather); // set attributes connecting to weather
        }    
        public WeatherType MyWeather { get; set; }// WeatherType
        public double Temperature { get; set; }//Temperature
        public double SpeedRatio { get; set; } //speedRatio

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
