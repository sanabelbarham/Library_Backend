using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Check if user is logged in
        private bool CheckLogin()
        {
            return HttpContext.Session.GetInt32("UserId") != null;
        }

        // Show all books
        public IActionResult Index()
        {
            if (!CheckLogin())
            {
                return RedirectToAction(
                    "Login",
                    "Account",
                    new { error = "Please login first." }
                );
            }

            var books = _context.Books.ToList();
            return View(books);
        }

        public IActionResult Search(string searchKey)
        {
            var books = _context.Books
                .Where(b => b.Title.ToLower().Contains(searchKey.ToLower()))
                .ToList();

            return View("Index", books);
        }

 
        public IActionResult SearchByAuthor(string authorName)
        {
            var books = _context.Books
                .Where(b => b.Author.ToLower().Contains(authorName.ToLower()))
                .ToList();

            return View("Index", books);
        }

        public IActionResult Borrow(int id)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var book = _context.Books.FirstOrDefault(b => b.BookId == id);

            if (book == null)
                return NotFound();

        
            if (book.UserId != null)
            {
                ViewBag.Error = "This book is already borrowed.";
                return RedirectToAction("Index");
            }

            book.UserId = userId;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
