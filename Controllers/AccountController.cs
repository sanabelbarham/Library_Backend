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
<<<<<<< Updated upstream
                HttpContext.Session.SetInt32("UserId", u.UserId);
                return RedirectToAction("Index", "Book");
            }

            return RedirectToAction("Login", new { error = "Invalid email or password." });
=======
                if (user.Email == u.Email)
                {
                    if (user.Password == u.Password)
                    {
                        //if the user logied in then take his id from the DB and make a seesion with it
                        //and then go to the Index in side the Book controller
                        HttpContext.Session.SetInt32("UserId", u.UserId);//here i saved the id for the user 
                        //who loged in 

                        return RedirectToAction("Index","Book");
                    }
                }   
            }
            //to senf the error to the Login action in the Login view the message wil be displayed
            return RedirectToAction("Login","Account", new { error = "Invalid email or password." });
>>>>>>> Stashed changes
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
        {//delete the id stored in the session for the user who loged in 
            //to sigin him out 
           
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Login");
        }
    }
}
