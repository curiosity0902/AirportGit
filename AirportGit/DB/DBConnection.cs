using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportGit.DB
{
    internal class DBConnection
    {
        public static AirportEntities1 airportEntities = new AirportEntities1();
        public static Worker loginedWorker;
        public static Client loginedClient;
    }
}

