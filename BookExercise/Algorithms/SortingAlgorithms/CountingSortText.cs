using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms.SortingAlgorithms
{
    public class CountingSortText
    {
        public static string Run(string text)
        {
            string newText = text.ToLower();
            int[] countArr = new int[26];
            int index;
            for (int i = 0; i < newText.Length; i++)
            {
                if (!char.IsLetter(newText[i]))
                    continue;
                index = newText[i] - 97;
                countArr[index] = countArr[index] + 1;
            }
            int sum = 0;
            for (int i = 0; i < countArr.Length; i++)
            {
                if (countArr[i] > 0)
                {
                    sum = sum + countArr[i];
                    countArr[i] = sum;
                }
            }
            StringBuilder sb = new StringBuilder(newText);
            for (int i = 0; i < newText.Length; i++)
            {
                index = countArr[newText[i] - 97] - 1;

                sb[index] = newText[i];
                countArr[newText[i] - 97]--;
            }
            return sb.ToString();
        }
    }
}
