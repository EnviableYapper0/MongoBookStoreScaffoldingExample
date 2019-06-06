using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoBookStore.Models;

namespace MongoBookStore.Pages.BookStorePage
{
    public class CreateModel : PageModel
    {
        private readonly MongoBookStore.Models.MongoBookStoreContext _context;

        public CreateModel(MongoBookStore.Models.MongoBookStoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.Book.InsertOneAsync(Book);

            return RedirectToPage("./Index");
        }
    }
}