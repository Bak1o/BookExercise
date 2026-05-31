using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.SearchEngine
{
    internal class CarYearComparer : IComparer<Car>
    {
        public int Compare(Car? x, Car? y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException((nameof(x)));
            return x.ProductionYear.CompareTo(y.ProductionYear);
        }
    }
}
