﻿using AirportGit.DB;
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
            string login = LoginTB.Text.Trim();
            string password = PasswordTB.Password.Trim();

            workers = new List<Worker>(DBConnection.airportEntities.Worker.ToList());
            var currentWorker = workers.FirstOrDefault(i => i.Email == login && i.Password == password);
            DBConnection.loginedWorker = currentWorker;
            if (currentWorker != null)
            {
                //if (currentWorker.Position.Nazvanie == "преподаватель")
                //    NavigationService.Navigate(new ExamPage());
                //else if (currentWorker.Position.Nazvanie == "зав. кафедрой")
                //    NavigationService.Navigate(new ChairPage());
                //else if (currentWorker.Position.Nazvanie == "инженер")
                //    NavigationService.Navigate(new WorkerPage());
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль. Попробуйте снова.");
            }

            clients = new List<Client>(DBConnection.airportEntities.Client.ToList());
            var currentClient = clients.FirstOrDefault(i => i.Email == login && i.Password == password);
            DBConnection.loginedClient = currentClient;
            if (currentClient != null)
            {
                NavigationService.Navigate(new MainMenuClientPage());
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль. Попробуйте снова.");
            }

        }
        private void GuestBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FlightsPage());
        }

        private void RegistrBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
