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
    /// Interakční logika pro HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void btnVehicles_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnControlCenter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMeteoCenter_Click(object sender, RoutedEventArgs e)
        {
            MeteoPage mp = new MeteoPage();
            mp.Show();
            this.Close();
        }
    }
}
