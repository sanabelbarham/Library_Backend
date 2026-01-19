using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]

        public string Title { get; set; }

        [Required]

        public string Author { get; set; }
        public int ?UserId { get; set; }
        [ForeignKey("UserId")]
        public User ?User { get; set; }


    }
}
