using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MongoBookStore.Models;
using MongoDB.Driver;

namespace MongoBookStore.Pages.BookStorePage
{
    public class EditModel : PageModel
    {
        private readonly MongoBookStore.Models.MongoBookStoreContext _context;

        public EditModel(MongoBookStore.Models.MongoBookStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await (await _context.Book.FindAsync(m => m.Id == id)).FirstOrDefaultAsync();

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.Book.ReplaceOneAsync(m => m.Id == Book.Id, Book);

            return RedirectToPage("./Index");
        }

        private bool BookExists(string id)
        {
            return _context.Book.Find(e => e.Id == id).Any();
        }
    }
}
