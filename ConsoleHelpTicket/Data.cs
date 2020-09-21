using System;
using System.IO;
using System.Data.SQLite;
using System.Collections.Generic;

namespace ConsoleHelpTicket
{
    static public class Data
    {
        public static SQLiteConnection CreateConnection(string dbName = "Tickets.db")
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            // Create a new database connection:
            SQLiteConnection sqlite_conn = new SQLiteConnection($@"Data Source=|DataDirectory|\{dbName}; Version = 3; New = True; Compress = True; ");
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

        public static void CreateTable()
        {
            SQLiteConnection conn = CreateConnection();

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
            conn.Close();
        }

        public static void Insert(Ticket ticket)
        {
            SQLiteConnection conn = CreateConnection();
            var cmd = new SQLiteCommand($"INSERT INTO Tickets (Title,Description,OpenDate,Location) VALUES (\"{ticket.Title}\", \"{ticket.Description}\", \"{DateTime.Now}\", \"{ticket.Location}\");", conn);
            Console.WriteLine("Inserting ticket into database");
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void UpdateComment(Ticket ticket, string comment)
        {
            SQLiteConnection conn = CreateConnection();
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
            conn.Close();
        }
        public static int GetTicketCount()
        {
            SQLiteConnection conn = CreateConnection();

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
            conn.Close();
            return countValue;
        }
        public static string GetTitle(int Tid)
        {
            SQLiteConnection conn = CreateConnection();

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
            conn.Close();
            return title;
        }
        public static void GetTicket(Queue<Ticket> queue)
        {
            SQLiteConnection conn = CreateConnection();

            try
            {
                var cmd = new SQLiteCommand($"SELECT * FROM Tickets WHERE Open = true ORDER BY OpenDate desc;", conn);
                using SQLiteDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Ticket ticket = new Ticket();
                    ticket.Tid = rdr.GetInt32(0);
                    if (!rdr.IsDBNull(1))
                        ticket.EmpID = rdr.GetInt32(1);
                    if (!rdr.IsDBNull(2))
                        ticket.Title = rdr.GetString(2);
                    if (!rdr.IsDBNull(3))
                        ticket.Description = rdr.GetString(3);
                    if (!rdr.IsDBNull(4))
                        ticket.Comment = rdr.GetString(4);
                    if (!rdr.IsDBNull(5))
                        ticket.CommentTime = DateTime.Parse(rdr.GetString(5));
                    if (!rdr.IsDBNull(6))
                        ticket.OpenDate = DateTime.Parse(rdr.GetString(6));
                    //ticket.ClosedDate = rdr.GetDateTime(7);
                    if (!rdr.IsDBNull(8))
                        ticket.Open = rdr.GetBoolean(8);
                    if (!rdr.IsDBNull(9))
                        ticket.Location = rdr.GetString(9);
                    if (!rdr.IsDBNull(10))
                        ticket.Image = rdr.GetBlob(10, false);
                    Console.WriteLine($"Added TID: {rdr.GetInt32(0)} Title: {rdr.GetString(2)} to queue.");

                    queue.Enqueue(ticket);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Failed to get row.");
            }
            conn.Close();
        }
    }
}