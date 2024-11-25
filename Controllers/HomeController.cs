using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using StudentManagementWithLogin.Models;

namespace StudentManagementWithLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Private method to check if the user is logged in
        private bool IsUserLoggedIn()
        {
            var userName = HttpContext.Session.GetString("UserName");
            return !string.IsNullOrEmpty(userName);
        }

        public IActionResult Index()
        {
            if (!IsUserLoggedIn())
            {
                // If the user is not logged in, redirect them to the login page
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            if (!IsUserLoggedIn())
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
