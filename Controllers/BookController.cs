using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryContext _context;

        public BookController(LibraryContext context)
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

        // Search by title
        public IActionResult Search(string searchKey)
        {
            var books = _context.Books
                .Where(b => b.Title.ToLower().Contains(searchKey.ToLower()))
                .ToList();

            return View("Index", books);
        }

        // Search by author
        public IActionResult SearchByAuthor(string authorName)
        {
            var books = _context.Books
                .Where(b => b.Author.ToLower().Contains(authorName.ToLower()))
                .ToList();

            return View("Index", books);
        }
    }
}
