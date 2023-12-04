using AirportGit.DB;
using AirportGit.Functions;
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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                if (string.IsNullOrWhiteSpace(SurnameTB.Text) || string.IsNullOrWhiteSpace(NameTB.Text) || string.IsNullOrWhiteSpace(PatronymicTB.Text) ||
                    DateOfBirthDP.SelectedDate == null || string.IsNullOrWhiteSpace(PassportTB.Text) || string.IsNullOrWhiteSpace(PhoneTB.Text) ||
                    string.IsNullOrWhiteSpace(EmailTB.Text) || string.IsNullOrWhiteSpace(PasswordTB.Password))
                {
                    error.AppendLine("Заполните все поля");
                }
                if (DateOfBirthDP.SelectedDate != null &&
                    (DateTime.Now - (DateTime)DateOfBirthDP.SelectedDate).TotalDays < 365 * 14 + 3)
                {
                    error.AppendLine("Для регистрации вам должно быть минимум 14 лет");
                }
                if (AddCheck.SameEmail(EmailTB.Text.Trim()))
                {
                    error.AppendLine("Такая почта уже зарегистрирована");
                }


                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    Client client = new Client();
                    client.Surname = SurnameTB.Text.Trim();
                    client.Name = NameTB.Text.Trim();
                    client.Patronymic = PatronymicTB.Text.Trim();
                    client.DateOfBirth = DateOfBirthDP.SelectedDate;
                    client.Passport = PassportTB.Text.Trim();
                    client.Phone = PhoneTB.Text.Trim();
                    client.Email = EmailTB.Text.Trim();
                    client.Password = PasswordTB.Password.Trim();
                    DBConnection.airportEntities.Client.Add(client);
                    DBConnection.airportEntities.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
            }
        }

        private void AuthBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
