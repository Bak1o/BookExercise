using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.IteratorPattern
{
    public static class Functions
    {
        public static IEnumerable<int> GetNumbers(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                yield return i;
            }
        }
    }
}
