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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class LibraryManager : ILibraryManager
    {
        private static ConcurrentDictionary<Guid, Book> books = new ConcurrentDictionary<Guid, Book>();

        public void AddBook(string isbn, string code, string title, string author, string subject)
        {
            Book newBook;

            using(var cli = new BookServiceClient())
            {
                cli.Open();
                newBook = cli.CreateBook(isbn, code, title, author, subject);
                cli.Close();
            }

            if (newBook != null)
                books.TryAdd(newBook.Id,newBook);
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

        public void UpdateToAvaible(Guid id)
        {
            Book book = books[id];
            book.IsBorrowed = false;
            books.TryUpdate(id, book, book);
        }

        public void UpdateToBorrowed(Guid id)
        {
            Book book = books[id];
            book.IsBorrowed = true;
            books.TryUpdate(id, book, book);
        }
    }
}
