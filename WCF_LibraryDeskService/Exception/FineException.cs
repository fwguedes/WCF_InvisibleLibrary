﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_LibraryDeskService.Exception
{
    [DataContract]
    public class FineException 
    {
        public FineException(string message) 
        {
        }
    }
}