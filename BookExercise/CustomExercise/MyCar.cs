using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CustomExercise
{
    internal class MyCar
    {
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public MyCar(string brand, decimal price)
        {
            Brand = brand;

            Price = price;
        }
    }
}
