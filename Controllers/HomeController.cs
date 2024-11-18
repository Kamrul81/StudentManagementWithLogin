using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using withlogin.Models;

namespace withlogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            // Check if user is logged in by looking for the session variable
            var userName = HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(userName))
            {
                // If the user is not logged in, redirect them to the login page
                return RedirectToAction("Login", "Account");
            }


            return View();
        }

        public IActionResult Privacy()
        {
            // Check if user is logged in by looking for the session variable
            var userName = HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(userName))
            {
                // If the user is not logged in, redirect them to the login page
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
