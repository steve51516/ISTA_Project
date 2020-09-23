using Microsoft.EntityFrameworkCore;
using System;

namespace WebHelpTicket.Models
{
    public class TicketContext : DbContext
    {
        public TicketContext()
        {

        }
        public TicketContext(DbContextOptions<TicketContext> options)
            : base(options)
        {
        }

        public DbSet<Ticket> GetTickets { get; set; }

        internal bool Any(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}