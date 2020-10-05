using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
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

        //public static void update(Customers customer)
        //{
        //    var context = new TravelExperts_Group3Context();
        //    var originalCustomer = context.Customers.Find(customer.CustomerId);
        //    originalCustomer.CustFirstName = customer.CustFirstName;
        //    originalCustomer.CustLastName = customer.CustLastName;
        //    originalCustomer.CustAddress = customer.CustAddress;
        //    originalCustomer.CustCity = customer.CustCity;
        //    originalCustomer.CustProv = customer.CustProv;
        //    originalCustomer.CustPostal = customer.CustPostal;
        //    originalCustomer.CustCountry = customer.CustCountry;
        //    originalCustomer.CustHomePhone = customer.CustHomePhone;
        //    originalCustomer.CustBusPhone = customer.CustBusPhone;
        //    originalCustomer.CustEmail = customer.CustEmail;
        //    originalCustomer.CustUserName = customer.CustUserName;
        //    originalCustomer.CustPassword = customer.CustPassword;
        //    context.SaveChanges();
        //}

        public static Customers FindCustomerId(string name)
        {
            var context = new TravelExperts_Group3Context();
            var customer = (from m in context.Customers
                            where m.CustUserName == name
                            select m).Single();
            return customer;
        }

        public static Customers Find(int id)
        {
            var context = new TravelExperts_Group3Context();
            var owner = context.Customers.Find(id);
            return owner;
        }

        public static void update(Customers customer)
        {
            var context = new TravelExperts_Group3Context();
            var originalOwner = context.Customers.Find(customer.CustomerId);
            originalOwner.CustFirstName = customer.CustFirstName;
            originalOwner.CustLastName = customer.CustLastName;
            context.SaveChanges();
        }


    }
}
