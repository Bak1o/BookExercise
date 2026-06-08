using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Chapter20
{
    internal class WorkersSalaryComparer : IComparer<Worker>
    {
        public int Compare(Worker? x, Worker? y)
        {
            if (x == null || y == null)
              throw new ArgumentNullException(nameof(x));
            return x.Wage.CompareTo(y.Wage);
        }
    }
}
