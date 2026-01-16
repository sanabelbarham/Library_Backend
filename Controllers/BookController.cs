using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class BookController : Controller
    {
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
