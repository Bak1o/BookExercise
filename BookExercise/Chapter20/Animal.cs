using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Chapter20
{
    internal abstract class Animal
    {
        public int Age { get; }
        public string Name { get; }
        public Gender Gender { get; }
        public Animal(int age, string name, Gender gender)
        {
           Age = age;
            Name = name;
            Gender = gender;
        }
        public virtual string Sound()
        {
            return "....";
        }
        public override string ToString()
        {
            return $" {Name}, {Age}, {Gender} Sound: {Sound()}";
        }
    }
}
