#Library Management System - Console Application

#A comprehensive Library Management System built using C# Console Application that demonstrates MVC (Model-View-Controller) architecture, secure authentication, and complete CRUD operations for book lending.

🏗️ System Architecture
MVC Structure
LibrarySystem/
│
├── Models/                          # Data Models (Entities)
│   ├── Member.cs                    # User/Member entity
│   ├── Book.cs                      # Book entity
│   └── Loan.cs                      # Loan transaction entity
│
├── DataAccess/                      # Data Access Layer
│   └── DatabaseHelper.cs            # SQL Server database operations
│
├── Controllers/                     # Business Logic Layer
│   ├── AuthenticationController.cs # User authentication & password hashing
│   └── MainController.cs            # CRUD operations & LINQ grouping
│
├── Views/                          # Presentation Layer
│   ├── LoginView.cs                # Login interface
│   ├── AdminView.cs                # Admin menu & operations
│   ├── MemberView.cs               # Member menu & operations
│   └── ViewFunctions.cs            # Display helper methods
│
└── Program.cs                      # Application entry point

#🔒 Security Features
Password Hashing (SHA-256)
The system implements industry-standard SHA-256 password hashing for secure credential storage:
csharp// Authentication Controller
public string HashPassword(string password)
{
    using (SHA256 sha256 = SHA256.Create())
    {
        byte[] bytePassword = Encoding.UTF8.GetBytes(password);
        byte[] hashPassword = sha256.ComputeHash(bytePassword);
        StringBuilder builder = new StringBuilder();
        foreach (byte b in hashPassword)
        {
            builder.Append(b.ToString("x2"));
        }
        return builder.ToString();
    }
}
Security Benefits:

✅ Passwords never stored in plain text
✅ One-way encryption (cannot be reversed)
✅ Industry-standard SHA-256 algorithm
✅ Protects user credentials in database


👥 Login Credentials
Administrator Account

Username: admin
Password: admin123
Hashed Password: 240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9
Role: Admin
Permissions: Full CRUD on books, view all loans, manage inventory

Member Accounts
Member 1:

Username: john
Password: pass123
Hashed Password: ef92b778bafe771e89245b89ecbc08a44a4e166c06659911881f383d4473e94f
Role: Member
Permissions: Borrow/return books, view own loans

Member 2:

Username: sarah
Password: pass123
Hashed Password: ef92b778bafe771e89245b89ecbc08a44a4e166c06659911881f383d4473e94f
Role: Member
Permissions: Borrow/return books, view own loans


#💾 Database Setup
Database Name: LibrarySystem
Connection String:
csharpServer=(localdb)\\MSSQLLocalDB;Database=LibrarySystem;Integrated Security=true
Database Schema:
Members Table
sqlCREATE TABLE Members (
    MemberId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) NOT NULL CHECK (Role IN ('Admin', 'Member'))
);
Books Table
sqlCREATE TABLE Books (
    BookId INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100) NOT NULL,
    Genre NVARCHAR(50) NOT NULL,
    Condition NVARCHAR(20) NOT NULL CHECK (Condition IN ('New', 'Good', 'Fair', 'Damaged')),
    IsBorrowed BIT NOT NULL DEFAULT 0
);
Loans Table
sqlCREATE TABLE Loans (
    LoanId INT PRIMARY KEY IDENTITY(1,1),
    MemberId INT NOT NULL,
    BookId INT NOT NULL,
    BorrowDate DATETIME NOT NULL,
    DueDate DATETIME NOT NULL,
    ReturnDate DATETIME NULL,
    FOREIGN KEY (MemberId) REFERENCES Members(MemberId),
    FOREIGN KEY (BookId) REFERENCES Books(BookId)
);
Sample Data Script:
sql-- Insert Members (with hashed passwords)
INSERT INTO Members (Username, PasswordHash, Role) VALUES
('admin', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 'Admin'),
('john', 'ef92b778bafe771e89245b89ecbc08a44a4e166c06659911881f383d4473e94f', 'Member'),
('sarah', 'ef92b778bafe771e89245b89ecbc08a44a4e166c06659911881f383d4473e94f', 'Member');

