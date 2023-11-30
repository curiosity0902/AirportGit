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
            if (string.IsNullOrWhiteSpace(SurnameTB.Text) || string.IsNullOrWhiteSpace(NameTB.Text) || string.IsNullOrWhiteSpace(PatronymicTB.Text) ||
                DateOfBirthDP.SelectedDate == null || string.IsNullOrWhiteSpace(PassportTB.Text) || string.IsNullOrWhiteSpace(PhoneTB.Text) ||
                string.IsNullOrWhiteSpace(EmailTB.Text) || string.IsNullOrWhiteSpace(PasswordTB.Password))
            {
                MessageBox.Show("Заполните все поля");
            }
            else if ((DateTime.Now - (DateTime)DateOfBirthDP.SelectedDate).TotalDays < 365 * 16)
            {
                MessageBox.Show("Для регистрации вам должно быть минимум 16 лет");
            }
            else if (SameEmail())
            {
                MessageBox.Show("Такая почта уже зарегистрирована");
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
        private bool SameEmail()
        {
            Client client = new List<Client>(DBConnection.airportEntities.Client.ToList()).FirstOrDefault(x => x.Email.Trim() == EmailTB.Text.Trim());
            if (client != null)
            {
                return true;
            }
            else
            {
                Worker worker = new List<Worker>(DBConnection.airportEntities.Worker.ToList()).FirstOrDefault(x => x.Email.Trim() == EmailTB.Text.Trim());
                if (worker != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
