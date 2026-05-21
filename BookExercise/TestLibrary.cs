using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise
{
    internal class TestLibrary
    {
        
        public static Library AddLibrary(string libraryName)
        {
            Library library1 = new Library(libraryName);
            return library1;
        }
        public static void AddBooksToLibrary(Library library, params Book[] books)
        {
            foreach (var book in books)
            {
                library.Books.Add(book);
            }
        }

        public static void DisplayBooksInLibrary(Library library)
        {
            Console.WriteLine($"Displaying books for library : {library.Name}");
            Console.WriteLine();
            library.PrintBooksFromLibrary();
        }

        public static void DisplayBooksByAuthor(Library library, string author)
        {
          List<Book> books =  library.SearchByAuthor(author);
            foreach (Book book in books)
            {
                book.PrintInfo();
            }
        }

        public static void RemoveBooksByAuthor(Library library, string author)
        {
            List<Book> books = library.SearchByAuthor(author);
            if (books != null)
            {
                Console.WriteLine($" removing books by author : {author}");
                foreach(Book book in books)
                {
                    library.RemoveBook(book);
                }
            }
            else
            {
                Console.WriteLine($" books with author : {author} wasn't found ");
            }
        }

       
    }
}
