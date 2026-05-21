using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise._22thExercise
{
    internal class Student
    {
        public string Name { get; set; }
        public Class? Class { get; set; }
        public Student(string name, Class? Class)
        {
            Name = name;
            this.Class = Class;
        }
        public Student(string name) : this(name,null) 
        {

        }
    }
}
