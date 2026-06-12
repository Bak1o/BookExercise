using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.IteratorPattern
{
    public class NumbersGenerator : IEnumerable<int>
    {
        private int _count;
        public NumbersGenerator(int count)
        {
            _count = count;
        }
        public IEnumerator<int> GetEnumerator()
        {
            return new NumbersEnumerator(_count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
