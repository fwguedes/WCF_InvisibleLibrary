using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_LibraryDeskService.Exception;
using WCF_LibraryDeskService.ServiceReference1;

namespace WCF_LibraryDeskService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class LibraryDesk : ILibraryDesk
    {
        public bool BorrowBook(string code)
        {
            using(var cli = new LibraryManagerClient())
            {
                cli.Open();
                var book = cli.GetBooksByCode(code);

                if (book == null)
                    throw new BookNotFoundException($"Book Code {code} Not Found");

                if (book.IsBorrowed)
                    throw new BookBorrowedException("Book already borrowed");

                cli.UpdateToBorrowed(book.Id);

                cli.Close();
            }

            return true;
        }

        public bool ReturnBook(string code)
        {
            using (var cli = new LibraryManagerClient())
            {
                cli.Open();
                var book = cli.GetBooksByCode(code);

                if (book == null)
                    throw new BookNotFoundException($"Book Code {code} Not Found");

                if (! book.IsBorrowed)
                    throw new BookReturnedException("Book already returned");

                cli.UpdateToAvaible(book.Id);

                cli.Close();
            }

            return true;
        }
    }
}
