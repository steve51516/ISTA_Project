using System;

namespace ConsoleHelpTicket
{
    public class Ticket
    {
        public string Title { get; set; }
        public string location { get; set; }
        public int EmpID { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public string CommentTime { get; set; }
        public bool Open { get; set; }
        public int Tid { get; set;  }
        public DateTime OpenDate { get; set; }
        public string ClosedDate { get; set; }
        public string Location { get; set; }
        public Ticket(string title = "Blank title", string desc = "Blank description", string loc = "Blank location")
        {
            Title = title;
            Description = desc;
            location = loc;
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
