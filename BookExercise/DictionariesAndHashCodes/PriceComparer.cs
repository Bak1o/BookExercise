using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.DictionariesAndHashCodes
{
    internal class PriceComparer : IComparer<Product>
    {
        public int Compare(Product? x, Product? y)
        {
            int result = x.Price.CompareTo(y.Price);
            if (result == 0)
            {
                result = x.BarCode.CompareTo(y.BarCode);
            }
            return result;
        }
    }
}
