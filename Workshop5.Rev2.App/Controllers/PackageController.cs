using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workshop5.Rev2.BLL;
using Workshop5.Rev2.App.Models;
using Workshop5.Rev2.Data.Domain;

namespace Workshop5.Rev2.App.Controllers
{ /*Package Controller is coded by Larisa Steig*/
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


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Packages package)
        {
            try
            {
                //call the OwnerManager to add
                PackageManager.Add(package);

                return RedirectToAction(nameof(Details));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var package = PackageManager.Find(id);
            return View(package);
        }

        [HttpPost]
        public ActionResult Edit(Packages package)
        {
            try
            {
                //call the OwnerManager to add
                PackageManager.update(package);

                return RedirectToAction(nameof(Details));
            }
            catch
            {
                return View();
            }
        }


        public IActionResult PackageDetail()
        {
            return View();
        }
    }
}
