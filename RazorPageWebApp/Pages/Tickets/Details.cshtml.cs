using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageWebApp.Data;
using WebHelpTicket.Models;

namespace RazorPageWebApp.Pages.Tickets
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPageWebApp.Data.TicketDbContext _context;

        public DetailsModel(RazorPageWebApp.Data.TicketDbContext context)
        {
            _context = context;
        }

        public Ticket Ticket { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket = await _context.Ticket.FirstOrDefaultAsync(m => m.id == id);

            if (Ticket == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
