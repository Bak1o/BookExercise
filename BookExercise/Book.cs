using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateOnly ReleaseDate {  get; set; }
        public int ISBNNumber { get; set; }
        public static int ISBNNumberGenerator { get; set; } = 0;

        public Book(string title, string author, string publisher, string releaseDate) 
        {
            ISBNNumberGenerator++;
            Title = title;
            Author = author;
            Publisher = publisher;
            ReleaseDate = DateOnly.ParseExact(releaseDate,"mm/dd/yyyy");
            ISBNNumber = ISBNNumberGenerator;
        
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Book title : {Title}");
            Console.WriteLine($"Book author : {Author}");
            Console.WriteLine($"Book publisher : {Publisher}");
            Console.WriteLine($"Book release date : {ReleaseDate.ToString("MM/dd/yyyy")}");
            Console.WriteLine($"Book ISBN number : {ISBNNumber}");
        }
    }
}
