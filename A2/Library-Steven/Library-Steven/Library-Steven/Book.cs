using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Steven
{
    public class Book
    {
        // define a primary key
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string IsbnNumber{ get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool BorrowingStatus { get; set; }
        public string Borrower { get; set; }

        public Book()
        {
        }

        // this is the constructor that will be used to
        // create new items
        public Book(string isbn, string title, string author, bool borrowingStatus = false, string borrower = "")
        {
            this.IsbnNumber = isbn;
            this.Title = title;
            this.Author = author;
            this.BorrowingStatus = borrowingStatus;
            this.Borrower = borrower;
        }

        public void Add(string isbn, string title, string author, bool borrowingStatus = false, string borrower = "")
        {
            this.IsbnNumber = isbn;
            this.Title = title;
            this.Author = author;
            this.BorrowingStatus = borrowingStatus;
            this.Borrower = borrower;
        }
        public override string ToString()
        {
            return $"{this.Title} {this.Author}";
        }

    }
}
