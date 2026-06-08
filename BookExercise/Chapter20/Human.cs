using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Chapter20
{
    internal class Human
    {
        public string FirstName { get; }
        public string LastName { get; }
        protected Human(string firstName,string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
