using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPageWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHelpTicket.Models;

namespace RazorPageWebApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TicketDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TicketDbContext>>()))
            {
                // Look for any movies.
                if (context.Ticket.Any())
                {
                    return;   // DB has been seeded
                }

                context.Ticket.AddRange(
                    new Ticket
                    {
                        Title = "Savage Axis 30-06",
                        Description = "Affordability, performance and precision all come together in the AXIS. " +
                        "The rifle's modern design includes sleek contours, " +
                        "recoil pad vents and a textured, easy-to-control grip. " +
                        "Its 22-inch, carbon-steel barrel is button rifled for superb accuracy. " +
                        "The AXIS features a black synthetic stock, smooth bolt operation and a 4-round detachable box magazine.",
                        Location = "Canada",
                    },

                    new Ticket
                    {
                        Title = "When Harry Met Sally",
                        Description = @"Height (inches) 90° to barrel: 4.75
                                        Weight(ounces) with empty magazine: 25
                                        Length(inches): 6.8
                                        Magazine capacity: 8
                                        Recoil spring(pounds): 16.0
                                        Full - length guide rod",
                        Location = "USA",
                    },

                    new Ticket
                    {
                        Title = "Mossberg 500",
                        Description = "Sure as autumn arrives, the Model 870 Wingmaster® rises to meet another day in the upland fields and woods of America. " +
                        "The Model 870 is so smooth and reliable that today - " +
                        "more than 60 years after its introduction - it's still the standard by which all pump shotguns are measured.",
                        Location = "USA",
                    },

                    new Ticket
                    {
                        Title = "Remington model 597",
                        Description = " A dependable semi-automatic rimfire rifle fed with a 10-shot magazine. " +
                        "Manufactured in Hickory, KY (before 2016) and Huntsville, AL (2017-on).",
                        Location = "USA",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
