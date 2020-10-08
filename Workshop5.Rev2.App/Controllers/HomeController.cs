using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Workshop5.Rev2.App.Models;
using Workshop5.Rev2.BLL;


namespace Workshop5.Rev2.App.Controllers
{ /*Home page coding and CSS is done by Larisa Steig*/
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            var db = PackageManager.GetAll();
            var PackageToShow = db.Select(d => new PackageViewModel
            { 
              PackageId =d.PackageId,
              PkgName = d.PkgName,
              
              Photo = d.Photo}).ToList();
              return View(PackageToShow);
        }

        // GET: PackageController/Details/5
        
        public ActionResult Details(int id)
        {
            var packages = PackageManager.GetAll();
            var package = packages.SingleOrDefault(m => m.PackageId == id);
            return View(package);
        }
        public ActionResult Data(int id)

        {
            var packages = PackageManager.GetAll();
            var package = packages.SingleOrDefault(m => m.PackageId == id);
            return PartialView("_PackageDetails", package);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
