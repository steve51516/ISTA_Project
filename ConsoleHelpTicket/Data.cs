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
                                CommentTime TIMPSTAMP,
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
            var cmd = new SQLiteCommand($"INSERT INTO Tickets (Title,Description,OpenDate,Location) VALUES (\"{ticket.Title}\", \"{ticket.Description}\", \"{ticket.OpenDate}\", \"{ticket.location}\");", conn);
            Console.WriteLine("Inserting ticket into database");
            cmd.ExecuteNonQuery();
        }
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
        public static int GetTicketCount(SQLiteConnection conn)
        {
            int countValue = 0;
            try
            {
                var cmd = new SQLiteCommand("SELECT COUNT(TicketID) from Tickets;", conn);
                var count = cmd.ExecuteScalar();
                int.TryParse(count.ToString(), out countValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Failed to read number of tickets.");
            }
            return countValue;
        }
        public static string GetTitle(SQLiteConnection conn, int Tid)
        {
            string title = "";
            try
            {
                var cmd = new SQLiteCommand($"SELECT Title WHERE TicketID = {Tid}", conn);
                title = cmd.ExecuteReader().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Failed to get title.");
            }
            return title;
        }
        public static void FillQueue(SQLiteConnection conn, Queue<Ticket> queue)
        {
            try
            {
                var cmd = new SQLiteCommand($"select * from Tickets order by OpenDate desc;", conn);
                using SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Ticket ticket = new Ticket();
                    ticket.Tid = rdr.GetInt32(0);
                    //ticket.EmpID = rdr.GetInt32(1);
                    ticket.Title = rdr.GetString(2);
                    ticket.Description = rdr.GetString(3);
                    //ticket.Comment = rdr.GetString(4);
                    ticket.OpenDate = Convert.ToDateTime(rdr.GetString(5));
                    ticket.ClosedDate = rdr.GetString(6);
                    ticket.Open = rdr.GetBoolean(7);
                    ticket.Location = rdr.GetString(8);
                    //ticket.Image = rdr.GetBlob(9);
                    System.Console.WriteLine($"Added TID: {rdr.GetInt32(0)} Title: {rdr.GetString(2)} to queue.");

                    queue.Enqueue(ticket);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex);
                System.Console.WriteLine("Failed to get row.");
            }
        }
    }
}