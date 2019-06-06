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
    public class IndexModel : PageModel
    {
        private readonly MongoBookStore.Models.MongoBookStoreContext _context;

        public IndexModel(MongoBookStore.Models.MongoBookStoreContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        public async Task OnGetAsync()
        {
            Book = await(await _context.Book.FindAsync(m => true)).ToListAsync();
        }
    }
}
