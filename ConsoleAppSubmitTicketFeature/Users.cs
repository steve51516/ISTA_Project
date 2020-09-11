using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSubmitTicketFeature
{
    class Users
    {
        public int uid { get; set; }
        public string name { get; set; }
        public string dept { get; set; }
        public int phone { get; set; }
        public string email { get; set; }

        Users(string nameIn, string deptIn, int phoneIn, string emailIn)
        {
            uid++;
            name = nameIn;
            dept = deptIn;
            phone = phoneIn;
            email = emailIn;
        }

        public void ViewTickets()
        {
            
        }
        public void MakeTicket()
        {

        }
    }
}
