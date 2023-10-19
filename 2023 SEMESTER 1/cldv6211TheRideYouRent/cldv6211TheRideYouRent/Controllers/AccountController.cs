using Microsoft.AspNetCore.Mvc;
using cldv6211TheRideYouRent.Services;

namespace cldv6211TheRideYouRent.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private AccountService accountService;

        public AccountController(AccountService _accountService)
        {
            accountService = _accountService;
        }

        [Route("")]
        [Route("~/")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string username, string password)
        {
            var account = accountService.Login(username, password);
            if (account != null)
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("Welcome");
            }else
            {
                ViewBag.msg = "Invalid";
                return View("Index");
            }
        }
        [Route("welcome")]
        public IActionResult Welcome()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            return View("Welcome");
        }

        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return View("Index");
        }
    }
}
