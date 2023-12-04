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
    /// Логика взаимодействия для MainMenuWorkerPage.xaml
    /// </summary>
    public partial class MainMenuWorkerPage : Page
    {
        public static List<Worker> workers { get; set; }
        public static Worker loggedWorker;
        public MainMenuWorkerPage()
        {
            InitializeComponent();
            loggedWorker = DBConnection.loginedWorker;
            UserTB.Text = DBConnection.loginedWorker.Surname.ToString() + " " + DBConnection.loginedWorker.Name.ToString() + " " + DBConnection.loginedWorker.Patronymic.ToString();
            EmailTB.Text = DBConnection.loginedWorker.Email;
            CheckConditionAndToggleButtonVisibility();
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
            NavigationService.Navigate(new AllAirplanesPage());
        }
        private void AircompanyBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllAircompaniesPage());
        }
        private void CountryBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllCountriesPage());
        }
        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
        private void CheckConditionAndToggleButtonVisibility()
        {
            if (loggedWorker.IDPosition == 4)
            {
                ClientsBTN.Visibility = Visibility.Visible; // Показать кнопку
            }
            else
            {
                ClientsBTN.Visibility = Visibility.Collapsed; // Скрыть кнопку
            }
        }
    }
}
