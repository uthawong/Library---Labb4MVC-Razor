using System.ComponentModel.DataAnnotations;

namespace Labb4MVC_Razor.Models
{
    public enum FavoriteGenre
    {
        //0,1,2,3,4
        Children, 
        History, 
        SciFi, 
        Romance, 
        Thriller
       
    }
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [MinLength(16, ErrorMessage = "Customer's name can't be shorter than 16 characters.")]
        [MaxLength(50, ErrorMessage = "Customer's name can't be longer than 50 characters.")]
        public string CustomerName { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Customer's e-mail address can't be shorter than 5 characters")]
        [MaxLength(100, ErrorMessage = "Customer's e-mail address can't be longer than 100 characters")]
        public string CustomerEmail { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Customer's address can't be shorter than 5 characters.")]
        [MaxLength(100, ErrorMessage = "Customer's address can't be longer than 100 characters")]
        public string CustomerAddress { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Phone number must be at least 10 digits")]
        [MaxLength(10, ErrorMessage = "Phone number must be at least 10 digits")]
        public string CustomerPhoneNumber { get; set; }

        public FavoriteGenre? FavoriteGenre { get; set; }

        public virtual ICollection<BookBorrow>? BookBorrows { get; set; }


    }
}