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
        //recives an error message
        public IActionResult Login(string? error)
        {
         //   the error message store it inside the LoginError in the ViewBag
         //and it will be sent automaticly to the Login view 
         //you can specify it but since the view and action have the same names then it will be passed directly
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

        public IActionResult SignUp()
        { 
            return View();
        }


        [HttpPost]
        public IActionResult AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {//delete the id stored in the session for the user who loged in 
            //to sigin him out 
           
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Login");
        }
    }
}
