using System;
using System.IO;
using System.Data.SQLite;
using System.Collections.Generic;

namespace ConsoleHelpTicket
{
    static public class Data
    {
        public static SQLiteConnection CreateConnection()
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            // Create a new database connection:
            SQLiteConnection sqlite_conn = new SQLiteConnection(@"Data Source=|DataDirectory|\Tickets.db; Version = 3; New = True; Compress = True; ");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Connection Failed.");
                Console.WriteLine(ex);
            }
            return sqlite_conn; 
        }

        public static void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            string Createsql = @"PRAGMA foreign_keys = ON;";
            string Createsql2 = @"CREATE TABLE IF NOT EXISTS Tickets(
                                TicketID INTEGER PRIMARY KEY AUTOINCREMENT, 
                                EmpID INT, 
                                Title TEXT, 
                                Description TEXT,
                                Comments TEXT, 
                                CommentTime TIMESTAMP,
                                OpenDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP, 
                                ClosedDate TIMESTAMP, 
                                Open INT DEFAULT 1, 
                                Location TEXT, 
                                Image BLOB
                                --FOREIGN KEY (UID) 
                                --REFERENCES Users (UID)
                                );";
            
            //string Createsql3 = @"CREATE TABLE IF NOT EXISTS Users(
            //                    UID INTEGER PRIMARY KEY,
            //                    Phone INT NOT NULL,
            //                    email TEXT NOT NULL,
            //                    Street TEXT,
            //                    City TEXT,
            //                    State TEXT,
            //                    Country TEXT DEFAULT ""USA"",
            //                    ZIP INT,
            //                    FirstName TEXT NOT NULL,
            //                    LastName TEXT NOT NULL,
            //                    UserName TEXT NOT NULL,
            //                    Password TEXT NOT NULL
            //                    );";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = Createsql2;
            sqlite_cmd.ExecuteNonQuery();
            //sqlite_cmd.CommandText = Createsql3;
            //sqlite_cmd.ExecuteNonQuery();
        }

        public static void Insert(SQLiteConnection conn, Ticket ticket)
        {
            SQLiteCommand sqlite_cmd = conn.CreateCommand();
            Console.WriteLine("Inserting ticket into database");
            sqlite_cmd.CommandText = $"INSERT INTO Tickets (Title,Description,OpenDate,Location) VALUES (\"{ticket.Title}\", \"{ticket.Description}\", \"{ticket.OpenDate}\", \"{ticket.location}\");";
            sqlite_cmd.ExecuteNonQuery();
        }
        // TODO: adding update method for comment column
        public static void UpdateComment(SQLiteConnection conn, Ticket ticket, string comment)
        {
            SQLiteCommand sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = $"UPDATE Tickets SET Comments = {comment} where TicketID = {ticket.Tid}";

            Console.WriteLine("Inserting comment into database");
            try
            {
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to update ticket.");
                Console.WriteLine(ex);
            }

        }
        public static void Query(SQLiteConnection conn)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM SampleTable";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine(myreader);
            }
            conn.Close();
        }
        //public static void DoesExist(SQLiteConnection conn)
        //{
        //    SQLiteDataReader sqlite_datareader;
        //    SQLiteCommand sqlite_cmd;
        //    sqlite_cmd = conn.CreateCommand();
        //    sqlite_cmd.CommandText = "SELECT TicketID FROM Tickets;";
        //}
        public static int GetNumber(SQLiteConnection conn)
        {

            var ticket_count = 0;
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT TicketID FROM Tickets ORDER BY TicketID DESC LIMIT 1;";
                var cmd = new SQLiteCommand(sqlite_cmd.CommandText, conn);
                SQLiteDataReader sqlite_datareader = cmd.ExecuteReader();

                ticket_count = int.Parse(sqlite_datareader.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Failed to read number of tickets.");
            }

            return ticket_count;
        }
    }
}
