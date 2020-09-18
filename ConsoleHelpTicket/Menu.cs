using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ConsoleHelpTicket
{
    class Menu
    {
        private static Queue<Ticket> queue = new Queue<Ticket>();
        public void initDatabase()
        {
            SQLiteConnection conn = Data.CreateConnection();
            Data.CreateTable(conn);
            conn.Close();
        }
        public void initQueue()
        {
            SQLiteConnection conn = Data.CreateConnection();
            int ticketCount = Data.GetTicketCount(conn);
            Data.FillQueue(conn, queue);
            conn.Close();
        }
        public void Selection()
        {
            int select = 0;
            bool exit = true;

            do
            {
                Console.WriteLine("Help Desk Ticket Application\n");
                Console.WriteLine("1) Create New Ticket");
                Console.WriteLine("2) View Existing Tickets");
                Console.WriteLine("3) Exit Application\n");
                Console.Write("Enter Selection: ");
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
                        newTicket();
                        break;
                    case 2:
                        Console.Clear();
                        getTicketMenu();
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
        void newTicket()
        {
            Console.Write("Enter title: ");
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
                Console.Write("Enter a description: ");
                desc = Console.ReadLine();
                if (desc.Length < 30)
                    Console.WriteLine("Description must be at least 30 characters.");
                else if (desc == "")
                    Console.WriteLine("Description cannot be empty.");
            } while (desc.Length < 30);
            string loc;
            do
            {
                Console.Write("Enter a location: ");
                loc = Console.ReadLine();
                if (loc == "")
                    Console.WriteLine("Location cannot be empty.");
            } while (loc == "");
            Ticket ticket = new Ticket(title, desc, loc);
            queue.Enqueue(ticket);
            SQLiteConnection conn = Data.CreateConnection();
            Data.Insert(conn, ticket);
            ticket.Tid = Data.GetTicketCount(conn);
            conn.Close();

            Console.WriteLine($"\nSuccessfully created ticket with title \"{ticket.Title}\", TicketID: {ticket.Tid}\n");
        }
        void getTicketMenu()
        {
            int select = 0;
            do
            {
                Console.WriteLine("1) View Open Tickets");
                Console.WriteLine("2) View All Open Tickets");
                Console.WriteLine("3) View Closed Tickets");
                Console.Write("Enter Selection: ");
                try
                {
                    select = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a 1, 2 or 3.");
                }
                switch (select)
                {
                    case 1:
                        getOneTicket();
                        break;
                    default:
                        break;
                }
            } while (select <= 0 || select >= 4);
            
        }
        void getOneTicket()
        {
            int select = 0;
            do
            {
                try
                {
                    select = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a number.");
                }
            } while (select < 1);
        }
    }
}
