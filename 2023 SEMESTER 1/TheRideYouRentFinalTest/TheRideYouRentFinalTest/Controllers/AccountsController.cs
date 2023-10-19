using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TheRideYouRentFinalTest.Models;


namespace TheRideYouRentFinalTest.Controllers
{
    public class AccountsController : Controller
    {
        TheRideYouRentDBTestEntities entity = new TheRideYouRentDBTestEntities();
        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel credentials)
        {
            bool userExist = entity.InspectorLogins.Any(x => x.Email == credentials.Email && x.Passcode == credentials.Password);
            InspectorLogin u = entity.InspectorLogins.FirstOrDefault(x => x.Email == credentials.Email && x.Passcode == credentials.Password);

            if (userExist)
            {
                FormsAuthentication.SetAuthCookie(u.Username, false);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Username or Password does not match");
            return View();
        }

        [HttpPost]
        public ActionResult Signup(InspectorLogin userinfo)
        {
            entity.InspectorLogins.Add(userinfo);
            entity.SaveChanges();
            return RedirectToAction("Login");
          }

       
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}