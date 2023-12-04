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
    /// Логика взаимодействия для TicketBuyPage.xaml
    /// </summary>
    public partial class TicketBuyPage : Page
    {
        public static List<Ticket> tickets = new List<Ticket>();
        public static List<ClassReservation> classReservations { get; set; }
        public static List<Flight> flights { get; set; }


        Flight contextFlight;
        public TicketBuyPage(Flight flight)
        {
            InitializeComponent();
            contextFlight = flight;
            InitializeDataInPage();
            this.DataContext = this;
            Refresh();
        }

        public void InitializeDataInPage()
        {
            //tickets = new List<Ticket>(DBConnection.airportEntities.Ticket.ToList().Where(x => x.IDClient == contextTicket.IDClient));
            //flights = new List<Flight>(DBConnection.airportEntities.Flight.ToList());
            tickets = DBConnection.airportEntities.Ticket.ToList();
            classReservations = DBConnection.airportEntities.ClassReservation.ToList();
            flights = DBConnection.airportEntities.Flight.ToList();
            this.DataContext = this;
            ClassReservationTBl.Text = DBConnection.airportEntities.ClassReservation.ToString();
                //DBConnection.loginedWorker.Patronymic.ToString();
        }

        public void Refresh()
        { 
                   
        }

        private void BuyTicket_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
