using AirportGit.DB;
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
    /// Логика взаимодействия для FlightsPage.xaml
    /// </summary>
    public partial class FlightsPage : Page
    {
        public static List<Flight> flights { get; set; }
        public static Worker loggedWorker;
        public FlightsPage()
        {
            InitializeComponent();
            flights = new List<Flight>(DBConnection.airportEntities.Flight.ToList().Where(x => x.DepartureDate >= DateTime.Now));
            FlightsLV.ItemsSource = flights;
            loggedWorker = DBConnection.loginedWorker;
            CheckConditionAndToggleButtonVisibility();
        }
        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuWorkerPage());
        }

        private void AddFlightBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddFlightPage());
        }
        private void CheckConditionAndToggleButtonVisibility()
        {
            if (loggedWorker.IDPosition == 4)
            {
                AddFlightBTN.Visibility = Visibility.Visible;
                //EditWorkerBTN.Visibility = Visibility.Visible;
                //DeleteWorkerBTN.Visibility = Visibility.Visible;
            }
            else
            {
                AddFlightBTN.Visibility = Visibility.Visible;
                //EditWorkerBTN.Visibility = Visibility.Collapsed;
                //DeleteWorkerBTN.Visibility = Visibility.Collapsed;
            }
        }
    }
}
