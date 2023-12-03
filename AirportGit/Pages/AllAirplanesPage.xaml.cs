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
    /// Логика взаимодействия для AllAirplanesPage.xaml
    /// </summary>
    public partial class AllAirplanesPage : Page
    {
        public static List<Airplane> airplanes { get; set; }
        public static List<Aircompany> aircompanies { get; set; }
        public static List<Team> teams { get; set; }
        public static List<AirplaneModel> airplaneModels { get; set; }
        public static List<Worker> workers { get; set; }


        public AllAirplanesPage()
        {
            InitializeComponent();
            airplanes = new List<Airplane>(DBConnection.airportEntities.Airplane.ToList());
            aircompanies = new List<Aircompany>(DBConnection.airportEntities.Aircompany.ToList());
            teams = new List<Team>(DBConnection.airportEntities.Team.ToList());
            airplaneModels = new List<AirplaneModel>(DBConnection.airportEntities.AirplaneModel.ToList());
            workers = new List<Worker>(DBConnection.airportEntities.Worker.ToList().Where(x => x.IDPosition == 1 || x.IDPosition == 6 || x.IDPosition == 3));
            AirplanesLv.ItemsSource = new List<Airplane>(DBConnection.airportEntities.Airplane.ToList());


        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuWorkerPage());
        }
    }
}
