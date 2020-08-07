-- Name: Steven Fairchild
-- File: project_db.sql
-- Date: August 7, 2020

.echo on
.headers on
PRAGMA foreign_keys = ON;

DROP TABLE IF EXISTS Users;
DROP TABLE IF EXISTS Ticket;
DROP TABLE IF EXISTS Category;
DROP TABLE IF EXISTS Employees;
DROP TABLE IF EXISTS Que;
DROP TABLE IF EXISTS Roles;

CREATE TABLE Users(
UID INT PRIMARY KEY NOT NULL,
Phone INT NOT NULL,
Street TEXT,
City TEXT,
State TEXT,
Country TEXT DEFAULT "USA",
ZIP INT,
First_Name TEXT NOT NULL,
Last_Name TEXT NOT NULL
);

CREATE TABLE Ticket(
TicketID PRIMARY KEY NOT NULL,
UID INT NOT NULL,
CategoryID INT,
Title TEXT,
Description TEXT,
CreationDate DATE NOT NULL DEFAULT (datetime('now','localtime')),
ClosedDate DATE,
Open INT, -- 0 closed, 1 open.
Status TEXT,
FOREIGN KEY (UID)
	REFERENCES Users (UID)
FOREIGN KEY (CategoryID)
	REFERENCES Category (CategoryID)
);

CREATE TABLE Que (
CatID int PRIMARY KEY,
TicketID int,
EmpID int,
FOREIGN KEY (EmpID)
	REFERENCES Employees (EmpID)
FOREIGN KEY (TicketID)
	REFERENCES Tickets (TicketID)
);

CREATE TABLE Employees(
EmpID PRIMARY KEY NOT NULL,
RoleID int,
Street text,
City text,
State text,
Country text,
ZIP int,
First_name text,
Last_name text,
Phone int,
Email text,
FOREIGN KEY (RoleID)
	REFERENCES Roles (RoleID)
);

CREATE TABLE Roles(
RoleID int PRIMARY KEY,
RoleTitle text,
AccessLevel int DEFAULT 0,
RoleDescription text
);


insert into Users values(
1, 7025551838, "8489 Strong St.", "Las Vegas", "NV", "USA", 83030, "Sue", "King");
insert into Users values(
2, 4155551450, "5677 Strong St.", "San Rafael", "CA", "USA", 97562, "Nelson", 'Valarie');
insert into Users values(
3, 6505555787, "5557 North Pendale Street", "San Francisco", "CA", "USA", 94217, "Julie", "Murphy");
insert into Users values(
4, 2125557818, "897 Long Airport Avenue", "New York City", "NY", "USA", 10022, "Yu", "Kwai");
insert into Users values(
5, 2125557413, "4092 Furth Circle Suite 400", "New York City", "NY", "USA", 10022, "Young", "Jeff");
insert into Users values(
6, 2155551555, "7586 Pompton St.", "Allentown", "PA", "USA", 70267, "Yu", "Kyung");
insert into Users values(
7, 6505556809, "9408 Furth Circle", "Burlingame", "CA", "USA", 94217, "Hirao", "Juri");



.schema Users;
select * from Users;