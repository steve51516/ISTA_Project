using System;
using System.Data.SQLite;

namespace WebHelpTicket
{
    public class Ticket
    {
        public string Title { get; set; }
        public int EmpID { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public DateTime CommentTime { get; set; }
        public bool Open { get; set; }
        public int Tid { get; set;  }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public string Location { get; set; }
        public Ticket()
        {

        }
        public Ticket(string title, string desc, string loc)
        {
            Title = title;
            Description = desc;
            Location = loc;
            Open = true;
            OpenDate = DateTime.Now;
        }
    }
}
