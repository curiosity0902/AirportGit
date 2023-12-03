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
using AirportGit.DB;

namespace AirportGit.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenuClientPage.xaml
    /// </summary>
    public partial class MainMenuClientPage : Page
    {
        public static List<Client> clients { get; set; }
        public static Client loggedClient;
        public MainMenuClientPage()
        {
            InitializeComponent();
            loggedClient = DBConnection.loginedClient;
            UserTB.Text = DBConnection.loginedClient.Surname.ToString() + " " + DBConnection.loginedClient.Name.ToString() + " " + DBConnection.loginedClient.Patronymic.ToString();
            EmailTB.Text = DBConnection.loginedClient.Email;
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
        private void AircompanyBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllAirportsPage());
        }
        private void CountryBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllCountriesPage());
        }
        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void MyTicketsBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MyTicketsPage());
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
