using System;
using System.Collections.Generic;

namespace Task2
{
    public class Book
    {
        public string Title { get; }
        public int PublicationDate { get; }
        public HashSet<string> Authors { get; }
        public string ISBN { get; }

        public Book(string title, int publicationDate, HashSet<string> authors, string ISBN)
        {
            Title = title;
            PublicationDate = publicationDate;
            Authors = authors;
            this.ISBN = ISBN.UnifyISBN();
        }

        //private string UnifyISBNFormat(string ISBN)
        //{
        //    if (ISBN == null)
        //    {
        //        throw new ArgumentNullException("ISBN is null");
        //    }


        //}
        //move ISBN and all logic on it here
    }
}
