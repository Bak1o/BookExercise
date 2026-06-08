using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Chapter20
{
    internal sealed class Stud : Human, IComparable<Stud>
    {
        public double Mark {  get;  set; }

        
        public Stud(string firstName, string lastName, double mark) : base(firstName, lastName)
        {
            Mark = mark;
        }

        public int CompareTo(Stud? other)
        {
            if (other == null)
                return 1;
            return Mark.CompareTo(other.Mark);

        }
        public override string ToString()
        {
           return $" {FirstName} {LastName} Mark : {Mark}";
        }
    }
}
