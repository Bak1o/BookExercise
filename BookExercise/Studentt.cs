using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise
{
    internal class Studentt : IComparable<Studentt>
    {
        private string _firstName;
        private string _lastName;
        public Studentt(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;   
        }

        public int CompareTo(Studentt other)
        {
            int result = _lastName.CompareTo(other._lastName);
            if (result == 0)
            {
                result = _firstName.CompareTo(other._firstName);
            }
            return result;

        }
        public override string ToString()
        {
            return _firstName + " " + _lastName;
        }
        
    }
}
