using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.IteratorPattern
{
    public class NumbersEnumerator : IEnumerator<int>
    {
        private int _current = 0;
        private int _maxValue;
        public NumbersEnumerator(int count)
        {
            _maxValue = count;
        }
        public int Current => _current;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
          
        }

        public bool MoveNext()
        {
            _current++;
            return _current <= _maxValue;
        }

        public void Reset()
        {
            _current = 0;
        }
    }
}
