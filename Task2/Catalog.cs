using System;
using System.Collections.Generic;

namespace Task2
{
    public class Catalog
    {
        private List<Book> CatalogOfBooks = new List<Book>();

        public void AddBook(Book book)
        {
            if (book is null)
            {
                throw new ArgumentNullException();
            }

            CatalogOfBooks.Add(book);
        }

        public Book GetBook(string ISBN)
        {
            ISBN = ISBN.UnifyISBN();

            foreach (var book in CatalogOfBooks)
            {
                if (book.ISBN.Equals(ISBN))
                {
                    return book;
                }
            }

            throw new Exception("There is no book with ISBN provided");
        }
    }
}
