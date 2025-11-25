using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.View
{
    public class viewFunctions
    {


        public void viewAllBooks(List<books> book)
        {

            Console.WriteLine("Here is a list of all the books: ");
            foreach (books b in book)
            {
                Console.WriteLine($"Book ID: {b.BookId,5}| Title: {b.Title,10}| Genre: {b.Genre,15}| Condition: {b.Condition,20}| Is Borrowed:{b.IsBorrowed,25}");

            }
        }

        public void viewAllBooksLoans(List<loans> loans)
        {
            Console.WriteLine("Here is a list of all the books that have been loaned: ");
            foreach (loans l in loans)
            {
                Console.WriteLine($"Loan ID: {l.LoanId,5}| Member ID: {l.MemeberId,10}| Book ID:  {l.BookId,15}| Borrow Date: {l.BorrowDate,20}| Due Date:{l.DueDate,25}| ReturnDate: {l.ReturnDate,30}");

            }
        }

        public books InsertAnewBook()
        {


            Console.Write("Please enter in the Book ID: ");
            int Bookid = int.Parse(Console.ReadLine());

            Console.Write("Please enter in your Book title: ");
            string title = Console.ReadLine();

            Console.Write("Please enter in your genre: ");
            string genre = Console.ReadLine();

            Console.Write("Please enter in your Condition of the book: ");
            string condition = Console.ReadLine();

            return new books(Bookid, title, genre, condition, false);



        }


        public books UpdateABook()
        {

            Console.Write("Please enter in the Book ID: ");
            int Bookid = int.Parse(Console.ReadLine());

            Console.Write("Please enter in your Book title: ");
            string title = Console.ReadLine();

            Console.Write("Please enter in your genre: ");
            string genre = Console.ReadLine();

            Console.Write("Please enter in your Condition of the book: ");
            string condition = Console.ReadLine();

            return new books(Bookid, title, genre, condition, false);

        }

        public books DeletABook()
        {


            Console.Write("Please enter in the Book ID: ");
            int Bookid = int.Parse(Console.ReadLine());

            Console.WriteLine("Are you sure you want to Delete this book(yes/no) :");
            string ans = Console.ReadLine();
            if (ans.Equals("yes", StringComparison.OrdinalIgnoreCase)) {
                Console.WriteLine("Book has been deleted");
            }
            return new books(Bookid, "", "", "", false);

        }

        public books BorrowBook()
        {

            Console.Write("Please enter in the Book ID you want to borrow: ");
            int BookId = int.Parse(Console.ReadLine());

            Console.Write("Please enter in your member ID : ");
            int memberId = int.Parse(Console.ReadLine());

            Console.WriteLine("The book has succesfully be borrowed");

            return new books(BookId, "", "", "", true);

        }

      

        public books ReturnBook()
        {
            Console.Write("Please enter in the Book ID you want to return: ");
                int BookId = int.Parse(Console.ReadLine());


                Console.WriteLine("The book has succesfully be returned");

            return new books(BookId, "", "", "", true);
        }
           

        }
    }

