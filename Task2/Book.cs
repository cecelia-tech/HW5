using System;
using System.Collections.Generic;

namespace Task2
{
    public class Book
    {
        public string Title { get;}
        public DateTime? PublicationDate { get;}
        public HashSet<string> Authors { get; } = new HashSet<string>();
        public string ISBN { get; }

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
                throw new ArgumentNullException("At least one or more authors needed.");
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
