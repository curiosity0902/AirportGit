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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static List<Worker> workers { get; set; }
        public static List<Client> clients { get; set; }
        public AuthorizationPage()
        {
            InitializeComponent();
        }
        private void EnterBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = LoginTB.Text.Trim();
                string password = PasswordTB.Password.Trim();

                workers = new List<Worker>(DBConnection.airportEntities.Worker.ToList());
                var currentWorker = workers.FirstOrDefault(i => i.Email.Trim() == login && i.Password.Trim() == password);
                DBConnection.loginedWorker = currentWorker;
                clients = new List<Client>(DBConnection.airportEntities.Client.ToList());
                var currentClient = clients.FirstOrDefault(i => i.Email.Trim() == login && i.Password.Trim() == password);
                DBConnection.loginedClient = currentClient;
                if (currentWorker != null)
                {
                    NavigationService.Navigate(new MainMenuWorkerPage());

                    //if (currentWorker.Position.Nazvanie == "Администратор")
                    //{
                    //}
                }

                else if (currentClient != null)
                {
                    NavigationService.Navigate(new MainMenuClientPage());
                }
                else

                {
                    MessageBox.Show("Неверный логин или пароль. Попробуйте снова.");
                }
            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
            }


        }
        private void GuestBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewFlightsPage());
        }

        private void RegistrBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
