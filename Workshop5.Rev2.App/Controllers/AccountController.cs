using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workshop5.Rev2.App.Models;
using Workshop5.Rev2.BLL;
using Workshop5.Rev2.Data.Domain;


namespace Workshop5.Rev2.App.Controllers
{
    public class AccountController : Controller
    {
       /*Login is coded by Larisa Steig*/
        public IActionResult Login(string returnUrl = null)
        {
            if (returnUrl != null)
                TempData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(Customers customer)
        {
            var x =TempData["ReturnUrl"];
            var user = CustomerManager.Authenticate(customer.CustUserName, customer.CustPassword);
            // no user is found
            if (user == null) return View();
            // user is found
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.CustUserName),
                new Claim("Password", user.CustPassword)
            };
            // create the instance of ClaimsIdentity
           
            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity));

            //handle the return url
            if (TempData["ReturnUrl"] == null)
            {
             
                return RedirectToAction("Index", "Home");
            }
              
            else
                
                //return RedirectToAction("Index", "Home");
                return Redirect(TempData["ReturnUrl"].ToString());

        }

        public async Task<IActionResult> LogoutAsync(string returnUrl =null)
        {
            returnUrl = null;
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
        //************************* Create Registration *****************************//
        //Coded by: David Hahner

        private readonly Registration _reg;

        public AccountController(Registration reg)
        {
            _reg = reg;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RegistrationViewModel rv)
        {
            TempData["ReturnUrl"] = null;
            var username = rv.CustUserName;
            bool exists = CustomerManager.checkCustomerExist(username);
            if(exists == true)
            {
               
                _reg.Add(rv);
                _reg.SaveChanges();
                ViewBag.message = "Customer " + rv.CustUserName + " Has Been Saved Successfully!";
                //return View("Login");
                return RedirectToAction(nameof(Login));
            }
            else
            {
                ViewBag.message = "User name already exists!Please try again.";
                return View("Create"); 
            }
            
        }


        //**********************************************************************************//
        /**find customer ID and created an updated registration_Larisa Steig */
        public ActionResult Edit()
        {
            var userX = CustomerManager.FindCustomerId(User.Identity.Name);
            var user = CustomerManager.Find(userX.CustomerId);
            return View(user);
        }

        //POST: Owner/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customers user)
        {
            try
            {
               ViewBag.Id = user.CustomerId;
               CustomerManager.update(user);

               return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }

}

