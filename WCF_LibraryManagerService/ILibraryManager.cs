using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_LibraryManagerService.WCFBookService;

namespace WCF_LibraryManagerService
{
    [ServiceContract]
    public interface ILibraryManager
    {
        [OperationContract]
        void AddBook(string isbn, string code, string title, string author, string subject);

        [OperationContract]
        IList<Book>GetAllBooks();

        [OperationContract]
        IList<Book> GetBooksBySubject(string subject);

        [OperationContract]
        IList<Book> GetBooksByAuthor(string author);

        [OperationContract]
        Book GetBooksByCode(string code);

        [OperationContract]
        void UpdateToBorrowed(Guid id,string client, DateTime dat);

        [OperationContract]
        void UpdateToAvaible(Guid id, string client, DateTime date);
              

        [OperationContract]
        Loan GetLoan(Guid id);

        [OperationContract]
        IList<Loan> GetLoansFromClient(string client);
    }
}
