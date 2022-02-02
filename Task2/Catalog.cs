using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task2
{
    public class Catalog
    {
        //private string patternMatch = @"^\d{3}-\d-\d{2}-\d{6}-\d|\d{13}$";
        //private string hyphenCheck = "-";
        //private string replaceTo = "";
        private List<Book> CatalogOfBooks = new List<Book>();

        //private Dictionary<string, Book> DictionaryCatalog = new Dictionary<string, Book>();
        //instead of dictionary has to be a list and look through it
        //create interface for AddBook and GetBook???

        //stores book only in one ISBN format
        public void AddBook(Book book)
        {
            //if (ISBN == null)
            //{
            //    throw new ArgumentNullException("ISBN is null");
            //}
            if (book == null)
            {
                throw new ArgumentNullException("Book argument is null");
            }
            CatalogOfBooks.Add(book);
            //if (Regex.IsMatch(ISBN, patternMatch))
            //{
            //    if (Regex.IsMatch(ISBN, hyphenCheck))
            //        {
            //            DictionaryCatalog.Add(ReplaceHyphens(ISBN), book);
            //        }
            //        else
            //        {
            //            DictionaryCatalog.Add(ISBN, book);
            //        }
            //}
            //else
            //{
            //    throw new FormatException("ISBN has to be digits of either format: XXXXXXXXXXXXX or XXX-X-XX-XXXXXX-X");
            //}
        }

        public Book GetBook(string ISBN)
        {
            if (ISBN is null)
            {
                throw new ArgumentNullException("ISBN provided is null");
            }
            ISBN = ISBN.UnifyISBN();

            //if (Regex.IsMatch(ISBN, patternMatch))
            //{
            //    if (Regex.IsMatch(ISBN, hyphenCheck))
            //    {
            //        ISBN = ReplaceHyphens(ISBN);
            //    }

                foreach (var book in CatalogOfBooks)
                {
                    if (book.ISBN == ISBN)
                    {
                        return book;
                    }
                }
            //}
            //else
            //{
            //    throw new FormatException("ISBN has to be digits of either format: XXXXXXXXXXXXX or XXX-X-XX-XXXXXX-X");
            //}

            throw new Exception("There is no book with ISBN provided");
        }

        //private string ReplaceHyphens(string ISBN)
        //{
        //    return Regex.Replace(ISBN, hyphenCheck, replaceTo);
        //}
    }
}
