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
        //public static AirportEntities1 airportEntities = new AirportEntities1();

        //База данных Варвары (Model 13)
        public static Airport05EntitiesV02 airportEntities = new Airport05EntitiesV02();


        // База данных Ренат
        //public static AirportEntities22 airportEntities = new AirportEntities22();


        public static Worker loginedWorker;
        public static Client loginedClient;

        public static Worker selectedForEditWorker;
        public static Flight selectedForFlight;
    }
}

