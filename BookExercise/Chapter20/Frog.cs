using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Chapter20
{
    internal class Frog : Animal
    {
        public Frog(int age, string name, Gender gender) : base(age, name, gender)
        {
        }
        public override string Sound()
        {
            return "Quack";
        }
    }
}
