using System;

namespace ConsoleAppSubmitTicketFeature
{
    public class Ticket
    {
        public string Title { get; set; }
        public string location { get; set; }
        private string description;
        public bool open { get; set; }
        public int tid { get; set; }
        public Ticket(string title, string desc, string loc)
        {
            Title = title;
            description = desc;
            location = loc;
            open = true;
        }
        public void NewComment(string comment)
        {
            description += "\n NEW COMMENT\n";
            description += DateTime.Now.ToString();
            description += comment;
        }
        public string GetDescription() => description;
        public void GetLocation() => Console.WriteLine(location);
    }
}
