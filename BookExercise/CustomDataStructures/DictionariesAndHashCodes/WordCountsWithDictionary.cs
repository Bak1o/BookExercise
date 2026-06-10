using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CustomDataStructures.DictionariesAndHashCodes
{
    public class WordCountsWithDictionary
    {
        public static IDictionary<string, int> GetWordOccuranceMap(string text)
        {
            string[] tokens = text.Split(' ', '.', ',', '-', '?', '!');

            IDictionary<string, int> occurances = new Dictionary<string, int>();
            foreach (string word in tokens)
            {
                if (!string.IsNullOrEmpty(word.Trim()))
                {
                    int count;
                    if (!occurances.TryGetValue(word, out count))
                    {
                        count = 0;
                    }
                    occurances[word] = count + 1;
                }
            }
            return occurances;
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
