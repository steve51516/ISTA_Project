using System;
using System.Data.SQLite;

namespace ConsoleHelpTicket
{
    public class Ticket
    {
        public string Title { get; set; }
        public string location { get; set; }
        public string Description { get; }
        public bool open { get; set; }
        public int Tid { get; set;  }
        public DateTime OpenDate { get; }
        public DateTime ClosedDate { get; }
        public string comment { get; set; }
        public Ticket(string title, string desc, string loc)
        {
            Title = title;
            Description = desc;
            location = loc;
            open = true;
            OpenDate = DateTime.Now;
        }
        public void NewComment(SQLiteConnection connection, Ticket ticket, string text)
        {
            // TODO: adding update method for comment column

            Data.Insert(connection, ticket);
            comment += "\n NEW COMMENT\n";
            comment += DateTime.Now.ToString();
            comment += text;
        }
        public void GetLocation() => Console.WriteLine(location);
    }
}
