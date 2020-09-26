using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPageWebApp.Data;
using WebHelpTicket.Models;

namespace RazorPageWebApp.Pages.Tickets
{
    public class IndexModel : PageModel
    {
        private readonly TicketDbContext _context;

        public IndexModel(TicketDbContext context)
        {
            _context = context;
        }

        public IList<Ticket> Ticket { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Title { get; set; }
        [BindProperty(SupportsGet = true)]
        public string TicketDescription { get; set; }
        public async Task OnGetAsync()
        {
            var movies = from m in _context.Ticket
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            Ticket = await _context.Ticket.ToListAsync();
        }
    }
}
