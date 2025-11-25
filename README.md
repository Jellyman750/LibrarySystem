Library Management System (C# Console Application)

A structured and secure Library Management System built using C#, applying the MVC architecture, ADO.NET, and SHA-256 password hashing. The system supports full CRUD operations, role-based authentication, and book loan management.

🧱 Project Structure (MVC)
LibrarySystem/
│
├── Models/                 # Entity Models
│   ├── Member.cs
│   ├── Book.cs
│   └── Loan.cs
│
├── DataAccess/             # Data Access Layer
│   └── DatabaseHelper.cs
│
├── Controllers/            # Business Logic Layer
│   ├── AuthenticationController.cs
│   └── MainController.cs
│
├── Views/                  # Presentation Layer
│   ├── LoginView.cs
│   ├── AdminView.cs
│   ├── MemberView.cs
│   └── ViewFunctions.cs
│
└── Program.cs              # Application Entry Point

🔒 Security

The system uses SHA-256 hashing to protect user passwords.

Benefits

Passwords are never stored in plain text

One-way cryptographic hashing

Prevents credential exposure

Safe for storing in SQL Server

👥 Default Login Credentials
Admin

Username: admin

Password: admin123

Role: Admin

Members
Username	Password	Role
john	pass123	Member
sarah	pass123	Member
🗄️ Database Setup

Database: LibrarySystem
Connection String:

Server=(localdb)\MSSQLLocalDB;Database=LibrarySystem;Integrated Security=true

Required Tables

Members

Books

Loans

(Your script already includes these—ideal for copy/paste into SSMS.)

🚀 Installation & Setup
Requirements

Visual Studio 2019+

.NET Framework 4.7.2+

SQL Server (LocalDB/Express)

Steps

Clone the repository

Open LibrarySystem.sln

Create the LibrarySystem database

Run the SQL setup script

Update/verify connection string

Build → Run the application

📋 Features
🔐 Authentication

SHA-256 password hashing

Role-based access (Admin / Member)

Secure login validation

👨‍💼 Admin Capabilities

Add, update, delete books

View all books

View grouped books (by genre using LINQ)

View all loan transactions

👤 Member Capabilities

View available books

Borrow books (14-day due date)

Return borrowed books

View personal loan history

🛠️ Key Technologies Used

C# (Console Application)

MVC Architecture

OOP Principles

Encapsulation

Inheritance

Polymorphism

ADO.NET (SQL connections, queries, transactions)

SQL Server (LocalDB)

LINQ (filtering, grouping, ordering)

SHA-256 hashing

📊 Example: LINQ Grouping (Books by Genre)
public Dictionary<string, List<Book>> GetBooksGroupedByGenre()
{
    return dataAccess.GetAllBooks()
        .GroupBy(b => b.Genre)
        .OrderBy(g => g.Key)
        .ToDictionary(g => g.Key, g => g.ToList());
}

🔄 Application Flow (Simplified)
Login

Enter credentials

Password hashed with SHA-256

Compare with stored hash

Load Admin or Member menu

Borrowing

View available books

Select book

Create loan record

Mark book as borrowed

Returning

View user loans

Select book

Update return date

Mark book as available

🐛 Troubleshooting
Database Not Connecting

Ensure SQL Server is running

Verify (localdb)\MSSQLLocalDB

Make sure the database exists

Login Failing

Re-check default credentials

Ensure hashed passwords exist in the DB

👨‍💻 Author

C# Console Application Project

Created as part of Software Engineering coursework

Built with Visual Studio 2022, .NET Framework 4.7.2

📄 License

This is an academic project intended for educational use.
