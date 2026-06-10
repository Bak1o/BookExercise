using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CustomDataStructures.DictionariesAndHashCodes
{
    public class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Point3D(double x, double y, double z)
        {
            X = x; Y = y; Z = z;
        }
        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", X, Y, Z);
        }
        public override bool Equals(object? obj)
        {
            if(this == obj) 
                return true;
            Point3D other = obj as Point3D;
            if(other == null)
                return false;
            if(!X.Equals(other.X)) 
                return false;
            if(!Y.Equals(other.Y)) 
                return false;
            if(!Z.Equals(other.Z))
                return false;

            return true;
        }
        public override int GetHashCode()
        {
            int prime = 83;
            int result = 1;
            unchecked
            {
                result = prime * result + X.GetHashCode();
                result = prime * result + Y.GetHashCode();
                result = prime * result + Z.GetHashCode();
            }
            return result;
        }

    }
}
