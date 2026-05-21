using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.DictionariesAndHashCodes
{
    public class Point3DEqualityComparer : IEqualityComparer<Point3D>
    {
        public bool Equals(Point3D? point1, Point3D? point2)
        {
           if(point1 == point2)
                return true;
           if(point1 == null || point2 == null)
                return false;
           if(!point1.X.Equals(point2.X))
                return false;
           if(!point1.Y.Equals(point2.Y))
                return false;
           if(!point1.Z.Equals(point2.Z)) 
                return false;
           return true;
        }

        public int GetHashCode([DisallowNull] Point3D obj)
        {
            Point3D point = obj as Point3D;
            if(point == null)
                return 0;
            int prime = 83;
            int result = 1;
            unchecked
            {
                result = prime * result +point.X.GetHashCode();
                result = prime * result + point.Y.GetHashCode();
                result = prime * result + point.Z.GetHashCode();
            }
            return result;
        }
    }
}
