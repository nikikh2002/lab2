using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab2.Data;
using lab2.Models;
using System.Security.Policy;
using lab2.Models.ViewModels;

namespace lab2.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly lab2.Data.lab2Context _context;
        private Models.Publisher publisher;

        public IndexModel(lab2.Data.lab2Context context)
        {
            _context = context;
        }

        public IList<Models.Publisher> Publisher { get;set; } = default!;

        public PublisherIndexData PublisherData { get; set; }
        public int PublisherID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            PublisherData = new PublisherIndexData();
            PublisherData.Publishers = await _context.Publisher
           .Include(i => i.Books)
           .ThenInclude(c => c.Author)
           .OrderBy(i => i.PublisherName)
           .ToListAsync();
            if (id != null)
            {
                PublisherID = id.Value;
                Models.Publisher publisher = PublisherData.Publishers
               .Where(i => i.ID == id.Value).Single();
                PublisherData.Books = publisher.Books;
            }
        }
            public async Task OnGetAsync()
        {
            Publisher = await _context.Publisher.ToListAsync();
        }
    }
}
