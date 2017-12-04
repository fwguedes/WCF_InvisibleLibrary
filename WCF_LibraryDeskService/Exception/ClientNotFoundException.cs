using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_LibraryDeskService.Exception
{
    public class ClientNotFoundException : HttpException
    {
        public ClientNotFoundException(string message) : base(message)
        {
        }
    }
}