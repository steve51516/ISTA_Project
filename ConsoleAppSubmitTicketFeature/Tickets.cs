using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSubmitTicketFeature
{
    public class Ticket
    {
        public string Title { get; set; }
        private string location;
        private string description;
        private int statusCode = 0;
        private int tid = 0;
        public Ticket(string title, string desc, string loc)
        {
            title = Title;
            description = desc;
            location = loc;
            tid++;

        }
        public void NewComment(string comment)
        {
            description += "\n NEW COMMENT\n";
            description += DateTime.Now.ToString();
            description += comment;
        }
        public void SetStatus(string status) // 0 = open, 1 = reopened, 2 = closed
        {
            switch (status)
            {
                case "open":
                    statusCode = 0;
                    break;
                case "reopen":
                    statusCode = 1;
                    break;
                case "closed":
                    statusCode = 2;
                    break;
                default:
                    throw new Exception("Input must be open, reopen, or closed");
            }
        }
        public void GetDescription() => Console.WriteLine(description);
        public void GetLocation() => Console.WriteLine(location);
    }
}
