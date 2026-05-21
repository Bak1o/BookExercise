using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.DictionariesAndHashCodes
{
    internal class MyIntValueComparer : IEqualityComparer<int>
    {
        public bool Equals(int x, int y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode([DisallowNull] int obj)
        {
            throw new NotImplementedException();
        }
    }
}
