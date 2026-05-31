using BookExercise.DictionariesAndHashCodes;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise
{
    internal class Car 
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public DateOnly ProductionYear { get; set; }
        public decimal Price { get; set; }
        public Car(string brand, string model, string color,DateOnly productionYear, decimal price)
        {
            Brand = brand;
            Model = model;
            Color = color;
            ProductionYear = productionYear;
            Price = price;
        }
        public override string ToString()
        {
            return $"Brand: {Brand}, Model: {Model}, Color: {Color}, Production year: {ProductionYear.ToString("yyyy")}, Price: {Price}";
        }
        public override bool Equals(object? obj)
        {
            if (this == obj)
                return true;
            Car other = obj as Car;
            if (other == null)
                return false;
            if (!Brand.Equals(other.Brand))
                return false;
            if (!Model.Equals(other.Model)) 
                return false;
            if (!Color.Equals(other.Color)) 
                return false;
            if (!ProductionYear.Equals(other.ProductionYear)) 
                return false;
            if (!Price.Equals(other.Price)) 
                return false;
            return true;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Brand, Model, Color, ProductionYear, Price);
        }

       
    }
}
