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
        void UpdateToBorrowed(Guid id);

        [OperationContract]
        void UpdateToAvaible(Guid id);
    }
}
