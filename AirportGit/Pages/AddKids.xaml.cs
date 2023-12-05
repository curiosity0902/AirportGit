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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AirportGit.DB;

namespace AirportGit.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddKids.xaml
    /// </summary>
    public partial class AddKids : Page
    {
        public static List<Client> clients { get; set; }
        public static List<Flight> flights { get; set; }

        public static List<Ticket> tickets = new List<Ticket>();

        public static Ticket ticket = new Ticket();
        public static Client client = new Client();

        Flight contextFlight;
        public AddKids(Flight flight)
        {
            InitializeComponent();
            clients = DBConnection.airportEntities.Client.ToList();
            flights = DBConnection.airportEntities.Flight.ToList();
            contextFlight = flight;
            InitializeDataInPage();
            this.DataContext = this;
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddWorkerBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SurnameTB.Text) || string.IsNullOrWhiteSpace(NameTB.Text) || string.IsNullOrWhiteSpace(PatronymicTB.Text) ||
                        DateOfBirthDP.SelectedDate == null)
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    client.Surname = SurnameTB.Text.Trim();
                    client.Name = NameTB.Text.Trim();
                    client.Patronymic = PatronymicTB.Text.Trim();
                    if (DateOfBirthDP.SelectedDate != null && (DateTime.Now - (DateTime)DateOfBirthDP.SelectedDate).TotalDays > 365 * 14 + 3)
                    {
                        MessageBox.Show("По тарифу ребенок могут ездить только пассажиры младше 14 лет.");
                    }
                    else
                    {
                        client.DateOfBirth = DateOfBirthDP.SelectedDate;
                    }

                    DBConnection.airportEntities.Client.Add (client);
                    DBConnection.airportEntities.SaveChanges();
                    NavigationService.GoBack();
                }
            }
            catch
            {
                MessageBox.Show("Заполните все поля!");
            }
        }
        public void InitializeDataInPage()
        {

            int allseats = (int)contextFlight.Airplane.AirplaneModel.CountSeats;
            int count = 0;
            int result = 0;

            for (int i = 0; i < tickets.Count; i++)
            {
                if (tickets[i].IDFlight == contextFlight.IDFlight)
                {
                    count++;
                }

            }

            result = allseats - count - 1;
            CountSeatsTBl.Text = result.ToString();
        }

        }
    }
