using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise
{
    internal class Library
    {
        public string Name { get; set; }
        public  List<Book> Books = new List<Book>();
        public Library(string name) 
        {
            Name = name;
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }
        public void RemoveBook(Book book)
        {
            Books.Remove(book);
        }
      
        public List<Book> SearchByAuthor(string author)
        {
            Console.WriteLine("Searching book/s  by author");
            List<Book> booksWAuthor = new List<Book>();
            int count = 0;
            foreach (Book book in Books)
            {
                if (string.Equals(book.Author,author,StringComparison.CurrentCultureIgnoreCase) /*&& book.Author.Trim() == author.Trim()*/)
                {
                    booksWAuthor.Add(book);
                    count++;
                    Console.WriteLine();
                }
            }
            if (count == 0 )
            {
                throw new ArgumentException($"Book with author : {author} wasn't found");
            }
            return booksWAuthor;
        }
        public void PrintBookInfo(Book book)
        {
            if (!Books.Contains(book))
                throw new ArgumentException(" the book wasn't found ");
                
            book.PrintInfo();
        }
        public void PrintBooksFromLibrary()
        {
            if (Books.Count != 0)
            {
                foreach (Book book in Books)
                {
                    book.PrintInfo();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Library is empty");
            }
        }
    }
}
