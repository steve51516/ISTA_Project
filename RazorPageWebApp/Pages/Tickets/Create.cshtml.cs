using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPageWebApp.Data;
using WebHelpTicket.Models;

namespace RazorPageWebApp.Pages.Tickets
{
    public class CreateModel : PageModel
    {
        private readonly TicketDbContext _context;

        public CreateModel(TicketDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Ticket Ticket { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var ticketVM = new TicketViewModel
            {
                OwnerID = this.Ticket.OwnerID,
                Title = this.Ticket.Title,
                EmpID = this.Ticket.EmpID,
                Description = this.Ticket.Description
            };
            _context.Ticket.Add(Ticket);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
    public class TicketViewModel
    {
        public string OwnerID { get; set; }
        public string Title { get; set; }
        public int EmpID { get; set; }
        public string Description { get; set; }
    }
}
