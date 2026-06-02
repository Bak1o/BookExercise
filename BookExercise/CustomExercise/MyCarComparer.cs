using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CustomExercise
{
    internal class MyCarComparer :  IComparer<MyCar> 
    {
        private readonly MyStringComparer _stringComparer;
        
        public MyCarComparer(MyStringComparer stringComparer)
        {
            _stringComparer = stringComparer;
        }
        public int Compare(MyCar? x, MyCar? y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException("x");

            int result = x.Price.CompareTo(y.Price);
            if (result != 0) 
                return result;
            return _stringComparer.Compare(x.Brand, y.Brand);
        }
    }
}
