using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise
{
    internal class Product
    {
        public string BarCode { get; set; }
        public string Producer {  get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Product(string barCode,string producer, string name, decimal price)
        {
            BarCode = barCode;
            Producer = producer;
            Name = name;
            Price = price;
        }
    }
}
