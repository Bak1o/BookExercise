using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise._22thExercise
{
    internal class Teacher
    {
        public string Name { get; set; }
        public List<Discipline> Disciplines { get; set; } = new List<Discipline>();
        public Teacher(string name, params Discipline[] disciplines) 
        {
            Name = name;

            foreach (var discipline in disciplines)
             {
                    Disciplines.Add(discipline);
             }
            
        }
    }
}
