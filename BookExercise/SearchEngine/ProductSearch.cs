using BookExercise.DictionariesAndHashCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.SearchEngine
{
    internal class ProductSearch
    {
        private SortedSet<Product> _products;
        public ProductSearch( IComparer<Product> comparer, params Product[] products)
        {
            _products = new SortedSet<Product>(comparer);
            foreach (Product product in products)
            {
                _products.Add(product);
            }
        }
        public SortedSet<Product> GetProductsInPriceRange(decimal priceLowBound, decimal priceHighBound, PriceComparer comparer)
        {
            if (comparer ==  null)
                throw new ArgumentNullException(nameof(comparer));
            if (priceLowBound < 0 || priceLowBound < 0 || priceLowBound > priceHighBound)
                throw new ArgumentException("enter correct price range");
           
            Product lowProduct = new Product("0000000000000", "FakeProd", "FakeName", priceLowBound);
            Product highProduct = new Product("9999999999999", "FakeProde", "FakeNamee", priceHighBound);
            
            return new SortedSet<Product>(_products.GetViewBetween(lowProduct, highProduct), comparer);
        }
    }
}
