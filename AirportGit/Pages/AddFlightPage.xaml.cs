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
    /// Логика взаимодействия для AddFlightPage.xaml
    /// </summary>
    public partial class AddFlightPage : Page
    {
        public static List<Flyghtport> FlyghtportList { get; set; }
        public static List<FlightStatus> flightStatuses { get; set; }
        public static List<Airplane> airplaneList { get; set; }
        public static List<Worker> workerList { get; set; }
        public static List<Worker> workerList1 { get; set; }
        public static List<Worker> workerList2 { get; set; }
        public static List<Worker> workerList3 { get; set; }

        public static Worker worker1 { get; set; } = null;
        public static Worker worker2 { get; set; } = null;
        public static Worker worker3 { get; set; } = null;

        public AddFlightPage()
        {
            InitializeComponent();
            FlyghtportList = new List<Flyghtport>(DBConnection.airportEntities.Flyghtport.ToList());
            flightStatuses = new List<FlightStatus>(DBConnection.airportEntities.FlightStatus.ToList());
            airplaneList = new List<Airplane>(DBConnection.airportEntities.Airplane.ToList());
            workerList = new List<Worker>(DBConnection.airportEntities.Worker.ToList().Where(x => x.Position.Nazvanie == "Бортпроводник"));
            workerList1 = workerList;
            workerList2 = workerList;
            workerList3 = workerList;
            this.DataContext = this;
        }

        private void Refresh()
        {
            WorkerList1Cb.ItemsSource = workerList1;
            WorkerList2Cb.ItemsSource = workerList2;
            WorkerList3Cb.ItemsSource = workerList3;
        }

        private void WorkerList1Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            worker1 = WorkerList1Cb.SelectedItem as Worker;
            List<Worker> filter = new List<Worker>();
            for (int i = 0; workerList.Count > i; i++)
            {
                if (workerList[i] != worker1 && workerList[i] != worker3)
                {
                    filter.Add(workerList[i]);
                }
            }
            workerList2 = filter;
            filter = new List<Worker>();
            for (int i = 0; workerList.Count > i; i++)
            {
                if (workerList[i] != worker1 && workerList[i] != worker2)
                {
                    filter.Add(workerList[i]);
                }
            }
            workerList3 = filter;
            Refresh();
        }

        private void WorkerList2Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            worker2 = WorkerList2Cb.SelectedItem as Worker;
            List<Worker> filter = new List<Worker>();
            for (int i = 0; workerList.Count > i; i++)
            {
                if (workerList[i] != worker2 && workerList[i] != worker3)
                {
                    filter.Add(workerList[i]);
                }
            }
            workerList1 = filter;
            filter = new List<Worker>();
            for (int i = 0; workerList.Count > i; i++)
            {
                if (workerList[i] != worker1 && workerList[i] != worker2)
                {
                    filter.Add(workerList[i]);
                }
            }
            workerList3 = filter;
            Refresh();
        }

        private void WorkerList3Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            worker3 = WorkerList3Cb.SelectedItem as Worker;
            List<Worker> filter = new List<Worker>();
            for (int i = 0; workerList.Count > i; i++)
            {
                if (workerList[i] != worker2 && workerList[i] != worker3)
                {
                    filter.Add(workerList[i]);
                }
            }
            workerList1 = filter;
            filter = new List<Worker>();
            for (int i = 0; workerList.Count > i; i++)
            {
                if (workerList[i] != worker1 && workerList[i] != worker3)
                {
                    filter.Add(workerList[i]);
                }
            }
            workerList2 = filter;
            Refresh();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FlightsPage());
        }
    }
}
