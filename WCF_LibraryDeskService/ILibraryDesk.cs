﻿using System;
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
        bool BorrowBook(string code);

        [OperationContract]
        bool ReturnBook(string code);
        
    }

    
}