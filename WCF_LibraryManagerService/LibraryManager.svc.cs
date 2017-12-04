using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_LibraryManagerService.WCFBookService;

namespace WCF_LibraryManagerService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class LibraryManager : ILibraryManager
    {
        private static ConcurrentDictionary<Guid, Book> books = new ConcurrentDictionary<Guid, Book>();
        private static IList<Loan> loans = new List<Loan>();
      
        public void AddBook(string isbn, string code, string title, string author, string subject)
        {
            Book newBook;

            using (var cli = new BookServiceClient())
            {
                cli.Open();
                newBook = cli.CreateBook(isbn, code, title, author, subject);
                cli.Close();
            }

            if (newBook != null)
                books.TryAdd(newBook.Id, newBook);
        }

        public IList<Book> GetAllBooks()
        {
            return books.Values.ToList();
        }

        public IList<Book> GetBooksByAuthor(string author)
        {
            return GetAllBooks().Where(b => b.Author.Equals(author)).ToList();
        }

        public Book GetBooksByCode(string code)
        {
            return GetAllBooks().FirstOrDefault(b => b.Code.Equals(code));
        }

        public IList<Book> GetBooksBySubject(string subject)
        {
            return GetAllBooks().Where(b => b.Subject.Equals(subject)).ToList();
        }

        public void UpdateToAvaible(Guid id, string client, DateTime date)
        {
                        
            Book book = books[id];
            book.IsBorrowed = false;
            var updated = books.TryUpdate(id, book, book);

            if (updated)
            {
                var thisLoan = loans.FirstOrDefault(l => l.IdBook == id);
                loans.Remove(thisLoan);
            }
        }

        public void UpdateToBorrowed(Guid id, string client, DateTime date)
        {
            
            Book book = books[id];
            book.IsBorrowed = true;
            var updated = books.TryUpdate(id, book, book);

            if (updated)
            {
                var loan = new Loan(id, client, date);
                loans.Add(loan);
            }
        }
               
        public Loan GetLoan(Guid id)
        {
            return loans.First(l => l.IdBook == id);
        }

        public IList<Loan> GetLoansFromClient(string client)
        {
            return loans.Where(l => l.ClientName == client).ToList();
        }
    }

    [DataContract]
    public class Loan
    {
        [DataMember]
        public Guid IdBook { get; set; }

        [DataMember]
        public string ClientName { get; set; }

        [DataMember]
        public DateTime LoanDate { get; set; }


        public Loan(Guid idBook, string clientName, DateTime loanDate)
        {
            IdBook = idBook;
            ClientName = clientName;
            LoanDate = loanDate;
        }
    }
}
