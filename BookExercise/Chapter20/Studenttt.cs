using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Chapter20
{
    internal class Studenttt : Person
    {
       public int NumberInClass { get; }
        public Studenttt(string name, int numberInClass) : base(name)
        {
           NumberInClass = numberInClass; 
        }
    }
}
