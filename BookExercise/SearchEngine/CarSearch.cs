using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.SearchEngine
{
    internal class CarSearch
    {
        private Dictionary<string, List<Car>> _carsByBrand;
        private Dictionary<string, List<Car>> _carsByModel;
        private Dictionary<string, List<Car>> _carsByColor;
        private List<Car> _carListByPrice;
        private List<Car> _carListByYear;
        private CarPriceComparer _priceComparer;
        private CarYearComparer _yearComparer;
        public CarSearch()
        {
            _carsByBrand = new Dictionary<string, List<Car>>();
            _carsByModel = new Dictionary<string, List<Car>>();
            _carsByColor = new Dictionary<string, List<Car>>();
            _carListByPrice = new List<Car>();
            _carListByYear = new List<Car>();
            _priceComparer = new CarPriceComparer();
            _yearComparer = new CarYearComparer();
        }
        public void Add(params Car[] cars)
        {
            foreach (var car in cars)
            {
                if (!_carsByBrand.TryGetValue(car.Brand, out List<Car> carsByBrand))
                {
                    carsByBrand = new List<Car>();
                    _carsByBrand[car.Brand] = carsByBrand;
                }
                if (!carsByBrand.Contains(car))
                {
                    carsByBrand.Add(car);
                }

                if (!_carsByModel.TryGetValue(car.Model, out List<Car> carsByModel))
                {
                    carsByModel = new List<Car>();
                    _carsByModel[car.Model] = carsByModel;
                }
                if (!carsByModel.Contains(car))
                {
                    carsByModel.Add(car);
                }

                if (!_carsByColor.TryGetValue(car.Color, out List<Car> carsByColor))
                {
                    carsByColor = new List<Car>();
                    _carsByColor[car.Color] = carsByColor;
                }
                if (!carsByColor.Contains(car))
                {
                    carsByColor.Add(car);
                }

                if (!_carListByPrice.Contains(car))
                {
                    _carListByPrice.Add(car);
                }
                if (!_carListByYear.Contains(car))
                {
                    _carListByYear.Add(car);
                }

            }
            _carListByPrice.Sort(_priceComparer);
            _carListByYear.Sort(_yearComparer);
        }
        public Car[] FindByBrand(string brand)
        {
            if (!_carsByBrand.TryGetValue(brand, out List<Car> carsByBrand))
            {
                carsByBrand = new List<Car>();
                
            }
            return carsByBrand.ToArray();
            
            
        }
        public List<Car> FindByModel(string model)
        {
            if (_carsByModel.TryGetValue(model, out List<Car> carsByModel))
            {
                return carsByModel;
            }
            return null;
        }

        public List<Car> FindByColor(string color)
        {
            if (_carsByColor.TryGetValue(color, out List<Car> carsByColor))
            {
                return carsByColor;
            }
            return null;
        }
        public List<Car> FindByPrice(decimal price)
        {
           
            Car[] cars = _carListByPrice.ToArray();
            int index = BinarySearch(cars, price);
            List<Car> carsInPrice = new List<Car>();
            if (index < 0)
                return carsInPrice;
            CollectLeft(cars, index, price, carsInPrice);
            CollectRight(cars, index+ 1, price, carsInPrice);
            return carsInPrice;

        }
        public List<Car> FindByYear(DateOnly prodYear)
        {
            Car[] cars = _carListByYear.ToArray();
            int index = BinarySearch(cars, prodYear);
            List<Car> carsInYear = new List<Car>();
            if (index < 0)
                return carsInYear;
            CollectLeft(cars, index, prodYear, carsInYear);
            CollectRight(cars, index + 1, prodYear, carsInYear);
            return carsInYear;

        }
        public List<Car> FindByPriceAndYear(decimal price, DateOnly year)
        {
            HashSet<Car> carsInPrice = new(FindByPrice(price));
            HashSet<Car> carsInYear = new(FindByYear(year));
            HashSet<Car> cars = new(carsInPrice.Intersect(carsInYear));
            return cars.ToList();
            
        }
        private int BinarySearch(Car[] cars, decimal price)
        {
            return BinarySearch(cars, price, 0, cars.Length - 1);
        }
        private int BinarySearch(Car[] cars, decimal price, int startIndex, int endIndex)
        {
            if (startIndex > endIndex)
                return -1;
            if (startIndex < 0 || startIndex >= cars.Length
                || endIndex < 0 || endIndex >= cars.Length)
                throw new ArgumentException("index");
           
            int mid = (startIndex + endIndex) / 2;
            if (cars[mid].Price == price)
            {
                return mid;
            }
            else if (cars[mid].Price > price)
            {
                return BinarySearch(cars, price, startIndex, mid - 1);
            }
            else
            {
                return BinarySearch(cars, price, mid + 1, endIndex);
            }
            
        }
        private void CollectLeft(Car[] cars , int index, decimal price,List<Car> carList)
        {
            if (index < 0 || index >= cars.Length)
                return;
            if (cars[index].Price != price)
                return;
           CollectLeft(cars, index - 1, price,carList);
            carList.Add(cars[index]);

        }
        private void CollectRight(Car[] cars, int index, decimal price, List<Car> carList)
        {
            if (index < 0 || index >= cars.Length)
                return;
            if (cars[index].Price != price)
                return;
            CollectRight(cars, index + 1, price, carList);
            carList.Add(cars[index]);

        }
        private int BinarySearch(Car[] cars, DateOnly prodYear)
        {
            return BinarySearch(cars, prodYear, 0, cars.Length - 1);
        }
        private int BinarySearch(Car[] cars, DateOnly prodYear, int startIndex, int endIndex)
        {
            if (startIndex > endIndex)
                return -1;
            if (startIndex < 0 || startIndex >= cars.Length
                || endIndex < 0 || endIndex >= cars.Length)
                throw new ArgumentException("index");

            int mid = (startIndex + endIndex) / 2;
            if (cars[mid].ProductionYear == prodYear)
            {
                return mid;
            }
            else if (cars[mid].ProductionYear > prodYear)
            {
                return BinarySearch(cars, prodYear, startIndex, mid - 1);
            }
            else
            {
                return BinarySearch(cars, prodYear, mid + 1, endIndex);
            }

        }
        private void CollectLeft(Car[] cars, int index, DateOnly prodYear, List<Car> carList)
        {
            if (index < 0 || index >= cars.Length)
                return;
            if (cars[index].ProductionYear != prodYear)
                return;
            CollectLeft(cars, index - 1, prodYear, carList);
            carList.Add(cars[index]);

        }
        private void CollectRight(Car[] cars, int index, DateOnly prodYear, List<Car> carList)
        {
            if (index < 0 || index >= cars.Length)
                return;
            if (cars[index].ProductionYear != prodYear)
                return;
            CollectRight(cars, index + 1, prodYear, carList);
            carList.Add(cars[index]);

        }
    }
}
