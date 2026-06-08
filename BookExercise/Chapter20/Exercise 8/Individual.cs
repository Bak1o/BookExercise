using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Chapter20.Exercise_8
{
    internal class Individual : Customer
    {
        public string LastName { get; }
        public Individual(string name , string lastName) : base(name)
        {
            LastName = lastName;
        }
    }
}
