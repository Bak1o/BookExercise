using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Chapter20
{
    internal class Circle : Shape
    {
        private const double Pi = Math.PI;
        public double Radius { get; }
        public Circle(double radius) :base(radius,radius)
        {
            Radius = radius;
        }
        public override double CalculateSurface()
        {
            return Math.Pow(Radius, 2) * Pi;
        }
    }
}
