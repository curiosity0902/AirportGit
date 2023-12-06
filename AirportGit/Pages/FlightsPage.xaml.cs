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
            }
            else
            {
                AddFlightBTN.Visibility = Visibility.Collapsed;
            }
        }


        private void Refresh()
        {
            IEnumerable<Flight> filter = flights;

            if (StartDp.SelectedDate != null)
            {
                filter = filter.Where(x => x.DepartureDate >= StartDp.SelectedDate);
            }

            if (EndDp.SelectedDate != null)
            {
                filter = filter.Where(x => x.ArivalDate <= EndDp.SelectedDate);
            }

            if (SearchStartTb.Text != "")
            {
                string search = SearchStartTb.Text.Trim().ToLower(); ;
                filter = filter.Where(x => x.Flyghtport1.Name.ToLower().StartsWith(search) || x.Flyghtport1.City.Nazvanie.ToLower().StartsWith(search)
                || x.Flyghtport1.City.Country.Nazvanie.ToLower().StartsWith(search));
            }

            if (SearchEndTb.Text != "")
            {
                string search = SearchEndTb.Text.Trim().ToLower();
                filter = filter.Where(x => x.Flyghtport.Name.ToLower().StartsWith(search) || x.Flyghtport.City.Nazvanie.ToLower().StartsWith(search)
                || x.Flyghtport.City.Country.Nazvanie.ToLower().StartsWith(search));
            }

            FlightsLV.ItemsSource = filter.ToList();

        }


        private void EndDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchStartTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchEndTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
    }
}
