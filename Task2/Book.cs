using System;
using System.Collections.Generic;

namespace Task2
{
    public class Book
    {
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }
        public HashSet<string> Authors { get; set; } = new HashSet<string>();
        public string ISBN { get; set; }

        public Book(string title, DateTime? publicationDate, string ISBN, params string[] authors)
        {
            if (title is null)
            {
                throw new ArgumentNullException("Title is null");
            }
            else if (title.Equals(string.Empty))
            {
                throw new ArgumentException("Title can't be empty");
            }
            else
            {
                Title = title;
            }
            
            PublicationDate = publicationDate;

            if (authors.Length == 0)
            {
                throw new ArgumentNullException("Author(s) are null");
            }
            else
            {
                foreach (var author in authors)
                {
                    Authors.Add(author);
                }
            }
            
            this.ISBN = ISBN.UnifyISBN();
        }
    }
}
