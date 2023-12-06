using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
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
    /// Логика взаимодействия для AboutAirplanePage.xaml
    /// </summary>
    public partial class AboutAirplanePage : Page
    {
        public static List<AirplaneModel> airplaneModels = new List<AirplaneModel>();
        public static Airplane air{ get; set; }

        Airplane contextAirplane;
        public AboutAirplanePage(Airplane airplane)
        {
            InitializeComponent();
            contextAirplane = airplane;
            airplane = air;
            InitializeDataInPage();
            this.DataContext = this;

            //DecodingTB.Text = a.Decoding;
            //MaxSpeedTB 
        }
        public void InitializeDataInPage()
        {
                airplaneModels = new List<AirplaneModel>(DBConnection.airportEntities.AirplaneModel).ToList();
                this.DataContext = this;
                SpeedTBl.Text = DBConnection.selectedForAirplane.AirplaneModel.Speed.ToString() + " км/ч ";
                DecodingTB.Text = DBConnection.selectedForAirplane.AirplaneModel.Decoding.ToString();
                MaxLenghtTB.Text = DBConnection.selectedForAirplane.AirplaneModel.LenghtFly.ToString() + " м";
                CountSeatsTB.Text = "  " + DBConnection.selectedForAirplane.AirplaneModel.CountSeats.ToString();
                MaxWeightTlB.Text = DBConnection.selectedForAirplane.AirplaneModel.MaxWeight.ToString() + " кг";


        }

            private void BackBtn_Click(object sender, RoutedEventArgs e)
            {
                NavigationService.GoBack();
            }
    }
}
