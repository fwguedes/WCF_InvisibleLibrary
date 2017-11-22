using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Desk.WCF_LibraryDesk;

namespace Console_Desk
{
    class Program
    {
        static void Main(string[] args)
        {
            var cli = new LibraryDeskClient();
            cli.Open();
            try
            {
                var response = cli.BorrowBook("A22");
                Console.WriteLine("Livro Pego");

                response = cli.BorrowBook("A22");
            }catch(Exception ex)
            {
                Console.WriteLine("Livro nao disponivel");
            }
            
            cli.Close();

        }
    }
}
