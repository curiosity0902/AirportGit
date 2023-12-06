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
    /// Логика взаимодействия для AllClientsPage.xaml
    /// </summary>
    public partial class AllClientsPage : Page
    {
        public static List<Client> clients { get; set; }
        public AllClientsPage()
        {
            InitializeComponent();
            clients = new List<Client>(DBConnection.airportEntities.Client.ToList());
            ClientsLv.ItemsSource = new List<Client>(DBConnection.airportEntities.Client.ToList());
            this.DataContext = this;
            Refresh();
        }
        public void Refresh()
        {
            ClientsLv.ItemsSource = new List<Client>(DBConnection.airportEntities.Client.ToList());
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuWorkerPage());
        }
    }
}
