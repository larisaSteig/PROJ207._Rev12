using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workshop5.Rev2.Data.Domain;

namespace Workshop5.Rev2.BLL
{
    public class AgentManager
    { //@*coded by Larisa Steig*@
        public static Agents Authenticate(string username, string password)
        {
            var db = new TravelExperts_Group3Context();
            var customer = db.Agents.SingleOrDefault(m => m.AgtEmail == username && m.AgtPassword == password);
            return customer;
        }

    }
}
