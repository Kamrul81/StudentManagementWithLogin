using Microsoft.AspNetCore.Mvc;
using withlogin.Models;

namespace withlogin.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }

            return View(user);
        }


        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {
            var existingUser = _context.Users
                .FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);

            if (existingUser != null)
            {
                // Set session or cookie for authentication
                HttpContext.Session.SetString("UserName", existingUser.UserName);
                HttpContext.Session.SetString("Email", existingUser.Email);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid username or password";
                return RedirectToAction("Login");
            }
        }

        // POST: /Account/Logout
        [HttpPost]
        public IActionResult Logout()
        {
            // Clear the session to log the user out
            HttpContext.Session.Clear();

            // Redirect the user to the login page
            return RedirectToAction("Login");
        }

    }
}
