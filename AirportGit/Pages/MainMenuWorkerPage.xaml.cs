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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirportGit.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenuWorkerPage.xaml
    /// </summary>
    public partial class MainMenuWorkerPage : Page
    {
        public MainMenuWorkerPage()
        {
            InitializeComponent();
        }
        private void WorkersBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllWorkersPage());
        }
        private void ClientsBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllClientsPage());
        }
        private void FlightsBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FlightsPage());
        }

        private void AirplaneBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllAirportsPage());
        }
    }
}
