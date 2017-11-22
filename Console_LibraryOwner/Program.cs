using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_LibraryOwner.WCF_LibraryManager;
namespace Console_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            PopulateLibrary();

            SearchBooks();

            Console.ReadKey();
        }

        public static void PopulateLibrary()
        {
            var cli = new LibraryManagerClient();
            cli.Open();
            cli.AddBook("123", "A22", "C# For Dummmies", "Martin Fowler", "Programming");
            cli.AddBook("1234", "A21", "Japanese Cooking", "Nakamoto", "Cooking");
            cli.AddBook("1235", "A27", "How to be Rich", "Jonathan Martin", "SelfHelping");
            cli.AddBook("12376", "A28", "Java Spring", "Michael Jr", "Programming");
            cli.AddBook("1235000", "A30", "Body Language Expert", "Jonathan Martin", "SelfHelping");
            cli.AddBook("1234", "A45", "Cool Places in Japan", "Nakamoto", "Tourism");
            cli.Close();
        }

        public static void SearchBooks()
        {
            var cli = new LibraryManagerClient();
            var books = cli.GetBooksBySubject("SelfHelping");
            Console.WriteLine("Books of SelfHelping");
            PrintBooks(books);

            Console.WriteLine("\n\n\n");

            books = cli.GetBooksByAuthor("Nakamoto");
            Console.WriteLine("Books from Nakamoto");
            PrintBooks(books);

            Console.WriteLine("\n\n\n");

            cli.Close();
        }

        public static void PrintBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine("Author : " + book.Author);
                Console.WriteLine("Code : " + book.Code);
                Console.WriteLine("Title : " + book.Title);
                Console.WriteLine("Subject : " + book.Subject);
                Console.WriteLine("--------------------------");
            }
        }
    }
}
