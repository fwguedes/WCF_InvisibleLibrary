using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_LibraryDeskService.Exception
{
    public class BookBorrowedException : HttpException
    {
        public BookBorrowedException(string message) : base(message)
        {
        }
    }
}