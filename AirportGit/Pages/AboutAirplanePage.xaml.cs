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
    /// Логика взаимодействия для AboutAirplanePage.xaml
    /// </summary>
    public partial class AboutAirplanePage : Page
    {
        public static List<AirplaneModel> airplaneModels = new List<AirplaneModel>();
        public static List<Airplane> airplanes { get; set; }
        Airplane contextAirplane;
        public AboutAirplanePage(Airplane airplane)
        {
            InitializeComponent();
            contextAirplane = airplane;
            airplanes = new List <Airplane> (DBConnection.airportEntities.Airplane.ToList());
            airplaneModels = new List<AirplaneModel> (DBConnection.airportEntities.AirplaneModel.ToList().Where(x => x.NumberModel == contextAirplane.IDAirplaneModel));
            this.DataContext = this;

            AirplaneModel a = DBConnection.selectedForAboutAirplane;
            DecodingTB.Text = a.Decoding;
            //MaxSpeedTB 
        }

    }
}
