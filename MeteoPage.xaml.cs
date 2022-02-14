using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Vehicle_Simulator
{
    /// <summary>
    /// Interakční logika pro MeteoPage.xaml
    /// </summary>
    public partial class MeteoPage : Window
    {
        public MeteoPage()
        {
            InitializeComponent();
        }
    }

    public interface Location
    {
        double LocationX { get; set; }
        double LocationY { get; set; }
    }

    public class Weather : Location
    {
        public enum WeatherType {Default, Rain, Freez}
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        public double RangeX { get; set; }
        public double RangeY { get; set; }

    }
}
