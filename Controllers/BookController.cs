using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private bool CheckLogin()
        {
            return HttpContext.Session.GetInt32("UserId") != null;
        }
        
        public IActionResult Index()
        {
            if (!CheckLogin())
            {
                return RedirectToAction("Login", "Account", new { error = "Please login first to access the books page." });
            }
            int UserId = (int)HttpContext.Session.GetInt32("UserId");
            return View();
        }



    }
}
