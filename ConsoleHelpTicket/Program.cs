using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleHelpTicket
{
    class Program
    {
        //static public Queue<int> Queue { get; set; }
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.Selection();
        }
    }
}
