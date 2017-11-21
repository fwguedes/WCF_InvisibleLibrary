using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_LibraryDeskService.Exception
{
    public class BookReturnedException : HttpException
    {
        public BookReturnedException(string message) : base(message)
        {
        }
    }
}