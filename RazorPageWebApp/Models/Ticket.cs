using System;
using WebHelpTicket.Models;
using System.Data.SQLite;
using System.Security.Permissions;
using System.Reflection.Metadata.Ecma335;
using System.ComponentModel.DataAnnotations;

namespace WebHelpTicket.Models
{
    public class Ticket
    {
        // user ID from AspNetUser table.
        public string OwnerID { get; set; }
        public string Title { get; set; }
        public int EmpID { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        [DataType(DataType.Date)]
        public DateTime CommentTime { get; set; }
        public bool Open { get; set; }
        public int id { get; set;  }
        [DataType(DataType.Date)]
        public DateTime OpenDate { get; set; }
        [DataType(DataType.Date)]

        public DateTime ClosedDate { get; set; }
        public string Location { get; set; }
        public TicketStatus Status { get; set; }
        //public double DaysOpen { get; set; }


        Random random = new Random();
        public Ticket()
        {
            EmpID = random.Next(5);
            //OpenDate = DateTime.Now;
            Open = true;
        }
        public double DaysOpen()
        {
            //double DaysOpen = (DateTime.Today - OpenDate).TotalDays;
            return 1;
        }
    }
    public enum TicketStatus
    {
        Open,
        Reopen,
        Closed
    }
}
