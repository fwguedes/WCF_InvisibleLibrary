using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_LibraryDeskService.Exception;

namespace WCF_LibraryDeskService
{
    [ServiceContract]
    public interface ILibraryDesk
    {

        [OperationContract]
        [FaultContract(typeof(BookNotFoundException))]
        [FaultContract(typeof(NotAuthenticatedException))]
        [FaultContract(typeof(BookBorrowedException))]
        [FaultContract(typeof(MaximumExceededException))]
        bool BorrowBook(string code,string client,DateTime date);

        [OperationContract]
        [FaultContract(typeof(BookNotFoundException))]
        [FaultContract(typeof(NotAuthenticatedException))]
        [FaultContract(typeof(BookReturnedException))]
        [FaultContract(typeof(FineException))]
        bool ReturnBook(string code, string client, DateTime date);

        [OperationContract]
        void Authenticate(string client);
        
    }

    
}
