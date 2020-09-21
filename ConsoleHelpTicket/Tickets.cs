using System;
using System.Data.SQLite;

namespace ConsoleHelpTicket
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
        public SQLiteBlob Image { get; set; }
        public Ticket(string title = "Blank title", string desc = "Blank description", string loc = "Blank location")
        {
            Title = title;
            Description = desc;
            Location = loc;
            Open = true;
            OpenDate = DateTime.Now;
        }
        // public void NewComment(SQLiteConnection connection, Ticket ticket, string text)
        // {
        //     TODO: adding update method for comment column

        //     Data.Insert(connection, ticket);
        //     comment += "\n NEW COMMENT\n";
        //     comment += DateTime.Now.ToString();
        //     comment += text;
        // }
    }
}
