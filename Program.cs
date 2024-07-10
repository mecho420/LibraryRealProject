using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace LibraryRealProject
{
    internal class Program
    {
        private const string filePath = "../../BooksList.txt";
        private static string soundFilePath = "../../enchantingsound.wav";
        private static string soundFilePath2 = "../../villagerHit.wav";
        private static string soundFilePath3 = "../../tnt-explosion";
        private static List<Books> bookList = new List<Books>();
        private static string menuActionChoice;

        static void Main(string[] args)
        {
            // Да може да чете кирилица
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            PrintMenu();
            ReadData();


            // MENU
            while (true)
            {
                menuActionChoice = Console.ReadLine();

                switch (menuActionChoice)
                {
                    case "1":

                        ShowActionTitle("Добавяне на нова книга в библиотеката");
                        PlayEnchantingSound();
                        AddNewBook();
                        break;
                    case "2":
                        ShowActionTitle("Заемане на книга от читател");
                        PlayEnchantingSound();
                        BorrowABook();
                        break;
                    case "3":
                        ShowActionTitle("Връщане на книга от читател");
                        PlayEnchantingSound();
                        ReturnABoook();
                        break;
                    case "4":
                        ShowActionTitle("Справка за всички книги в библиотката");
                        PlayEnchantingSound();
                        ReferenceForAllAvailiableBooks();
                        break;
                    case "5":
                        ShowActionTitle("Справка за заетите книги и техните наематели");
                        PlayEnchantingSound();
                        ReferenceForAllUnavailiableBooksAndTheirTenants();
                        break;
                    case "x":
                    case "X":
                        PlayexplosionSound();
                        Exit();
                        break;
                    default:
                        ShowActionTitle("Въведете валидна опция!");
                        PlayAngrySound();
                        BackToMenu();

                        break;
                }
                BackToMenu();
            }
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }

        private static void ReferenceForAllUnavailiableBooksAndTheirTenants()
        {
            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].Availability == false)
                {
                    Console.WriteLine(bookList[i].PrintBookUnavailable());
                }
            }
        }

        private static void ReferenceForAllAvailiableBooks()
        {
            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].Availability)
                {
                    Console.WriteLine(bookList[i].PrintBook());
                }
            }
        }

        private static void ReturnABoook()
        {
            Console.WriteLine("Моля изберете книга(isbn) за връщане: ");
            string inputIsbn = Console.ReadLine();
            Books bookToBorrow = bookList.Find(b => b.isbn == inputIsbn);
            if (bookToBorrow != null)
            {
                if (bookToBorrow.Availability == true)
                {
                    Console.WriteLine("Книгата е върната.");
                    PlayAngrySound();
                    return;
                }
                bookToBorrow.Availability = true;
                bookToBorrow.Borrower = "-";
                Console.WriteLine("Книгита е върната успешно");
                PlayEnchantingSound();
                WriteData();
            }
        }

        private static void BorrowABook()
        {
            Console.Write("Въведете isbn на книгата: ");

            string inputIsbn = Console.ReadLine();
            Books bookToBorrow = bookList.Find(b => b.isbn == inputIsbn);
            if (bookToBorrow != null)
            {
                if (bookToBorrow.Availability == false)
                {
                    Console.WriteLine("Книгата е заета.");
                    PlayAngrySound();
                    return;
                }
                bookToBorrow.Availability = false;
                Console.Write("Въведете име: ");
                string name = bookToBorrow.Borrower = Console.ReadLine();
                CheckingBorrowersLength(name);
                bookToBorrow.Borrower = Console.ReadLine();
                Console.WriteLine("Книгита е заета успешно");
                PlayEnchantingSound();
                WriteData();
            }
            else
            {
                Console.WriteLine("Няма такава книга!");
                PlayAngrySound();
            }

        }
        public bool IsBookInLibrary(string title)
        {
            foreach (var book in bookList)
            {
                if (book.title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    return true; // Book found
                }

            }
            return false; // Book not found
        }
        private static void AddNewBook()
        {
            while (true)
            {
                Console.Write("Код на книгата: ");
                string isbn = Console.ReadLine();
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
                    Books newBook = new Books();//ako ne e null da e ""
                    newBook.isbn = isbn;
                    newBook.author = author;
                    newBook.year = int.Parse(year);
                    newBook.Price = decimal.Parse(price);
                    newBook.Borrower = "-";
                    newBook.title = title;
                    newBook.Availability = true;
                    bookList.Add(newBook);
                    WriteData();
                    ShowResultMessage($"Книгата {title} е добавена успешно");
                    PlayEnchantingSound();
                    Console.WriteLine(newBook);
                    Console.WriteLine(price);
                    break;
                }
                catch (Exception)
                {

                    ShowResultMessage($"Въвели сте невалидни данни");
                    PlayAngrySound();
                }
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
        private static void PlayEnchantingSound()
        {
            SoundPlayer player = new SoundPlayer(soundFilePath);
            player.PlaySync();
        }
        private static void PlayexplosionSound()
        {
            SoundPlayer player = new SoundPlayer(soundFilePath3);
            player.PlaySync();
        }
        private static void PlayAngrySound()
        {
            SoundPlayer player = new SoundPlayer(soundFilePath2);
            player.PlaySync();
        }

        private static void WriteData()
        {
            StreamWriter writer = new StreamWriter(filePath, false, Encoding.Unicode);
            using (writer)
            {
                foreach (Books book in bookList)
                {
                    writer.WriteLine(book.ToString());
                }
            }
        }
        private static void ReadData()
        {
            StreamReader reader = new StreamReader(filePath, Encoding.Unicode);
            using (reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] bookInfo = line.Split(',');

                    Books book = new Books();
                    book.isbn = bookInfo[0];
                    book.title = bookInfo[1];
                    book.author = bookInfo[2];
                    book.year = int.Parse(bookInfo[3]);
                    book.Price = decimal.Parse(bookInfo[4].Replace('.', ','));
                    book.Availability = bool.Parse(bookInfo[5]);
                    book.Borrower = bookInfo[6];

                    bookList.Add(book);
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

        private static void CheckingBorrowersLength(string borrower)
        {
            if (borrower.Length <= 2)
            {
                Console.WriteLine("Моля въведете име по-дълго от 2 букви.");
            }
        }
    }
}