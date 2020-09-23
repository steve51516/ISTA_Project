using System;
using WebHelpTicket.Models;
using System.Data.SQLite;
using System.Security.Permissions;
using System.Reflection.Metadata.Ecma335;

namespace WebHelpTicket.Models
{
    public class Ticket
    {
        public string Title { get; set; }
        public int EmpID { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public DateTime CommentTime { get; set; }
        public bool Open { get; set; }
        public int id { get; set;  }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public string Location { get; set; }
        public double DaysOpen { get; set; }

        public Ticket()
        {
            OpenDate = DateTime.Now;
            Open = true;
            Description = "Empty Description";
            Title = "Empty Title";
            id = Data.GetTicketCount() + 1;
        }
        public Ticket(string title, string desc, string loc)
        {
            Title = title;
            Description = desc;
            Location = loc;
            Open = true;
            OpenDate = DateTime.Now;
            id = Data.GetTicketCount() + 1;
        }
    }
}
