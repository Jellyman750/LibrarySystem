using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class loans
    {

        private int loanId;
        private int memeberId;
        private int bookId;
        private DateTime borrowDate;
        private DateTime dueDate;
        private DateTime returnDate;

        public int LoanId { get => loanId; set => loanId = value; }
        public int MemeberId { get => memeberId; set => memeberId = value; }
        public int BookId { get => bookId; set => bookId = value; }
        public DateTime BorrowDate { get => borrowDate; set => borrowDate = value; }
        public DateTime DueDate { get => dueDate; set => dueDate = value; }
        public DateTime ReturnDate { get => returnDate; set => returnDate = value; }

        public loans(int loanId_,int memberId_,int bookId_,DateTime borrowDate_,DateTime DueDate_,DateTime ReturnDate_)
        {
            this.loanId = loanId_;
            this.memeberId = memberId_;
            this.bookId = bookId_;
            this.borrowDate = borrowDate_;
            this.dueDate = DueDate_;
            this.returnDate = ReturnDate_;

        }
        public string toString()
        {
            return $"Loan ID: {LoanId}, Member ID: {MemeberId}, Book ID: {BookId}, Borrow Date:{BorrowDate}, Due Date:{DueDate},Return Date: {ReturnDate}";
        }
    }
}
