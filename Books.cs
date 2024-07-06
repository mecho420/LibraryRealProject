using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryRealProject
{
    internal class Books
    {
        private bool booksAvailable;
        private double price;
        private string author;
        private bool availability;

        public int isbn { get; private set; }
        public string title { get; private set; }
        public int year { get; private set; }

        public string borrower { get; private set; }
        public bool BooksAvailable
        {
            get
            {
                return string.IsNullOrEmpty(borrower);
            }
            private set
            {
                booksAvailable = string.IsNullOrEmpty(borrower);
            }
        }
       
        public double Price
        {
            get
            {
                return price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Цената на книгата трябва да е  положително число!");
                }
            }
        }

        public Books(int isbn, string title, string author, int year, double price, string borrower)
        {
            this.isbn = isbn;
            this.title = title;
            this.year = year;
            this.borrower = borrower;
            this.booksAvailable = string.IsNullOrEmpty(borrower);
        }

        public Books()
        {
        }

        public Books(int isbn, string title, string author, int year, double price, bool availability, string borrower)
        {
            this.isbn = isbn;
            this.title = title;
            this.author = author;
            this.year = year;
            this.price = price;
            this.availability = availability;
            this.borrower = borrower;
        }

        public override string ToString()
        {
            return $"{isbn},{title},{year.ToString()},{borrower},{booksAvailable}";
        }
    }
}
