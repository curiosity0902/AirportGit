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
    /// Логика взаимодействия для AllKidsPage.xaml
    /// </summary>
    public partial class AllKidsPage : Page
    {
        public static List<Children> childrens { get; set; }
        public static List<Client> clients { get; set; }
        public static Client loggedClient;
        public AllKidsPage()
        {
            InitializeComponent();
            loggedClient = DBConnection.loginedClient;
            clients = new List<Client>(DBConnection.airportEntities.Client.ToList());
            childrens = new List<Children>(DBConnection.airportEntities.Children.ToList().Where(x => x.IDClient == loggedClient.IDClient));
            KidsLv.ItemsSource = new List<Children>(DBConnection.airportEntities.Children.ToList());
            this.DataContext = this;
            Refresh();
        }
        public void Refresh()
        {
            KidsLv.ItemsSource = new List<Client>(DBConnection.airportEntities.Client.ToList());
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void AddChildBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddKids());
        }
    }
}
