using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Chapter20
{
    internal class Course
    {
        public readonly string Name;

        private int _numberOfClasses;
        private int _numberOfExercises;
        
        public Course(string name, int numberOfClasses, int numberOfExercises)
        {
            Name = name;
            _numberOfClasses = numberOfClasses;
            _numberOfExercises = numberOfExercises;
        }
        public int CountOfClasses
        {
            get
            {
                return _numberOfClasses;
            }
        }
        public int CountOfExercises
        {
            get { return _numberOfExercises; }
        }
    }
}
