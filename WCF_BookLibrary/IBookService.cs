using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_BookLibrary
{   
    [ServiceContract]
    public interface IBookService
    {       
        [OperationContract]
        Book CreateBook(string isbn, string code, string title, string author, string subject);
               
    }   
}
