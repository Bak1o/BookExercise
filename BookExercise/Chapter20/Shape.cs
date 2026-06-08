using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Chapter20
{
    internal abstract class Shape
    {
        public double Width { get; }
        public double Height {  get; }
        protected Shape(double width, double height)
        {
            Width = width;
            Height = height;
        }
        public abstract double CalculateSurface();
    }
}
