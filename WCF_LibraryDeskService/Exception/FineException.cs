using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_LibraryDeskService.Exception
{
    public class FineException : HttpException
    {
        public FineException(string message) : base(message)
        {
        }
    }
}