-- Insert Books
INSERT INTO Books (Title, Genre, Condition, IsBorrowed) VALUES
('The Great Gatsby', 'Fiction', 'Good', 0),
('To Kill a Mockingbird', 'Fiction', 'Fair', 0),
('1984', 'Fiction', 'New', 0),
('Clean Code', 'NonFiction', 'Good', 0),
('Design Patterns', 'NonFiction', 'Good', 0),
('Harry Potter and the Sorcerer''s Stone', 'Children', 'Good', 0),
('Where the Wild Things Are', 'Children', 'Fair', 0),
('Oxford English Dictionary', 'Reference', 'Good', 0);
```

---

## 🚀 Installation & Setup

### **Prerequisites:**
- Visual Studio 2019 or later
- .NET Framework 4.7.2 or higher
- SQL Server (LocalDB or Express)

### **Step-by-Step Installation:**

1. **Clone/Download the Project**
```
   Extract the project to your desired location
```

2. **Open in Visual Studio**
```
   Double-click LibrarySystem.sln

Create Database

Open SQL Server Management Studio (SSMS)
Connect to (localdb)\MSSQLLocalDB
Run the database script (provided above)


Verify Connection String

csharp   // In DatabaseHelper.cs
   private string connectionString = 
       "Server=(localdb)\\MSSQLLocalDB;Database=LibrarySystem;Integrated Security=true";
```

5. **Build Solution**
```
   Build → Build Solution (Ctrl+Shift+B)
```

6. **Run Application**
```
   Debug → Start Debugging (F5)

📋 System Features
🔐 Authentication System

✅ SHA-256 password hashing
✅ Role-based access control (Admin/Member)
✅ Secure login validation
✅ Session management

👨‍💼 Admin Features
Book Management (CRUD):

Create - Add new books to inventory

Input: Title, Genre, Condition
Validation: Required fields
Default: IsBorrowed = false


Read - View all books

Display all books in database
LINQ Grouping: View books grouped by genre
Show borrowing status (Available/Borrowed)


Update - Edit book details

Modify: Title, Genre, Condition
Cannot modify BookId


Delete - Remove books

Validation: Cannot delete borrowed books
Permanent deletion from database



Loan Management:

View all loans across all members
See borrowing history
Monitor due dates

#👤 Member Features
Book Borrowing:

View available books by genre
Select book to borrow
Automatic due date calculation (14 days)
Transaction recording

Book Returning:

View borrowed books
Select book to return
Update loan status
Update book availability

Personal Loans:

View own borrowing history
See active loans
Check due dates


#🎯 Key Technologies
Programming Concepts:

✅ MVC Architecture (Model-View-Controller)
✅ Object-Oriented Programming (OOP)

Encapsulation (Private fields, public properties)
Inheritance (Model base classes)
Polymorphism (Method overriding)


✅ LINQ (Language Integrated Query)

GroupBy for data organization
Where for filtering
OrderBy for sorting


✅ ADO.NET for database operations
✅ SQL Transactions for data integrity

Security:

✅ SHA-256 Cryptographic Hashing
✅ Parameterized SQL Queries (SQL Injection prevention)
✅ Role-based authorization

Database:

✅ SQL Server (LocalDB)
✅ Relational database design
✅ Foreign key relationships
✅ Transaction management


📊 LINQ Grouping Example
Grouping Books by Genre:
csharp// In MainController.cs
public Dictionary<string, List<Book>> GetBooksGroupedByGenre()
{
    List<Book> allBooks = dataAccess.GetAllBooks();
    
    return allBooks
        .GroupBy(b => b.Genre)              // Group by Genre
        .OrderBy(g => g.Key)                // Sort alphabetically
        .ToDictionary(g => g.Key, g => g.ToList());  // Convert to Dictionary
}

// Display Example:
Fiction:
  - The Great Gatsby (Good) [AVAILABLE]
  - 1984 (New) [BORROWED]

NonFiction:
  - Clean Code (Good) [AVAILABLE]

Children:
  - Harry Potter (Good) [AVAILABLE]
```

---

## 🔄 Application Flow

### **Login Process:**
```
1. User starts application
   ↓
2. Enter Username & Password
   ↓
3. System hashes password (SHA-256)
   ↓
4. Compare with database hash
   ↓
5. If match → Check role
   ↓
6. Admin → Admin Menu
   Member → Member Menu
```

### **Borrowing Flow:**
```
1. Member selects "Borrow Book"
   ↓
2. View available books
   ↓
3. Select book by ID
   ↓
4. System checks:
   - Book exists?
   - Book available (not borrowed)?
   ↓
5. Create Loan record:
   - BorrowDate = Today
   - DueDate = Today + 14 days
   - ReturnDate = NULL
   ↓
6. Update Book.IsBorrowed = true
   ↓
