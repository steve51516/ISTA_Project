using System;

namespace ConsoleHelpTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating database connection...");
            var connection = Data.CreateConnection();
            Console.WriteLine("Creating tables...");
            Data.CreateTable(connection);

            Menu menu = new Menu();

            menu.Selection();
            Console.WriteLine("Closing database connection...");
            connection.Close();
        }
    }
}
