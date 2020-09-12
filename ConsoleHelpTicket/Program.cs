namespace ConsoleHelpTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Creating database connection...");
            var connection = Data.CreateConnection();
            System.Console.WriteLine("Creating tables...");
            Data.CreateTable(connection);

            Menu menu = new Menu();

            //menu.Selection();
        }
    }
}
