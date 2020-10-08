using System;
using System.Collections.Generic;
using System.Linq;
using Workshop5.Rev2.Data.Domain;

namespace Workshop5.Rev2.BLL
{
    public class BookingsManager
    {
        public static void Add(Bookings booking)
        {
            var context = new TravelExperts_Group3Context();
            context.Bookings.Add(booking);
            context.SaveChanges();
        }

        //Create a Bookings object
        public static Bookings CreateBooking(int id, int custId)
        {
            Bookings booking = new Bookings
            {
                PackageId = id,
                BookingDate = DateTime.Now,
                CustomerId = custId,
                BookingNo = RandomString(6)
            };
            return booking;
        }


        private static Random random = new Random();

        //method to create random alphanumeric string
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //retrieves booking information for a customer
        public static List<int> GetBookingByCustomer(int CustomerId)
        {
            var context = new TravelExperts_Group3Context();

            List<int> pID = (from b in context.Bookings
                             where b.CustomerId == CustomerId
                             select Convert.ToInt32(b.PackageId)).ToList();
            return pID; // returns package ids selected by customer

        }
    }
}
