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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AirportGit.DB;

namespace AirportGit.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddKids.xaml
    /// </summary>
    public partial class AddKids : Page
    {
        public static Client loggedClient;
        public static List<Children> childrens { get; set; }
        public static Children children = new Children();
        public static List<Client> clients { get; set; }
        public AddKids()
        {
            InitializeComponent();
            loggedClient = DBConnection.loginedClient;
            childrens = DBConnection.airportEntities.Children.ToList();
            clients = DBConnection.airportEntities.Client.ToList();
            this.DataContext = this;
        }
        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllChildrenPage());
        }
        private void AddKidBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SurnameTB.Text) || string.IsNullOrWhiteSpace(NameTB.Text) || string.IsNullOrWhiteSpace(PatronymicTB.Text) ||
                        DateOfBirthDP.SelectedDate == null)
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    children.Surname = SurnameTB.Text.Trim();
                    children.Name = NameTB.Text.Trim();
                    children.Patronymic = PatronymicTB.Text.Trim();
                    if (DateOfBirthDP.SelectedDate != null && (DateTime.Now - (DateTime)DateOfBirthDP.SelectedDate).TotalDays > 365 * 14 + 3)
                    {
                        MessageBox.Show("По тарифу ребенок могут ездить только пассажиры младше 14 лет.");
                    }
                    else
                    {
                        children.DateOfBirth = DateOfBirthDP.SelectedDate;
                    }
                    children.IDClient = loggedClient.IDClient;

                    DBConnection.airportEntities.Children.Add(children);
                    DBConnection.airportEntities.SaveChanges();
                    NavigationService.Navigate(new AllChildrenPage());
                }
            }
            catch
            {
                MessageBox.Show("Заполните все поля!");
            }

        }
    }
}
