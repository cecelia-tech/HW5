using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog bookCatalog = new Catalog();

            Book book1 = new Book("book1", 1990, new HashSet<string>() { "Author1", "Author2"}, "123-4-56-789012-3");
            Book book2 = new Book("book2", DateTime.Now.Year , new HashSet<string>() { "Author3", "Author4"}, "1234567890128");

            try
            {
                bookCatalog.AddBook(book1);
                Console.WriteLine(bookCatalog.GetBook("1234567890123").Title);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                bookCatalog.AddBook(book2);
                Console.WriteLine(bookCatalog.GetBook("123-4-56-789012-8").Title);

                var book2Authors = bookCatalog.GetBook("123-4-56-789012-8").Authors;
                foreach (var item in book2Authors)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine(bookCatalog.GetBook("123-4-56-789012-8").PublicationDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                
            
            
        }
    }
}
