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
    /// Логика взаимодействия для AllAircompaniesPage.xaml
    /// </summary>
    public partial class AllAircompaniesPage : Page
    {
        public static List<Aircompany> aircompanies { get; set; }
        public AllAircompaniesPage()
        {
            InitializeComponent();
            aircompanies = new List<Aircompany>(DBConnection.airportEntities.Aircompany.ToList());
            AircompaniesLv.ItemsSource = new List<Aircompany>(DBConnection.airportEntities.Aircompany.ToList());
            this.DataContext = this;
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if(DBConnection.loginedWorker != null)
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
            {
                AircompaniesLv.ItemsSource = DBConnection.airportEntities.Aircompany.Where(i => i.Nazvanie.Contains(SearchTB.Text.Trim()));
            }
            else
            {
                AircompaniesLv.ItemsSource = new List<Aircompany>(DBConnection.airportEntities.Aircompany.ToList());
            }
        }
    }
}
