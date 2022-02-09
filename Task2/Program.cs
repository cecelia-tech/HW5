using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Catalog bookCatalog = new Catalog();

            Book book1 = null;
            Book book2 = null;

            try
            {
                book1 = new Book("book1", new DateTime(2022, 03, 01), "123-4-56-789012-3", "Author1", "Author2");
                book2 = new Book("book2", new DateTime(2022, 03, 01), "1234567890128", "Author3", "Author4");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
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

                Console.WriteLine(bookCatalog.GetBook("123-4-56-789012-8").PublicationDate?.ToShortDateString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
