using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryRealProject
{
    internal class Program
    {
        private const string filePath = "BooksList.txt";
        private static List<Books> bookList = new List<Books>();
        private static string menuActionChoice;

        static void Main(string[] args)
        {
            // Да може да чете кирилица
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            PrintMenu();

            // MENU
            while (true)
            {
                menuActionChoice = Console.ReadLine();
                switch (menuActionChoice)
                {
                    case "1":
                        ShowActionTitle("Добавяне на нова книга в библиотеката");
                        AddNewBook();
                        break;
                    case "2":
                        ShowActionTitle("Заемане на книга от читател");
                        BorrowABook();
                        break;
                    case "3":
                        ShowActionTitle("Връщане на книга от читател");
                        ReturnABoook();
                        break;
                    case "4":
                        ShowActionTitle("Справка за всички книги в библиотката");
                        ReferenceForAllBooks();
                        break;
                    case "5":
                        ShowActionTitle("Справка за заетите книги и техните наематели");
                        ReferenceForAllBooksAndTheirTenants();
                        break;
                    case "x": 
                    case "X":
                        Exit();
                        break;
                    default:
                        // todo: implement default case

                        break;
                }
            }
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }

        private static void ReferenceForAllBooksAndTheirTenants()
        {
            throw new NotImplementedException();
        }

        private static void ReferenceForAllBooks()
        {
            throw new NotImplementedException();
        }

        private static void ReturnABoook()
        {
            
        }

        private static void BorrowABook()
        {
            throw new NotImplementedException();
        }

        private static void AddNewBook()
        {
            Console.Write("Код на книгата: ");
            int isbn = int.Parse(Console.ReadLine());
            Console.Write("Заглавие на книгата: ");
            string title = Console.ReadLine();
            Console.Write("Автор на книгата: ");
            string author = Console.ReadLine();
            Console.Write("Година на издаване: ");
            string year = Console.ReadLine();
            Console.Write("Цена на книгата: ");
            string price = Console.ReadLine();
            try
            {
                Books newBook = new Books(isbn, title, author, year, price);
                bookList.Add(newBook);
                WriteData();
                ShowResultMessage($"Книгата{title} е добавена успешно");
                Console.WriteLine(bookList);
            }
            catch (Exception)
            {

                ShowResultMessage($"Въвели сте невалидни данни");
            }
            BackToMenu();
        }
        private static void BackToMenu()
        {
            AddLine();
            Console.Write("\tНатисни произвлен клавиш обратно към МЕНЮ: ");
            Console.ReadLine();
            PrintMenu();
        }

        private static void WriteData()
        {
            StreamWriter writer = new StreamWriter(filePath, false, Encoding.Unicode);
            using (writer)
            {
                foreach (Books book in bookList)
                {
                    writer.WriteLine(bookList);
                }
            }
        }
        private void ReadData(string filePath)
        {
            StreamReader reader = new StreamReader(filePath, Encoding.Unicode);
            using (reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] bookInfo = line.Split(',');
                    Books book = new Books();

                    int isbn = int.Parse(bookInfo[0]);
                    string title = bookInfo[1];
                    string author = bookInfo[2];
                    int year = int.Parse(bookInfo[3]);
                    double price = double.Parse(bookInfo[4]);
                    bool availability = bool.Parse(bookInfo[5]);
                    string borrower = bookInfo[6];

                    Books currentBook = new Books(isbn, title, author, year, price, availability, borrower);
                    bookList.Add(currentBook);
                }
            }
        }

        private static void ShowActionTitle(string title)
        {
            Console.Clear();
            AddLine();
            Console.WriteLine("\t" + title);
            AddLine();
        }

        private static void AddLine(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(Environment.NewLine);
            }
        }

        private static void PrintMenu()
        {
            Console.Clear();

            AddLine();
            Console.WriteLine("\tМ Е Н Ю");
            AddLine();
            Console.WriteLine("\tМоля изберете желаното действие:");
            AddLine();
            Console.WriteLine("\t[1]: Добавяне на нова книга в библиотеката");
            Console.WriteLine("\t[2]: Заемане на книга от читател");
            Console.WriteLine("\t[3]: Връщане на книга от читател");
            Console.WriteLine("\t[4]: Справка за всички книги в библиотката");
            Console.WriteLine("\t[5]: Справка за заетите книги и техните наематели");
            Console.WriteLine("\t[x]: Изход от програмата");
            AddLine();
            Console.Write("\tВашият избор: ");
        }
        private static void ShowResultMessage(string message)
        {
            AddLine();
            Console.WriteLine("\t" + message);
        }
    }
}