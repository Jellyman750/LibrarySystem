# Library Management System (C# Console Application)

### A structured and secure Library Management System built using C#, following the MVC architecture, ADO.NET, and SHA-256 password hashing.The system supports full CRUD operations, role-based authentication, and book loan management.

## 🧱 Project Structure (MVC)
``` LibrarySystem/
│
├── Models/                 
│   ├── Member.cs
│   ├── Book.cs
│   └── Loan.cs
│
├── DataAccess/             
│   └── DatabaseHelper.cs
│
├── Controllers/            
│   ├── AuthenticationController.cs
│   └── MainController.cs
│
├── Views/                  
│   ├── LoginView.cs
│   ├── AdminView.cs
│   ├── MemberView.cs
│   └── ViewFunctions.cs
│
└── Program.cs
``` 
## 🔒 Security

```The system uses SHA-256 hashing to protect user passwords.```
Benefits:

- Passwords are never stored in plain text
- One-way cryptographic hashing
- Prevents credential exposure
- Safe and secure for storing in SQL Server

## 👥 Default Login Credentials
- Admin
- Username: admin
- Password: admin123
- Role: Admin
```
Members
Username   Password   Role
--------------------------------
john       pass123    Member
sarah      pass123    Member
```
## 🗄️ Database Setup

- Database Name: LibrarySystem
- Connection String:
- Server=(localdb)\MSSQLLocalDB;Database=LibrarySystem;Integrated Security=true


### Required Tables:
- Members
- Books
- Loans

(Your SQL script already includes the required schema.)

## 🚀 Installation & Setup
- Requirements
- Visual Studio 2019+
- .NET Framework 4.7.2+
- SQL Server (LocalDB / Express)
- Steps
- Clone the repository
- Open LibrarySystem.sln
- Create the LibrarySystem database
- Run the SQL setup script in SSMS
- Verify the connection string in DatabaseHelper.cs
- Build & Run the application

### 📋 Features
## 🔐 Authentication
- SHA-256 password hashing
- Role-based access control
- Secure login validation

## 👨‍💼 Admin Capabilities
-Add, update, delete books
-View all books
-View books grouped by genre (LINQ)
-View all loan transactions

## 👤 Member Capabilities
-View available books
-Borrow books (14-day due date)
-Return borrowed books
-View personal loan history

## 🛠️ Key Technologies Used
- C# (Console Application)
- MVC Architecture
- OOP Principles
- Encapsulation
- Inheritance
- Polymorphism
- ADO.NET (SQL connections, queries, transactions)
- SQL Server (LocalDB)
- LINQ (filtering, grouping, sorting)
- SHA-256 hashing

## 📊 Example: LINQ Grouping
```
public Dictionary<string, List<Book>> GetBooksGroupedByGenre()
{
    return dataAccess.GetAllBooks()
        .GroupBy(b => b.Genre)
        .OrderBy(g => g.Key)
        .ToDictionary(g => g.Key, g => g.ToList());
}
```
## 🔄 Application Flow
-Login
-Enter credentials
-Password hashed using SHA-256
-Hash compared with stored value
-Load Admin or Member menu

Borrowing
View available books
→ Select book
→ Record loan
→ Mark book as borrowed

Returning
View user's loans
→ Select book
→ Update return date
→ Mark book as available

## 🐛 Troubleshooting
- Database Not Connecting
- Ensure SQL Server is running
- Verify (localdb)\MSSQLLocalDB
- Check if the database exists

## 👨‍💻 Author

- C# Console Application Project
- Developed for Software Engineering coursework
- Built using Visual Studio 2022, .NET Framework 4.7.2

##📄 License

- This project is for academic and educational use.
