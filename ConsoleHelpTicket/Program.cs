using System;
using System.Data.SQLite;

namespace ConsoleHelpTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.initDatabase();
            menu.initQueue();

            menu.Selection();
        }
    }
}
