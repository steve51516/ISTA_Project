using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebHelpTicket.Models;

namespace RazorPageWebApp.Data
{
    public class TicketDbContext : DbContext
    {
        public TicketDbContext (DbContextOptions<TicketDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ticket> Ticket { get; set; }
    }
}
