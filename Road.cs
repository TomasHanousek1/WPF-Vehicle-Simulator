namespace WPF_Vehicle_Simulator
{
    public class Road
    {

        public Road(double distance)
        {
            WeatherList myWeather = new WeatherList(distance);
            Service service = new Service();
        }

    }
}
