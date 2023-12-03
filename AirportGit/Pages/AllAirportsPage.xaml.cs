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
    /// Логика взаимодействия для AllAirportsPage.xaml
    /// </summary>
    public partial class AllAirportsPage : Page
    {
        public static List<Flyghtport> flyghtports = new List<Flyghtport>();
        public static List<City> cities { get; set; }
        City contextCity;
        public AllAirportsPage(City city)
        {
            InitializeComponent();
            contextCity = city;
            InitializeDataInPage();
            this.DataContext = this;
            Refresh();
        }

        public void InitializeDataInPage()
        {
            cities = new List<City>(DBConnection.airportEntities.City.ToList());
            flyghtports = new List<Flyghtport>(DBConnection.airportEntities.Flyghtport.ToList().Where(x => x.IDCity == contextCity.IDCity));
            FlyghtportLv.ItemsSource = new List <Flyghtport>(DBConnection.airportEntities.Flyghtport.ToList());
            this.DataContext = this;
        }
        private void Refresh() //Обновление листа
        {
            FlyghtportLv.ItemsSource = new List<Flyghtport>(DBConnection.airportEntities.Flyghtport.ToList().Where(i => i.IDCity == contextCity.IDCity));
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
