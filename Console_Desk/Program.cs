using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Desk.WCF_LibraryDesk;
using System.Threading;

namespace Console_Desk
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(Program.TakeBookFilipe);
            Thread t2 = new Thread(Program.TakeBookFilipe);

            t1.Start();
            t2.Start();

            Console.ReadKey();

        }

        public static void TakeBookFilipe()
        {
            var cli = new LibraryDeskClient();
            var clientName = "Filipe";
            cli.Open();
            try
            {
                cli.Authenticate(clientName);

                var response = cli.BorrowBook("A22", clientName, DateTime.Now);
                Console.WriteLine("Livro Pego");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            cli.Close();           
        }

        public static void TakeBookJoao()
        {
            var cli = new LibraryDeskClient();
            var clientName = "Joao";
            cli.Open();
            try
            {
                cli.Authenticate(clientName);

                var response = cli.BorrowBook("A22", clientName, DateTime.Now);
                Console.WriteLine("Livro Pego");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            cli.Close();
        }
    }
}
