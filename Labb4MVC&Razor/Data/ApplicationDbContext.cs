using Labb4MVC_Razor.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb4MVC_Razor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookBorrow>().HasKey(bb => new { bb.BookId, bb.CustomerId });
          
            // This line is used if using identity and if having a overrided OnModelCreating
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookBorrow> BookBorrow { get; set; }

    }
}