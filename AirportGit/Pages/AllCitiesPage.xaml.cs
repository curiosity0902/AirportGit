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
    /// Логика взаимодействия для AllCitiesPage.xaml
    /// </summary>
    public partial class AllCitiesPage : Page
    {
        public static List<City> cities { get; set; }
        public static List<Country> countries { get; set; }
        public AllCitiesPage()
        {
            InitializeComponent();
            cities = new List<City>(DBConnection.airportEntities.City.ToList());
            countries = new List<Country>(DBConnection.airportEntities.Country.ToList());
            CitiesLv.ItemsSource = new List<City>(DBConnection.airportEntities.City.ToList());
            this.DataContext = this;
        }
    }
}
