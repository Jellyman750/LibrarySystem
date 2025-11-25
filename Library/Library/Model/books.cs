using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class books
    {
        private int bookId;
        private string title;
        private string genre;
        private string condition;
        private bool isBorrowed;

        public int BookId { get => bookId; set => bookId = value; }
        public string Title { get => title; set => title = value; }
        public string Genre { get => genre; set => genre = value; }
        public string Condition { get => condition; set => condition = value; }
        public bool IsBorrowed { get => isBorrowed; set => isBorrowed = value; }

        public books(int bookId_,string title_,string genre_,string condition_,bool isBorrowed_)
        {
            this.bookId = bookId_;
            this.title = title_;
            this.genre = genre_;
            this.condition = condition_;
            this.isBorrowed = isBorrowed_;
        }

        public string toString()
        {
            return $"Book ID: {BookId}, Title:{Title}, Genre: {Genre}, Condition: {Condition}, is Borrowed: {IsBorrowed}";
        }
    }
}
