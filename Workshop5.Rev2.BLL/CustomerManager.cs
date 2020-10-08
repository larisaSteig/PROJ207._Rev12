using System.Collections.Generic;
using System.Linq;
using Workshop5.Rev2.Data.Domain;

namespace Workshop5.Rev2.BLL
{
    public class CustomerManager
    {
        public static Customers Authenticate( string username, string password)
        {
            var db = new TravelExperts_Group3Context();
            var customer = db.Customers.SingleOrDefault(m => m.CustUserName == username &&
            m.CustPassword == password);
            return customer;
        }

        public static bool checkCustomerExist(string username)
        {
            var db = new TravelExperts_Group3Context();
            var exists = db.Customers.Any(x => x.CustUserName == username);
            if (!exists) return true;
            else return false;
        }
        //@*coded by Larisa Steig*@
        public static List<Customers> GetAll()
        {
            var context = new TravelExperts_Group3Context();
            var customers = context.Customers.ToList();
            return customers;
        }

        public static List<Customers> GetCustomer()
        {
            var context = new TravelExperts_Group3Context();
            var customers = context.Customers.ToList();
            return customers;
        }


        //@*coded by Larisa Steig*@
        public static Customers FindCustomerId(string name)
        {
            var context = new TravelExperts_Group3Context();
            var customer = (from m in context.Customers
                            where m.CustUserName == name
                            select m).Single();
            return customer;
        }
        //@*coded by Larisa Steig*@
        public static Customers Find(int id)
        {
            var context = new TravelExperts_Group3Context();
            var owner = context.Customers.Find(id);
            return owner;
        }
        //@*coded by Larisa Steig*@
        public static void update(Customers user)
        {
            var context = new TravelExperts_Group3Context();

            var originalCustomer = context.Customers.Find(user.CustomerId);
            originalCustomer.CustFirstName = user.CustFirstName;
            originalCustomer.CustLastName = user.CustLastName;
            originalCustomer.CustAddress= user.CustAddress;
            originalCustomer.CustCity = user.CustCity;
            originalCustomer.CustCountry = user.CustCountry;
            originalCustomer.CustEmail = user.CustEmail;
            originalCustomer.CustBusPhone = user.CustBusPhone;
            originalCustomer.CustHomePhone = user.CustHomePhone;
            originalCustomer.CustProv = user.CustProv;
            originalCustomer.CustPostal = user.CustPostal;
            context.SaveChanges();
        }


    }
}
