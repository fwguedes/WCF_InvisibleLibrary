using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_LibraryDeskService.Exception
{
    public class MaximumExceededException : HttpException
    {
        public MaximumExceededException(string message) : base(message)
        {
        }
    }
}