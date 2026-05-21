using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise._22thExercise
{
    internal class Class
    {
        public string Id { get; set; }
        public List<Student> Students { get; }
        public static School School { get; private set; }

        public Class(string id, School school)
        {
            Id = id;
            Students = new List<Student>();
            School = school;

        }

        public void AddStudents(params Student[] students)
        {
            foreach (var student in students)
            {
                Students.Add(student);
            }
        }

        public void PrintStudents()
        {
            Console.WriteLine($"Printing students from Class {Id} ");
            foreach (var student in Students)
            {

                Console.WriteLine(student.Name);
                Console.WriteLine();
            }
        }
    }
}
