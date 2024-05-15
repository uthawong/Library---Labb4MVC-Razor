using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labb4MVC_Razor.Data;
using Labb4MVC_Razor.Models;

namespace Labb4MVC_Razor.Controllers
{
    public class BookBorrowsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookBorrowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookBorrows
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BookBorrow.Include(b => b.Book).Include(b => b.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BookBorrows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookBorrow = await _context.BookBorrow
                .Include(b => b.Book)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookBorrow == null)
            {
                return NotFound();
            }

            return View(bookBorrow);
        }

        // GET: BookBorrows/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookAuthor");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName");

            //ViewData["Status"] = Enum.GetValues(typeof(BorrowStatus))
            //   .Cast<BorrowStatus>()
            //   .Select(bs => new SelectListItem
            //   {
            //       Value = bs.ToString(),
            //       Text = bs.ToString()
            //   })
            //   .ToList();
            BookBorrow bookBorrow = new();
          
            return View(bookBorrow);
        }

        // POST: BookBorrows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,BookId,BookBorrowDate,BookReturnDate,Status")] BookBorrow bookBorrow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookBorrow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookAuthor", bookBorrow.BookId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerAddress", bookBorrow.CustomerId);
            return View(bookBorrow);
        }

        // GET: BookBorrows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookBorrow = await _context.BookBorrow.FindAsync(id);
            if (bookBorrow == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookAuthor", bookBorrow.BookId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerAddress", bookBorrow.CustomerId);
            return View(bookBorrow);
        }

        // POST: BookBorrows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,BookId,BookBorrowDate,BookReturnDate,Status")] BookBorrow bookBorrow)
        {
            if (id != bookBorrow.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookBorrow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookBorrowExists(bookBorrow.BookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookAuthor", bookBorrow.BookId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerAddress", bookBorrow.CustomerId);
            return View(bookBorrow);
        }

        // GET: BookBorrows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookBorrow = await _context.BookBorrow
                .Include(b => b.Book)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookBorrow == null)
            {
                return NotFound();
            }

            return View(bookBorrow);
        }

        // POST: BookBorrows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookBorrow = await _context.BookBorrow.FindAsync(id);
            if (bookBorrow != null)
            {
                _context.BookBorrow.Remove(bookBorrow);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookBorrowExists(int id)
        {
            return _context.BookBorrow.Any(e => e.BookId == id);
        }
    }
}
