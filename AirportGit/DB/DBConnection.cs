using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportGit.DB
{
    internal class DBConnection
    {
        // База данных Аня
        public static AirportEntities1 airportEntities = new AirportEntities1();

        //База данных Варвары (Model 04)
        //public static Airport03Entities1 airportEntities = new Airport03Entities1();


        // База данных Ренат
        //public static AirportEntities airportEntities = new AirportEntities();


        public static Worker loginedWorker;
        public static Client loginedClient;

        public static Worker selectedForEditWorker;
        public static Flight selectedForFlight;
    }
}

