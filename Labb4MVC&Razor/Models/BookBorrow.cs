using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Labb4MVC_Razor.Models
{
    public enum BorrowStatus
    {
        //0,1
        Returned, 
        NotReturned
    }
    public class BookBorrow
    {
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int BookId { get; set; }
        public Book? Book { get; set; }



        [DataType(DataType.Date)]
        public DateTime BookBorrowDate { get; set; } = DateTime.Now;


        [DataType(DataType.Date)]
        public DateTime BookReturnDate { get; set; } = DateTime.Now.AddDays(21);  //Books can only be borrowed for 21 days

        public BorrowStatus Status { get; set; } = BorrowStatus.NotReturned;
    }
}