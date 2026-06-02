using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CustomExercise
{
    internal class MyStringComparer : IComparer<string>
    {
        private readonly Dictionary<char, int> _dict = new Dictionary<char, int>();
        private readonly char[] _order;
        public MyStringComparer(char[] order)
        {
            _order = order;
            
            int i = 0;
            for (i = 0; i < _order.Length; i++)
            {

                _dict[char.ToLower(_order[i])] = i;
            }
        }
        public int Compare(string? firstElement, string? secondElement)
        {
            if (firstElement == null || secondElement == null)
                throw new ArgumentNullException(nameof(firstElement));
            string firstToLower = firstElement.ToLower();
            string secondToLower = secondElement.ToLower();
            int i = 0;
             while (i < firstToLower.Length && i < secondToLower.Length)
            {
                if (_dict[firstToLower[i]] < _dict[secondToLower[i]])
                    return -1;
                if (_dict[firstToLower[i]] > _dict[secondToLower[i]])
                    return 1;
                i++;
            }
            if (firstToLower.Length < secondToLower.Length)
                return -1;
            if (firstToLower.Length > secondToLower.Length)
                return 1;
            return 0;
        }

        
    }
}
