using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise._22thExercise
{
    internal class School
    {
        public int Number { get;}
        public string Name { get;}
        public List<Class> Classes { get; set; }
        public List <Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Discipline> Disciplines { get; set; }
        public School(int number)
        {
            Number = number;
            Name = $"{number}TH SCHOOL";
            Classes = new List<Class> ();
            Students = new List<Student> ();
            Teachers = new List<Teacher> ();
            Disciplines = new List<Discipline> ();

        }

        public void AddDisciplines(params Discipline[] disciplines)
        {
            foreach (var discipline in disciplines)
            {
               Disciplines.Add(discipline);
            }
        }

        public void AddClasses(params  Class[] classes)
        {
            foreach (Class item in classes)
            {
                Classes.Add(item);
            }
        }
        public void AddStudentsToSchool(params Student[] students)
        {
            foreach(Student student in students)
            {
                Students.Add(student);
            }
        }
        public void AddStudentsToClass(Class cclass, params Student[] students)
        {
            cclass.AddStudents(students);
        }

        public void AddTeachers(params Teacher[] teachers)
        {
            foreach (Teacher teacher in teachers)
            {
                Teachers.Add(teacher);
            }
        }

        public void DisplayAllStudentsFromClass(Class cclass)
        {
            cclass.PrintStudents();
        }
        public void DisplayName()
        {
            Console.WriteLine(Name);
        }


    }
}
