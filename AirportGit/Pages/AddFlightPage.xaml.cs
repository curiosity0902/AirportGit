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

        public AddFlightPage()
        {
            InitializeComponent();
            FlyghtportList = new List<Flyghtport>(DBConnection.airportEntities.Flyghtport.ToList());
            flightStatuses = new List<FlightStatus>(DBConnection.airportEntities.FlightStatus.ToList());
            airplaneList = new List<Airplane>(DBConnection.airportEntities.Airplane.ToList());
            this.DataContext = this;
        }

    }
}
