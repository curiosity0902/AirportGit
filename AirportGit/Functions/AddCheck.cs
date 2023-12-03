using AirportGit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportGit.Functions
{
    public class AddCheck
    {
        public static bool SameEmail(string email)
        {
            Client client = new List<Client>(DBConnection.airportEntities.Client.ToList()).FirstOrDefault(x => x.Email.Trim() == email.Trim());
            if (client != null)
            {
                return true;
            }
            else
            {
                Worker worker = new List<Worker>(DBConnection.airportEntities.Worker.ToList()).FirstOrDefault(x => x.Email.Trim() == email.Trim());
                if (worker != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
