using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_LibraryDeskService.Exception
{
    public class BookNotFoundException : HttpException
    {
        public BookNotFoundException(string message) : base(message)
        {
        }
    }
}