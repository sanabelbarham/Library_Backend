using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class UserController : Controller
    {
        private readonly LibraryContext _context;
        public UserController(LibraryContext context) => _context = context;
        public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Account");

            var user = _context.Users.Find(userId);
            return View("Index",User); 
        }

        public IActionResult Details()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Account");

            var user = _context.Users.Find(userId);
            return View(user);
        }

        public IActionResult ChangeUserPassword()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
                return RedirectToAction("Login", "Account");
            return View( "ChangeUserPassword", User);
        }

        [HttpPost]
        public IActionResult ChangePassword(string currentPassword, string newPassword, string confirmPassword)
        {
            int userId = (int)HttpContext.Session.GetInt32("UserId");
            var user = _context.Users.Find(userId);

            if (user.Password != currentPassword)
            {
                ViewBag.Error = "Current password is incorrect.";
                return View("ChangeUserPassword",User);
            }

            if (newPassword != confirmPassword)
            {
                ViewBag.Error = "New password and confirmation do not match.";
                return View("ChangeUserPassword", User);
            }

            user.Password = newPassword;
            _context.SaveChanges();
            ViewBag.Message = "Password changed successfully!";

            //login out 
            HttpContext.Session.Clear();
            //return to the login view

            return RedirectToAction("Login","Account");
        }
    }
}
