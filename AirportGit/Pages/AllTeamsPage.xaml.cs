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
    /// Логика взаимодействия для AllTeamsPage.xaml
    /// </summary>
    public partial class AllTeamsPage : Page
    {
        public static List<Worker> workers { get; set; }
        public static Worker loggedWorker;
        public static List<Team> teams { get; set; }

        public AllTeamsPage()
        {
            InitializeComponent();
            workers = new List<Worker>(DBConnection.airportEntities.Worker.ToList());
            teams = new List<Team>(DBConnection.airportEntities.Team.ToList());
            TeamLv.ItemsSource = new List<Team>(DBConnection.airportEntities.Team.ToList());
            Refresh();
            loggedWorker = DBConnection.loginedWorker;
            this.DataContext = this;
        }

        public void Refresh()
        {
            TeamLv.ItemsSource = DBConnection.airportEntities.Team.ToList();
        }
   
        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuWorkerPage());
        }
    }
}
