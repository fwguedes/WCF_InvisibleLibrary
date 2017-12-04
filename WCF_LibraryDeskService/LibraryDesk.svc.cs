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

        private static int MAX_BOOKS_ALLOWED = 1;
        private static int MAX_DAYS_ALLOWED = 15;
        private static int FINE = 2;
        private static IList<string> clients;
        private static bool authenticated = false;

        public LibraryDesk()
        {
            clients = new List<string>()
            {
                "Filipe"
            };
        }

        public void Authenticate(string client)
        {
            if (clients.Any(c => c == client))
                authenticated = true;
            else
                throw new FaultException<ClientNotFoundException>(new ClientNotFoundException($"Client Not Found.Can't Authenticate"));
        }

        public bool BorrowBook(string code, string client, DateTime date)
        {
            if (!authenticated)
                throw new FaultException<NotAuthenticatedException>(new NotAuthenticatedException($"Restricted Area"));

            using (var cli = new LibraryManagerClient())
            {
                cli.Open();
                
                var book = cli.GetBooksByCode(code);

                if (book == null)                  
                    throw new FaultException<BookNotFoundException>(new BookNotFoundException($"Book Code {code} Not Found"));
                
                if (book.IsBorrowed)
                    throw new FaultException<BookBorrowedException>(new BookBorrowedException($"Book Code {code} already borrowed"));

                var loans = cli.GetLoansFromClient(client);

                if (loans.Count == MAX_BOOKS_ALLOWED)
                    throw new FaultException<MaximumExceededException>(new MaximumExceededException($"You cannot borrow more than {MAX_BOOKS_ALLOWED} books"));

                cli.UpdateToBorrowed(book.Id, client,date);

                cli.Close();
            }

            return true;
        }

        public bool ReturnBook(string code, string client, DateTime date)
        {

            if (!authenticated)
                throw new FaultException<NotAuthenticatedException>(new NotAuthenticatedException($"Restricted Area"));


            using (var cli = new LibraryManagerClient())
            {
                cli.Open();
                var book = cli.GetBooksByCode(code);

                if (book == null)
                   throw new FaultException<BookNotFoundException>(new BookNotFoundException($"Book Code {code} Not Found"));

                if (! book.IsBorrowed)
                    throw new FaultException<BookReturnedException>(new BookReturnedException($"Book Code {code} already returned"));

                var loan = cli.GetLoan(book.Id);

                var delay = date - loan.LoanDate;

                if(delay.Days > MAX_DAYS_ALLOWED)
                     throw new FaultException<FineException>(new FineException($"Fine of $ {(delay.Days - MAX_DAYS_ALLOWED) * FINE }"));
               
                cli.UpdateToAvaible(book.Id, client, date);

                cli.Close();
            }

            return true;
        }
    }
}
