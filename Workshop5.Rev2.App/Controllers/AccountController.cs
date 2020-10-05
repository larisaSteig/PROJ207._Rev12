using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workshop5.Rev2.App.Models;
using Workshop5.Rev2.BLL;
using Workshop5.Rev2.Data.Domain;

using System.Web.Providers.Entities;
using Workshop5.Rev2.App._classes;

namespace Workshop5.Rev2.App.Controllers
{
    public class AccountController : Controller
    {
       
        public IActionResult Login(string returnUrl = null)
        {
            if (returnUrl != null)
                TempData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(Customers customer)
        {
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
                ViewBag.userId = user.CustomerId;
                return RedirectToAction("Index", "Home");
            }
              
            else
                return Redirect(TempData["ReturnUrl"].ToString());

        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Index", "Home");
        }

         

        public IActionResult AccessDenied()
        {
            return View();
        }
        //************************* Registration *****************************//
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
            _reg.Add(rv);
            _reg.SaveChanges();
            ViewBag.message = "Customer " + rv.CustUserName + " Has Been Saved Successfully!";
            return View("Login");
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
        public ActionResult Edit(Customers customer)
        {
            try
            {
                //call the OwnerManager to add
                CustomerManager.update(customer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }

}

