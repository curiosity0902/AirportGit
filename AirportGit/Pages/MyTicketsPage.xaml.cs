using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using AirportGit.DB;

namespace AirportGit.Pages
{
    /// <summary>
    /// Логика взаимодействия для MyTicketsPage.xaml
    /// </summary>
    public partial class MyTicketsPage : Page
    {
        public static List<Ticket> tickets { get; set; }
        public static List<Flight> flights { get; set; }
        public static List<City> cities { get; set; }
        public MyTicketsPage()
        {
            InitializeComponent();
            tickets = new List<Ticket>(DBConnection.airportEntities.Ticket.ToList().Where(x => x.IDClient == DBConnection.loginedClient.IDClient));
            flights = new List<Flight>(DBConnection.airportEntities.Flight.ToList());
            cities = new List<City>(DBConnection.airportEntities.City.ToList());
            this.DataContext = this;
        }

        public void Refresh()
        {
            TicketsLv.ItemsSource = tickets;
        }
        private void FlightsLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BackBtn_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuClientPage());
        }
    }
}
