using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workshop5.Rev2.BLL;
using Workshop5.Rev2.Data.Domain;

namespace Workshop5.Rev2.App.Controllers
{
    public class BookingsController : Controller
    {
        TravelExperts_Group3Context db = new TravelExperts_Group3Context();
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Booking(int Packageid)
        {
            var userX = CustomerManager.FindCustomerId(User.Identity.Name);
            
            int CustomerId = userX.CustomerId;
            //var package = PackagesManager.GetPackagesById(Packageid);
            //if (package == null)
            //{
            //    return NotFound();
            //}

            //create a booking object & add to database
            var booking = BookingsManager.CreateBooking(Packageid, CustomerId);
            BookingsManager.Add(booking);

            //retrieve booking information from database for display
            var pId = BookingsManager.GetBookingByCustomer(CustomerId);
            decimal total = 0;
            var pck = new List<Packages>();
            foreach (int item in pId)
            {
                try
                {
                    var packageselected = PackageManager.GetPackagesById(item);
                    try
                    {
                        if (packageselected != null)
                        {

                            pck.Add(packageselected);
                            total += packageselected.PkgBasePrice;
                        }
                    }
                    catch
                    {
                        continue;
                    }

                }
                catch
                {
                    continue;
                }
            }
            ViewBag.Total = Math.Round((total), 2);
            ViewBag.selectedPackages = pck;
            // ViewBag.Package = package;
            ViewBag.CustomerId = CustomerId;
            return View();
        }
    }
}
