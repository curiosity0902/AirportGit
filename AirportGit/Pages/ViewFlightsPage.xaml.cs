using AirportGit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для ViewFlightsPage.xaml
    /// </summary>
    public partial class ViewFlightsPage : Page
    {
        public static List<Flight> flights { get; set; }
        public static List<City> cities { get; set; }
        public ViewFlightsPage()
        {
            InitializeComponent();
            flights = new List<Flight>(DBConnection.airportEntities.Flight.ToList().Where(x => x.DepartureDate >= DateTime.Now));
            cities = new List<City>(DBConnection.airportEntities.City.ToList());
            FlightsLV.ItemsSource = flights;
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if(DBConnection.loginedClient != null)
            {
                NavigationService.Navigate(new MainMenuClientPage());
            }
            else
            {
                NavigationService.Navigate(new AuthorizationPage());
            }
        }
        private void Refresh()
        {
        //    var filtred = DBConnection.airportEntities.City.ToList();

        //    var name = City1FilterCB.SelectedItem as City;
        //    if (City1FilterCB.SelectedIndex != 0 && name != null)
        //    filtred = filtred.Where(x => x.Nazvanie == name.Nazvanie).ToList();
        //    FlightsLV.ItemsSource = filtred.ToList();

            var filtred = DBConnection.airportEntities.City.ToList();

            var name = CBStudents.SelectedItem as City;
            if (CBStudents.SelectedIndex != 0 && name != null)
                filtred = filtred.Where(x => x.Nazvanie == name.Nazvanie).ToList();
            FlightsLV.ItemsSource = filtred.ToList();
        }

        //private void City1FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    Refresh();
        //}

        private void CBStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
