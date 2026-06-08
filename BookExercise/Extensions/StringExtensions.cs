using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Extensions
{
    internal static class StringExtensions
    {
        public static string CapitalizeFirstLetters(this string s)
        {
            
            string lower = s.ToLower();
            StringBuilder sb = new StringBuilder();
            bool isBeginningOfWord = true;
            foreach (char c in lower)
            {
                if (char.IsLetter(c))
                {
                    if (isBeginningOfWord)
                    {
                        sb.Append(char.ToUpper(c));
                        isBeginningOfWord = false;
                    }
                    else
                    {
                        sb.Append(c);
                        
                    }
                }
                else
                {
                    sb.Append(c);
                    isBeginningOfWord = true;
                }
            }
            return sb.ToString();
            
        }
    }
}
