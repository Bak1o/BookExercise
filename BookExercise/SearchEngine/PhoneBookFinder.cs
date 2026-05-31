using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.SearchEngine
{
    internal class PhoneBookFinder
    {
        const string PhoneBookFileName = "PhoneBook.txt";
        const string QueriesFileName = "Queries.txt";
        static Dictionary<string,List<string>> PhoneBook = new Dictionary<string,List<string>>();

       public static void ReadPhoneBook()
        {
            string[] text = File.ReadAllLines(PhoneBookFileName);
            if (text.Length == 0)
                return;
            foreach (string line in text)
            {
                string[] entry = line.Split(new char[] { '|' });
                string names = entry[0].Trim();
                string town = entry[1].Trim();
                string[] nameTokens = names.Split(new char[] { ' ', '\t' },StringSplitOptions.RemoveEmptyEntries);
                StringBuilder sb = new StringBuilder();
                foreach (string name in nameTokens)
                {
                    AddToPhoneBook(name, line);
                    string nameAndTown = CombineNameAndTown(name, town);
                    AddToPhoneBook(nameAndTown, line);
                }
                AddToPhoneBook(names, line);
                string fullNameAndTown = CombineNameAndTown(names, town);
                AddToPhoneBook(fullNameAndTown, line);
            }
        }
        private static void AddToPhoneBook(string name, string entry)
        {
            name = name.ToLower();
            List<string> entries;
            if(!PhoneBook.TryGetValue(name, out entries))
            {
                entries = new List<string>();
                PhoneBook[name] = entries;
            }
            entries.Add(entry);
        }
        private static string CombineNameAndTown(string name, string town)
        {
            return name + " from " + town;
        }
        public static void ProcessQueries()
        {
            string[] queries = File.ReadAllLines(QueriesFileName);
            if (queries.Length == 0)
                throw new Exception(" File is empty ");
            foreach (string query in queries)
            {
                ProcessQueries(query);
            }
        }
        private static void ProcessQueries(string query)
        {
            if (query.StartsWith("list("))
            {
                int listLen = "list(".Length;
                string name = query.Substring(listLen, query.Length - listLen - 1);
                name = name.Trim().ToLower();
                PrintAllMatches(name);
            }
            else if (query.StartsWith("find("))
            {
                int start = "find(".Length;
                string inside = query.Substring(start, query.Length - start - 1);

                string[] parts = inside.Split(',');

                if (parts.Length != 2)
                {
                    Console.WriteLine($"invalid {query}");
                    return;
                }

                string name = parts[0].Trim().ToLower();
                string town = parts[1].Trim().ToLower();

                string nameAndTown = CombineNameAndTown(name, town);
                PrintAllMatches(nameAndTown);
            }
            else
            {
                Console.WriteLine($"invalid {query} ");
            }
            //else
            //{
            //     if (query.StartsWith("find("))
            //    {
            //        string[] queryParams = query.Split(
            //            new char[] { '(', ' ', ',', ')' }, StringSplitOptions.RemoveEmptyEntries );
            //        string name = queryParams[1];
            //        name = name.Trim().ToLower();
            //        string town = queryParams[2];
            //        town = town.Trim().ToLower();
            //        string nameAndTown = CombineNameAndTown(name, town);
            //        PrintAllMatches(nameAndTown);
            //    }
            //}
        }
        private static void PrintAllMatches(string query)
        {
            List<string> allMatches;
            if (PhoneBook.TryGetValue(query, out allMatches))
            {
                foreach (string entry in allMatches)
                {
                    Console.WriteLine(entry);
                }
            }
            else
            {
                Console.WriteLine($"{query} Not found!");
            }
            Console.WriteLine();
        }
                

            
    }
}
