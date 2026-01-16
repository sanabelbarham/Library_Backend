using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<User>().HasData(
                  new User { UserId = 1, FullName = "shahd", Password = "123", Email = "s.ayasa@gmail.com" },
                   new User { UserId = 2, FullName = "Sanabel", Password = "456", Email = "s.barham@gmail.com" },
                   new User { UserId = 3, FullName = "ranin", Password = "789", Email = "r.kmail@gmail.com" },
                   new User { UserId = 4, FullName = "randa", Password = "432", Email = "r.ali@gmail.com" },
                   new User { UserId = 5, FullName = "malak", Password = "564", Email = "m.aref@gmail.com" },
                   new User { UserId = 6, FullName = "raghad", Password = "577", Email = "r.ayasa@gmail.com" },
                   new User { UserId = 7, FullName = "baylasan", Password = "363", Email = "b.ayasa@gmail.com" },
                   new User { UserId = 8, FullName = "leen", Password = "130", Email = "l.mashaqi@gmail.com" },
                   new User { UserId = 9, FullName = "shahed", Password = "325", Email = "s.shehab@gmail.com" },
                   new User { UserId = 10, FullName = "aseel", Password = "333", Email = "a.atiya@gmail.com" });

            modelBuilder.Entity<Book>().HasData(
                  new Book { BookId = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald" },
                  new Book { BookId = 2, Title = "The Sun Also Rises", Author = "Ernest Hemingway" },
                  new Book { BookId = 3, Title = "East of Eden ", Author = "John Steinbeck" },
                  new Book { BookId = 4, Title = "The House of Mirth", Author = "Edith Wharton" },
                  new Book { BookId = 5, Title = "A Time to Kill", Author = "John Grisham" },
                  new Book { BookId = 6, Title = "Vile Bodies", Author = "Evelyn Waugh" },
                  new Book { BookId = 7, Title = "A Scanner Darkly", Author = "Philip K. Dick" },
                  new Book { BookId = 8, Title = "Moab is my Washpot ", Author = "Stephen Fry" },
                  new Book { BookId = 9, Title = ". Number the Stars", Author = "Lois Lowry" },
                  new Book { BookId = 10, Title = " Brave New World", Author = "Aldous Huxley" });
        }
    }
}
