using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

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
        //public void SetStatus(string status) // 0 = open, 1 = reopened, 2 = closed
        //{
        //    switch (status)
        //    {
        //        case "open":
        //            statusCode = 0;
        //            break;
        //        case "reopen":
        //            statusCode = 1;
        //            break;
        //        case "closed":
        //            statusCode = 2;
        //            break;
        //        default:
        //            throw new Exception("Input must be open, reopen, or closed");
        //    }
        //}
        public string GetDescription() => description;
        public void GetLocation() => Console.WriteLine(location);
    }
}
