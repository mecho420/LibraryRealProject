using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryRealProject
{
    internal class Program
    {
        private string filePath = "BooksList.txt";
        List<Books> bookList = new List<Books>();

        static void Main(string[] args)
        {
            // Да може да чете кирилица
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
        }

        static void ReadData(string filePath)
        {
            StreamReader reader = new StreamReader(filePath, Encoding.Unicode);
            using (reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] bookInfo = line.Split(',');
                    Books book = new Books();
                }
            }
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
    }
}
