using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Extensions
{
    internal static class StringBuilderExtensions
    {
        public static StringBuilder Substring(this StringBuilder item, int index, int length)
        {
            
            string element = item.ToString().Substring(index,length);

            return new StringBuilder(element);
        }
    }
}
