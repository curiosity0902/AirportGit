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

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                if (DepartureDateDP.SelectedDate == null || DepartureTimeTb.Text.Trim() == "" ||
                    ArivalDateDP.SelectedDate == null || ArivalTimeTb.Text.Trim() == "" ||
                    StartFlyghtportCb.SelectedIndex == -1 || EndFlyghtportCb.SelectedIndex == -1 ||
                    AirplaneCb.SelectedIndex == -1 || StatusCb.SelectedIndex == -1 || PriceTb.Text.Trim() == "")
                {
                    error.AppendLine("Заполните все поля");
                }
                if(WorkerList1Cb.SelectedIndex == -1 && WorkerList2Cb.SelectedIndex == -1 &&
                    WorkerList3Cb.SelectedIndex == -1)
                {
                    error.AppendLine("Выберите бортпроводника");
                }

                if(error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    Flight flight = new Flight();
                    DateTime d = (DateTime)DepartureDateDP.SelectedDate;
                    int hour = int.Parse(DepartureTimeTb.Text.Split(':')[0]);
                    int minute = int.Parse(DepartureTimeTb.Text.Split(':')[1]);
                    DateTime dateTime = new DateTime(d.Year, d.Month, d.Day, hour, minute, 0);
                    flight.DepartureDate = dateTime;

                    d = (DateTime)ArivalDateDP.SelectedDate;
                    hour = int.Parse(ArivalTimeTb.Text.Split(':')[0]);
                    minute = int.Parse(ArivalTimeTb.Text.Split(':')[1]);
                    dateTime = new DateTime(d.Year, d.Month, d.Day, hour, minute, 0);
                    flight.ArivalDate = dateTime;

                    flight.IDFlyghport1 = (StartFlyghtportCb.SelectedItem as Flyghtport).IDFlyghtport;
                    flight.IDFlyghtport = (EndFlyghtportCb.SelectedItem as Flyghtport).IDFlyghtport;
                    if (worker1 != null)
                        flight.IDBortworker1 = worker1.IDWorker;
                    if(worker2 !=  null)
                        flight.IDBortworker2 = worker2.IDWorker;
                    if(worker3 != null)
                        flight.IDBortworker3 = worker3.IDWorker;
                    flight.IDFlightStatus = (StatusCb.SelectedItem as FlightStatus).IDFlightStatus;
                    flight.IDAirplane = (AirplaneCb.SelectedItem as Airplane).IDAirplane;
                    flight.Price = int.Parse(PriceTb.Text);
                    DBConnection.airportEntities.Flight.Add(flight);
                    DBConnection.airportEntities.SaveChanges();
                    NavigationService.Navigate(new FlightsPage());
                }
            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
            }
        }
    }
}
