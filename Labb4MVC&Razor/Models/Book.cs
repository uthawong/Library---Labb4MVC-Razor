using System.ComponentModel.DataAnnotations;

namespace Labb4MVC_Razor.Models
{
    public enum BookGenre
    {
        //0,1,2,3,4
        Children, 
        History, 
        SciFi, 
        Romance, 
        Thriller
    }
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string BookTitle { get; set; }

        [Required]
        public string BookAuthor { get; set; }

        [Required]
        public BookGenre BookGenre { get; set; }

        [Required]
        public int NumberOfBooks { get; set; }

        public virtual ICollection<BookBorrow>? BookBorrows { get; set; }
    }
}