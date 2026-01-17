using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class BookController : Controller
    {
<<<<<<< Updated upstream
        private readonly LibraryContext _context;
        public BookController(LibraryContext context) => _context = context;

        // التحقق من تسجيل الدخول
        private bool CheckLogin() => HttpContext.Session.GetInt32("UserId") != null;

        // عرض جميع الكتب
        public IActionResult Index()
        {
            if (!CheckLogin())
                return RedirectToAction("Login", "Account", new { error = "Please login first." });

            var books = _context.Books.ToList();
            return View(books);
=======
        private bool CheckLogin()
        {
            //here i want to check if the one who is trying to access this view is loged in or not
            //by getting the sesion with the UserId and see if it is null
            //then no one loged in if not null then he accualy logen in
            //and a secction with his id is created 
            return HttpContext.Session.GetInt32("UserId") != null;
        }
        
        public IActionResult Index()
        {
            if (!CheckLogin())
            {
                //to senf the error to the Login action in the Login view the message wil be displayed

                return RedirectToAction("Login", "Account", new { error = "Please login first to access the books page." });
            }
            //here i store the Id foe the user who loged in for later use 
            //eg. to get the user details info and so on 
            int UserId = (int)HttpContext.Session.GetInt32("UserId");
            return View();
>>>>>>> Stashed changes
        }

        // البحث بالعنوان
        public IActionResult Search(string searchKey)
        {
            var books = _context.Books
                                .Where(b => b.Title.ToLower().Contains(searchKey.ToLower()))
                                .ToList();
            return View("Index", books);
        }

        // البحث بالكاتب
        public IActionResult SearchByAuthor(string authorName)
        {
            var books = _context.Books
                                .Where(b => b.Author.ToLower().Contains(authorName.ToLower()))
                                .ToList();
            return View("Index", books);
        }
    }
}
