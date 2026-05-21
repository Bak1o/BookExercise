using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise._22thExercise
{
    internal class Discipline
    {
        public string Name { get; set; }
        public int NumberOfLessons { get; set; }
        public int NumberOfExercises { get; set; }
        public Discipline(string name, int numberOfLessons, int numberOfExercises)
        {
            Name = name;
            NumberOfLessons = numberOfLessons;
            NumberOfExercises = numberOfExercises;
        }
    }
}
