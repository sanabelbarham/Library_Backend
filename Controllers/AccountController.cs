using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Library.Controllers
{
    public class AccountController : Controller
    {
        private readonly LibraryContext _context;

        public AccountController(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Login(string? error)
        {
            ViewBag.LoginError = error;
            return View();
        }

        [HttpPost]
        public IActionResult CheckUser(User user)
        {
            var u = _context.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if (u != null)
            {
                HttpContext.Session.SetInt32("UserId", u.UserId);
                return RedirectToAction("Index", "Book");
            }

            return RedirectToAction("Login", new { error = "Invalid email or password." });
        }

        public IActionResult SignUp() => View();

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Login");
        }
    }
}
