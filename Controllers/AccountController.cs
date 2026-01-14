using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
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
            List<User> users = _context.Users.ToList();
            foreach (var u in users)
            {
                if (user.Email == u.Email)
                {
                    if (user.Password == u.Password)
                    {
                        HttpContext.Session.SetInt32("UserId", u.UserId);//here i saved the id for the user 
                        //who loged in 

                        return RedirectToAction("Index","Book");
                    }
                }   
            }
            return RedirectToAction("Login","Account", new { error = "Invalid email or password." });
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            User AddedUser = new User()
            {
                FullName = user.FullName,
                Email = user.Email,
                Password = user.Password
            };

            _context.Users.Add(AddedUser);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Login", "Account");
        }



    }
}
