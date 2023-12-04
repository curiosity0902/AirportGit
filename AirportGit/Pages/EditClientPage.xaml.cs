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
    /// Логика взаимодействия для EditClientPage.xaml
    /// </summary>
    public partial class EditClientPage : Page
    {
        public static List<Client> clients { get; set; }
        public static Client client { get; set; }
        public static Client loggedClient;
        public EditClientPage(Client client)
        {
            InitializeComponent();
            loggedClient = client;
            InitializeDataInPage();
            this.DataContext = this;
        }

        private void InitializeDataInPage()
        {
            clients = DBConnection.airportEntities.Client.ToList();
            loggedClient = DBConnection.loginedClient;
            this.DataContext = this;
            SurnameTB.Text = loggedClient.Surname;
            NameTB.Text = loggedClient.Name;
            PatronymicTB.Text = loggedClient.Patronymic;
            DateOfBirthDP.SelectedDate = loggedClient.DateOfBirth;
            PassportTB.Text = loggedClient.Passport;
            PhoneTB.Text = loggedClient.Phone;
            EmailTB.Text = loggedClient.Email;
            PasswordTB.Text = loggedClient.Password;
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuClientPage());
        }

        private void EditClientBTN_Click(object sender, RoutedEventArgs e)
        {
            Client client = loggedClient;
            if (string.IsNullOrWhiteSpace(SurnameTB.Text) || string.IsNullOrWhiteSpace(NameTB.Text) || string.IsNullOrWhiteSpace(PatronymicTB.Text) ||
                    DateOfBirthDP.SelectedDate == null || string.IsNullOrWhiteSpace(PassportTB.Text) || string.IsNullOrWhiteSpace(PhoneTB.Text) ||
                    string.IsNullOrWhiteSpace(EmailTB.Text) || string.IsNullOrWhiteSpace(PasswordTB.Text))
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                client.Surname = SurnameTB.Text;
                client.Name = NameTB.Text;
                client.Patronymic = PatronymicTB.Text;
                if (DateOfBirthDP.SelectedDate != null &&
                        (DateTime.Now - (DateTime)DateOfBirthDP.SelectedDate).TotalDays < 365 * 14 + 4)
                {
                    MessageBox.Show("Вы не можете быть младше 14 лет.");
                }
                else
                {
                    client.DateOfBirth = Convert.ToDateTime(DateOfBirthDP.Text);
                }
                client.Phone = PhoneTB.Text;
                client.Email = EmailTB.Text;
                client.Password = PasswordTB.Text;
                DBConnection.airportEntities.SaveChanges();

                SurnameTB.Text = String.Empty;
                NameTB.Text = String.Empty;
                PatronymicTB.Text = String.Empty;
                DateOfBirthDP = null;
                PhoneTB.Text = String.Empty;
                EmailTB.Text = String.Empty;
                PasswordTB.Text = String.Empty;

                DBConnection.airportEntities.SaveChanges();
                NavigationService.Navigate(new MainMenuClientPage());
            }
        }
    }
}
