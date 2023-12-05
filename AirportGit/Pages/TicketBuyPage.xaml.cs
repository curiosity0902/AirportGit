using System;
using System.CodeDom;
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

        public static Ticket ticket = new Ticket();

        Flight contextFlight;
        public TicketBuyPage(Flight flight)
        {
            InitializeComponent();
            contextFlight = flight;
            this.DataContext = this;
            Refresh();
        }

        public void InitializeDataInPage()
        {
            tickets = DBConnection.airportEntities.Ticket.ToList();
            classReservations = DBConnection.airportEntities.ClassReservation.ToList();
            flights = DBConnection.airportEntities.Flight.ToList();
            this.DataContext = this;
            FlightTBl.Text = DBConnection.selectedForFlight.Flyghtport.City.Nazvanie.ToString() + " - " + DBConnection.selectedForFlight.Flyghtport1.City.Nazvanie.ToString();
            FlightDateTBl.Text = Convert.ToString(contextFlight.DepartureDate) + " - " + Convert.ToString(contextFlight.ArivalDate);
            CountSeatsTBl.Text = Convert.ToString(new List <Count_tickets>(DBConnection.airportEntities.);


        }

        public void Refresh()
        {
        //    if (ClassReservationCb.SelectedItem is ClassReservation classReservation)
        //    {
        //        var exam = contextFlight;
        //        exam.Ticket = classReservation.Ticket;
        //        var studentInList = tickets.FirstOrDefault(x => x.IDClassReservation == ticket.IDClassReservation);
    
        //    }


            int price = int.Parse(DBConnection.selectedForFlight.Price.ToString());

            var c = ClassReservationCb.SelectedItem as ClassReservation;

            if (ClassReservationCb.SelectedIndex > -1)
            {
           
                ticket.IDClassReservation = c.IDClassReservation;
            }


            
            if (ClassReservationCb.SelectedIndex == 0)
            {
                price = price + 950;
            }
            if (ClassReservationCb.SelectedIndex == 1)
            {
                price = price + 2000;
            }
            if (ClassReservationCb.SelectedIndex == 2)
            {
                price = price + 550;
            }
                CostTbl.Text = Convert.ToString(price);

                ticket.Cost = price;

            InitializeDataInPage();

        }

        private void BuyTicket_Click(object sender, RoutedEventArgs e)
        {

            ticket.IDClassReservation = ClassReservationCb.SelectedIndex + 1;
            ticket.IDFlight = contextFlight.IDFlight;
            ticket.IDClient = DBConnection.loginedClient.IDClient;
            //ticket.IDBaggage = 
            //ticket.DateOfBuy = DateOfBirthDP.SelectedDate;
            //ticket.Passport = PassportTB.Text.Trim();


                DBConnection.airportEntities.Ticket.Add(ticket);
                DBConnection.airportEntities.SaveChanges();
                NavigationService.Navigate(new MainMenuClientPage());
          
        }

        private void ClassReservationCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
