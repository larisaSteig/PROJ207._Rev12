using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workshop5.Rev2.BLL;
using Workshop5.Rev2.App.Models;

namespace Workshop5.Rev2.App.Controllers
{
    public class PackageController : Controller
    {
        // GET: PackageController
        public ActionResult Index()
        {
            var packages = PackageManager.GetAll();
            return View(packages);
        }

        // GET: PackageController/Details/5

        public ActionResult Details()
        {
            var packages = PackageManager.GetAll();
            return View(packages);
        }
        public ActionResult Data(int id)

        {
            var packages = PackageManager.GetAll();
            var package = packages.SingleOrDefault(m => m.PackageId == id);
            return PartialView("_PackageDetails", package);

        }

       
        // GET: PackageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PackageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PackageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PackageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PackageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PackageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //public IActionResult Index()
        //{
        //    var properties = PackageManager.GetAll();
        //    var viewModels = properties.Select(p => new PackageViewModel
        //    {
        //        PackageId = p.PackageId,
        //        PkgName = p.PkgName,
        //        PkgStartDate = p.PkgStartDate,
        //        PkgEndDate = p.PkgEndDate,
        //        PkgDesc = p.PkgDesc,
        //        PkgBasePrice = p.PkgBasePrice,
        //        PkgAgencyCommission = p.PkgAgencyCommission,
        //        //Bookings =p.Bookings.BookingId,
        //        //PackagesProductsSuppliers =p.PackagesProductsSuppliers
        //    });
        //    return View(viewModels);
        //}

        public IActionResult PackageDetail()
        {
            return View();
        }
    }
}
