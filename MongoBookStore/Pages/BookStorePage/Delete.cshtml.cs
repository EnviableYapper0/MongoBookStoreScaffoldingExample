using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MongoBookStore.Models;
using MongoDB.Driver;

namespace MongoBookStore.Pages.BookStorePage
{
    public class DeleteModel : PageModel
    {
        private readonly MongoBookStore.Models.MongoBookStoreContext _context;

        public DeleteModel(MongoBookStore.Models.MongoBookStoreContext context)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _context.Book.FindOneAndDeleteAsync(m => m.Id == id);

            return RedirectToPage("./Index");
        }
    }
}