7. Display success message
```

### **Returning Flow:**
```
1. Member selects "Return Book"
   ↓
2. View borrowed books
   ↓
3. Select book to return
   ↓
4. Update Loan.ReturnDate = Today
   ↓
5. Update Book.IsBorrowed = false
   ↓
6. Display success message
```

---

## 🎨 Console Interface

### **Login Screen:**
```
╔════════════════════════════════════╗
║   LIBRARY MANAGEMENT SYSTEM        ║
╚════════════════════════════════════╝

Username: admin
Password: ********

[Login]

Status: Connected to database
```

### **Admin Menu:**
```
╔════════════════════════════════════╗
║          ADMIN MENU                ║
╚════════════════════════════════════╝

1. View All Books
2. View Books by Genre (LINQ Grouping)
3. Add Book
4. Update Book
5. Delete Book
6. View All Loans
99. Logout

Select option: _
```

### **Member Menu:**
```
╔════════════════════════════════════╗
║         MEMBER MENU                ║
╚════════════════════════════════════╝

1. View Available Books
2. Borrow Book
3. Return Book
4. View My Loans
99. Logout

Select option: _
```

---

## 🧪 Testing the Application

### **Test Scenario 1: Admin Login & Book Management**
```
1. Login as admin (admin/admin123)
2. View all books
3. Add new book:
   - Title: "The Hobbit"
   - Genre: "Fiction"
   - Condition: "New"
4. View books by genre (LINQ grouping)
5. Logout
```

### **Test Scenario 2: Member Borrowing**
```
1. Login as john (john/pass123)
2. View available books
3. Borrow book ID 1
4. View my loans (verify loan appears)
5. Logout
```

### **Test Scenario 3: Member Returning**
```
1. Login as john (john/pass123)
2. View my loans
3. Return book ID 1
4. View available books (verify book is available again)
5. Logout
```

---

## 🐛 Troubleshooting

### **Common Issues:**

#### **1. Database Connection Failed**
```
Error: Cannot connect to database

Solution:
- Verify SQL Server is running
- Check connection string in DatabaseHelper.cs
- Ensure database "LibrarySystem" exists
- Run database creation script
```

#### **2. Login Failed - Invalid Credentials**
```
Error: Invalid username or password

Solution:
- Verify username spelling (case-sensitive)
- Use correct password (admin123 or pass123)
- Check database has members with hashed passwords
- Re-run member INSERT script
```

#### **3. Cannot Borrow Book**
```
Error: Book already borrowed

Solution:
- Book is already borrowed by someone else
- Check book status: SELECT * FROM Books WHERE BookId = X
- Return book first, then try borrowing again

📝 Code Standards
Naming Conventions:

Classes: PascalCase (AuthenticationController)
Methods: PascalCase (HashPassword())
Variables: camelCase (userName, passwordHash)
Private fields: camelCase with underscore (_dataAccess)
Constants: UPPER_CASE (MAX_LOAN_DAYS)

Best Practices Implemented:

✅ Separation of Concerns (MVC)
✅ DRY Principle (Don't Repeat Yourself)
✅ Single Responsibility Principle
✅ Parameterized queries (SQL injection prevention)
✅ Using statements for resource disposal
✅ Try-catch error handling
✅ Meaningful variable names


📚 Project Statistics

Total Files: 10+
Lines of Code: ~1,500
Development Time: 2.5 hours
Database Tables: 3
User Roles: 2 (Admin, Member)
CRUD Operations: Complete
Security Level: SHA-256 encrypted passwords


🎓 Learning Outcomes
This project demonstrates proficiency in:

✅ MVC Architecture - Proper separation of concerns
✅ Database Design - Relational database with foreign keys
✅ Security - Password hashing and authentication
✅ LINQ - Data querying and grouping
✅ ADO.NET - Database connectivity and operations
✅ OOP Principles - Encapsulation, inheritance, polymorphism
✅ Transaction Management - Data integrity
✅ Error Handling - Try-catch blocks
✅ User Experience - Clear menus and feedback


👨‍💻 Author
Student Project

Platform: Visual Studio 2022
Framework: .NET Framework 4.7.2
Language: C#
Database: SQL Server (LocalDB)


📄 License
This is an educational project for academic purposes.

🎉 Acknowledgments

Developed as part of Software Engineering coursework
Demonstrates MVC architecture and secure authentication
Implements industry-standard password hashing (SHA-256)


📞 Support
For issues or questions:

Check Troubleshooting section
Verify database connection
Ensure all dependencies installed
Review login credentials
