using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Library.DataAccess;
using Library.Model;
using Library.View;

namespace Library.Controller
{
    public class MainController
    {
        private databaseHelper m;
        private viewFunctions v;

        public MainController(databaseHelper m_, viewFunctions v_)
        {
            this.m = m_;
            this.v = v_;
        }

        public Dictionary<string,List<books>> GetGroupedBooks()
        {
            return null;
        }

        public void viewAllBooks()
        {
            List<books> b = m.viewAllBooks();
            v.viewAllBooks(b);
        }

        public void viewAllLoans()
        {
            List<loans> l = m.viewAllLoans();
            v.viewAllBooksLoans(l);
        }

        public void InsertBooks()
        {
            books b = v.InsertAnewBook();
            m.InsertNewBook(b.Title, b.Genre, b.Condition);
        }

        public void updateBooks()
        {
            books b = v.UpdateABook();
            m.updateBooK(b.BookId, b.Title, b.Genre, b.Condition);
        }

        public void DeleteBooks()
        {
            books b = v.DeletABook();
            m.DeleteABook(b.BookId);
        }

        public void ReturnBook()
        {
            books b = v.ReturnBook();
            m.ReturnBook(b.BookId);

        }

       /* public void BorrowBook()
        { books b;
            members mem;
            string username = mem.Username();
            mem = m.getMemberByUsername(username);
            b = v.BorrowBook();
            m.BorrowBook(b.BookId);

        }*/


    }
}
