-- Name: Steven Fairchild
-- File: project_db.sql
-- Date: August 7, 2020

.echo on
.headers on
PRAGMA foreign_keys = ON;


DROP TABLE IF EXISTS Tickets;
DROP TABLE IF EXISTS Category;
DROP TABLE IF EXISTS Employees;
DROP TABLE IF EXISTS Que;
DROP TABLE IF EXISTS Roles;
DROP TABLE IF EXISTS Users;

CREATE TABLE Users(
UID INTEGER PRIMARY KEY AUTOINCREMENT,
Phone INT NOT NULL,
Street TEXT,
City TEXT,
State TEXT,
Country TEXT DEFAULT "USA",
ZIP INT,
FirstName TEXT NOT NULL,
LastName TEXT NOT NULL
);

CREATE TABLE Tickets(
TicketID INTEGER PRIMARY KEY AUTOINCREMENT,
UID INT NOT NULL,
EmpID INT,
Title TEXT,
Description TEXT,
OpenDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
ClosedDate TIMESTAMP,
Open INT DEFAULT 1, -- Boolean 0 closed, 1 open.
Status TEXT DEFAULT "Awaiting Assignment",
FOREIGN KEY (UID)
	REFERENCES Users (UID)
FOREIGN KEY (EmpID)
	REFERENCES Employees (EmpID)
);

CREATE TABLE Employees(
EmpID INTEGER PRIMARY KEY AUTOINCREMENT,
RoleID INT,
FirstName text,
LastName text,
Phone int,
Email text,
FOREIGN KEY (RoleID)
	REFERENCES Roles (RoleID)
);

CREATE TABLE Roles(
RoleID int PRIMARY KEY NOT NULL,
RoleTitle text,
RoleDescription text
);

-- Inserting data into Users table
insert into Users(UID, Phone, Street,City, State, Country, ZIP, FirstName, LastName) values
(NULL, 7025551838, "8489 Strong St.", "Las Vegas", "NV", "USA", 83030, "Sue", "King"),
(NULL, 4155551450, "5677 Strong St.", "San Rafael", "CA", "USA", 97562, "Nelson", 'Valarie'),
(NULL, 6505555787, "5557 North Pendale Street", "San Francisco", "CA", "USA", 94217, "Julie", "Murphy"),
(NULL, 2125557818, "897 Long Airport Avenue", "New York City", "NY", "USA", 10022, "Yu", "Kwai"),
(NULL, 2125557413, "4092 Furth Circle Suite 400", "New York City", "NY", "USA", 10022, "Young", "Jeff"),
(NULL, 2155551555, "7586 Pompton St.", "Allentown", "PA", "USA", 70267, "Yu", "Kyung"),
(NULL, 6505556809, "9408 Furth Circle", "Burlingame", "CA", "USA", 94217, "Hirao", "Juri");

-- Inserting data into roles table
insert into Roles (RoleID, RoleTitle, RoleDescription) values
(0, "Manager", "Manages Technicians and ensures ticket resolution, customer satisfaction, and employee work quality."),
(1, "Technician", "Resolves help tickets");

-- Inserting data into Employees table
insert into Employees (EmpID, RoleID, FirstName, LastName, Phone, Email) values
(1, 0, "Murphy", "Diane", 5402420302, "dmurphy@gmail.com"),
(2, 1, "Patterson", "Mary", 5402889102, "mpatterson@gmail.com"),
(3, 1, "Firreli", "Jeff", 5403002002, "jferreli@gmail.com"),
(4, 1, "Patterson", "William", 5403180213, "wpatterson@gmail.com"),
(5, 1, "Bondur", "Gerard", 5404464406, "gbondur@gmail.com");

-- Inserting data into Tickets table
insert into Tickets (TicketID, UID, EmpID, Title, Description, OpenDate, ClosedDate, Open, Status) values
(NULL, 3, NULL, "A/C Unit not working", "My A/C unit will not cool below 80 degrees", CURRENT_TIMESTAMP, NULL, 1, "Awaiting Action"),
(NULL, 1, NULL, "Refrigerator Broken", "Will not cool", CURRENT_TIMESTAMP, NULL, 1,"Awaiting Action"),
(NULL, 7, NULL, "Squeaky front door", "Front door squeaks loudly", CURRENT_TIMESTAMP, NULL, 1, "Awaiting Action"),
(NULL, 2, NULL, "Broken Window", "Living room window is broken.", CURRENT_TIMESTAMP, NULL, 1, "Awaiting Action");

select * from Employees;
select * from Users;
select * from Tickets;