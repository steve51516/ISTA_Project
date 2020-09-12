using System;
using System.IO;
using System.Data.SQLite;

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
            SQLiteConnection sqlite_conn = new SQLiteConnection(@"Data Source=|DataDirectory|\Database.sdf; Version = 3; New = True; Compress = True; ");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return sqlite_conn;
        }

        public static void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            string Createsql = "DROP TABLE IF EXISTS Tickets";
            string Createsql1 = @"CREATE TABLE Tickets(TicketID INTEGER PRIMARY KEY, UID INT NOT NULL, EmpID INT, Title TEXT, Description TEXT," +
            "Comments TEXT, OpenDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP, ClosedDate TIMESTAMP, OccurDate DATE DATE DEFAULT (datetime('now','localtime'))," +
            "Open INT DEFAULT 1, Location TEXT, ImagePath BLOB, FOREIGN KEY (UID) REFERENCES Users (UID))";
            string Createsql2 = @"CREATE TABLE Users(UID INTEGER PRIMARY KEY, Phone INT NOT NULL, email TEXT NOT NULL, Street TEXT, City TEXT, State TEXT," +
                "Country TEXT DEFAULT \"USA\", ZIP INT, FirstName TEXT NOT NULL, LastName TEXT NOT NULL, Secret TEXT NOT NULL)";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = Createsql1;
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = Createsql2;
            sqlite_cmd.ExecuteNonQuery();
        }

        public static void InsertData(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES('Test Text ', 1); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES('Test1 Text1 ', 2); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES('Test2 Text2 ', 3); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO SampleTable1(Col1, Col2) VALUES('Test3 Text3 ', 3); ";
            sqlite_cmd.ExecuteNonQuery();
        }

        public static void ReadData(SQLiteConnection conn)
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
    }
}
