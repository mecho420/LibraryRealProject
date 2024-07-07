﻿using System;
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
        public string author;
        private bool availability;

        public int isbn { get;  set; }
        public string title { get;  set; }
        public int year { get;  set; }

        public string borrower { get;  set; }
        public bool BooksAvailable
        {
            get
            {
                return availability;
            }
             set
            {
                booksAvailable = value;
            }
        }
       
        public double Price
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

        public Books(int isbn, string title, string author, int year, double price, string borrower)
        {
            this.isbn = isbn;
            this.title = title;
            this.year = year;
            this.borrower = borrower;
            this.booksAvailable = true;
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

        public Books(int isbn, string title, string author, string year1)
        {
            this.isbn = isbn;
            this.title = title;
            this.author = author;
        }

        public Books(int isbn, string title, string author, string year1, string price1) : this(isbn, title, author, year1)
        {
        }

        public override string ToString()
        {
            return $"{isbn},{title},{author},{year},{this.Price},{booksAvailable},{borrower}";
        }
    }
}
