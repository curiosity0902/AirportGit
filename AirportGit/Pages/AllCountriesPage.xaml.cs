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
    /// Логика взаимодействия для AllCountriesPage.xaml
    /// </summary>
    public partial class AllCountriesPage : Page
    {
        public static List<Country> countries { get; set; }
        public AllCountriesPage()
        {
            InitializeComponent();
            countries = new List<Country>(DBConnection.airportEntities.Country.ToList());
            CountiesLv.ItemsSource = new List<Country>(DBConnection.airportEntities.Country.ToList());
            this.DataContext = this;
        }

        private void CountiesLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CountiesLv.SelectedItem is Country country)
            {
                CountiesLv.SelectedItem = null;
                NavigationService.Navigate(new AllCitiesPage(country));
            }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DBConnection.loginedWorker != null)
            {
                NavigationService.Navigate(new MainMenuWorkerPage());
            }

            if (DBConnection.loginedClient != null)
            {
                NavigationService.Navigate(new MainMenuClientPage());
            }
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (SearchTB.Text.Length > 0)

                CountiesLv.ItemsSource = DBConnection.airportEntities.Country.Where(i => i.Nazvanie.ToLower().StartsWith(SearchTB.Text.Trim().ToLower())).ToList();

            else
                CountiesLv.ItemsSource = new List<Country>(DBConnection.airportEntities.Country.ToList());
        }
    }
}
