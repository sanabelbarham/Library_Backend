using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class ApplicationDbContext:DbContext
    {
       public DbSet<Book> Books { get; set; }
       public  DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        


    }
}
