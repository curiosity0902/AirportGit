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
        public static Worker loggedWorker;

        public AllWorkersPage()
        {
            InitializeComponent();
            loggedWorker = DBConnection.loginedWorker;
            workers = DBConnection.airportEntities.Worker.ToList();
            this.DataContext = this;
            Refresh();
            CheckConditionAndToggleButtonVisibility();
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
                NavigationService.Navigate(new EditWorkerPage(WorkersLV.SelectedItem as Worker));
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
        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTB.Text.Length > 0)

                WorkersLV.ItemsSource = DBConnection.airportEntities.Worker.Where(i => i.Surname.Contains(SearchTB.Text.Trim()) || i.Name.Contains(SearchTB.Text.Trim()) || i.Patronymic.Contains(SearchTB.Text.Trim())).ToList();

            else
                WorkersLV.ItemsSource = new List<Worker>(DBConnection.airportEntities.Worker.ToList());
        }
        private void CheckConditionAndToggleButtonVisibility()
        {
            if (loggedWorker.IDPosition == 4)
            {
                EditWorkerBTN.Visibility = Visibility.Visible;
                AddWorkerBTN.Visibility = Visibility.Visible;
                DeleteWorkerBTN.Visibility = Visibility.Visible;
            }
            else
            {
                EditWorkerBTN.Visibility = Visibility.Collapsed;
                AddWorkerBTN.Visibility = Visibility.Collapsed;
                DeleteWorkerBTN.Visibility = Visibility.Collapsed;
            }
        }
    }
}
