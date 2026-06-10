using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CustomDataStructures.DictionariesAndHashCodes
{
    internal class WordCountingWithSortedDictionary
    {
        public static IDictionary<string, int> GetWordOccurrenceMap(string text)
        {
            string[] tokens = text.Split(' ', '.', ',', '-', '?', '!');
            IDictionary<string, int> words = new SortedDictionary<string, int>(new MyCaseInsensitiveComparer());
            foreach (string word in tokens)
            {
                if (!string.IsNullOrEmpty(word.Trim()))
                {
                    int count;
                    if (!words.TryGetValue(word, out count))
                    {
                        count = 0;
                    }
                    words[word] = count + 1;
                }
            }
            return words;
        }
        public static void PrintWordOccuranceCount(IDictionary<string, int> wordOccuranceMap)
        {
            foreach (var entry in wordOccuranceMap)
            {
                Console.WriteLine($" word {entry.Key} occurs {entry.Value} time(s) in the text");
            }
        }
    }
}
