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
    /// Логика взаимодействия для AllWorkersPage.xaml
    /// </summary>
    public partial class AllWorkersPage : Page
    {
        public static List<Worker> workers { get; set; }

        public AllWorkersPage()
        {
            InitializeComponent();
            workers = DBConnection.airportEntities.Worker.ToList();
            this.DataContext = this;
            Refresh();
        }
        private void Refresh()
        {
            WorkersLV.ItemsSource = DBConnection.airportEntities.Worker.ToList();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        private void AddWorkerBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddWorkerPage());
        }

        private void EditWorkerBTN_Click(object sender, RoutedEventArgs e)
        {
            if (WorkersLV.SelectedItem is Worker)
            {
                DBConnection.selectedForEditWorker = WorkersLV.SelectedItem as Worker;
                //NavigationService.Navigate(new EditWorkerPage());
            }
        }

        private void DeleteWorkerBTN_Click(object sender, RoutedEventArgs e)
        {
            if (WorkersLV.SelectedItem is Worker work)
            {
                DBConnection.airportEntities.Worker.Remove(work);
                DBConnection.airportEntities.SaveChanges();
            }
            Refresh();
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuWorkerPage());
        }
    }
}
