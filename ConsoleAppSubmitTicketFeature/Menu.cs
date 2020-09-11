using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSubmitTicketFeature
{
    class Menu
    {
        static Queue<Ticket> openTickets = new Queue<Ticket>();
        static List<Ticket> closedTickets = new List<Ticket>();
        public void Selection()
        {
            int select = 0;
            bool exit = true;

            do
            {
                Console.WriteLine("Help Desk Ticket Application\n");
                Console.WriteLine("1) Create New Ticket");
                Console.WriteLine("2) View Existing Tickets");
                Console.WriteLine("3) Exit Application");
                try
                {
                    select = int.Parse(Console.ReadLine());
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Selection cannot be empty");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Selection must be 1 or 0");
                }
                switch (select)
                {
                    case 1:
                        Console.Clear();
                        NewTicket();
                        break;
                    case 2:
                        Console.Clear();
                        GetTicket();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Exiting Application...");
                        exit = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("You must select options 1, 2, or 3.");
                        break;
                }
            } while (exit);
        }
        public void NewTicket()
        {
            Console.Write("Please enter title: ");
            string title;
            string desc;
            do
            {
                title = Console.ReadLine();
                if (title == "")
                    Console.WriteLine("Title cannot be empty.");
                else if (title.Length < 5)
                    Console.WriteLine("Title must be longer than 5 characters.");
            } while (title.Length < 5);

            do
            {
                desc = Console.ReadLine();
                if (desc.Length < 30)
                    Console.WriteLine("Description must be at least 30 characters.");
                else if (desc == "")
                    Console.WriteLine("Description cannot be empty.");
            } while (desc.Length < 30);
            string loc;
            do
            {
                loc = Console.ReadLine();
                if (loc == "")
                    Console.WriteLine("Location cannot be null");
            } while (loc == "");
            Ticket ticket = new Ticket(title, desc, loc);

            openTickets.Enqueue(ticket);
        }
        public void GetTicket()
        {
            bool exit = true;
            int select = 0;
            do
            {
                Console.WriteLine("1) View Open Tickets");
                Console.WriteLine("2) View Closed Tickets");
                Console.Write("Enter Selection: ");
                try
                {
                    select = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a 1 or 2.");
                }
            } while (exit);
            if (select == 1)
            {
                foreach (var ticket in openTickets)
                    Console.WriteLine(ticket);
            }
            else if (select == 2)
            {
                foreach (var ticket in closedTickets)
                {
                    Console.WriteLine(ticket);
                }
            }

            exit = true;
            do
            {
                int tid;
                Console.WriteLine("Enter ticket ID you would like to view: ");
                try
                {
                    tid = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("You must enter an intiger.");
                }
            } while (exit);
        }
    }
}
