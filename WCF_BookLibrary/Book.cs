using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCF_BookLibrary
{
    [DataContract]
    public class Book 
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Isbn { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public bool IsBorrowed { get; set; }

        public Book(string isbn, string code, string title, string author, string subject)
        {
            Id = Guid.NewGuid();
            Isbn = isbn;
            Code = code;
            Title = title;
            Author = author;
            Subject = subject;
        }       
    }
}
