using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise
{
    internal class NameComparer : IComparer<Stu>
    {
        public int Compare(Stu? x, Stu? y)
        {
            if (x == null && y == null)
                return 0;
            int result = x.FirstName.CompareTo(y.FirstName);
            if (result == 0)
                result = x.LastName.CompareTo(y.LastName);
            return result;
        }
    }
}
