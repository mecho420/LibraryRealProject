using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryRealProject
{
    internal class Books
    {
        private decimal price;
        public string author;
        private bool availability;

        public string isbn { get;  set; }
        public string title { get;  set; }
        public int year { get;  set; }

        public string Borrower { get;  set; }
        public bool Availability
        {
            get
            {
                return availability;
            }
             set
            {
                availability = value;
            }
        }
       
        public decimal Price
        {
            get
            {
                return price;
            }
             set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Цената на книгата трябва да е  положително число!");
                }
                else
                {
                    price= value;
                }
            }
        }

        public Books(string isbn, string title, string author, int year, double price, string borrower)
        {
            this.isbn = isbn;
            this.title = title;
            this.year = year;
            this.Borrower = borrower;
            this.Availability = true;
        }

        public Books()
        {
        }

        public Books(string isbn, string title, string author, int year, decimal price, bool availability, string borrower)
        {
            this.isbn = isbn;
            this.title = title;
            this.author = author;
            this.year = year;
            this.price = price;
            this.availability = availability;
            this.Borrower = borrower;
        }

        public Books(string isbn, string title, string author, string year1)
        {
            this.isbn = isbn;
            this.title = title;
            this.author = author;
        }

        public Books(string isbn, string title, string author, string year1, string price1) : this(isbn, title, author, year1)
        {
        }

        public override string ToString()
        {
            return $"{isbn},{title},{author},{year},{this.price},{availability},{Borrower}";
        }
        public string PrintBook()
        {
            return $"ISBN: {isbn}\nКнига: {title}\nАвтор: {author}\nГодина на издаване: {year}\nЦена: {this.price}\n";
        }
        public string PrintBookUnavailable()
        {
            return $"ISBN: {isbn}\nКнига: {title}\nАвтор: {author}\nГодина на издаване: {year}\nЦена: {this.price}\nЗаемател: {Borrower}\n";
        }
    }
}
