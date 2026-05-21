using BookExercise.OtherNameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise._22thExercise
{
    internal class Test
    {
        public static School School = new(147); 
        public static List<Discipline> Disciplines { get; set; } = new List<Discipline>();
        public static List<Class> Classes { get; set; } = new List<Class>();
        public static List<Student> Students { get; set; } = new List<Student>();
        public static List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public Test(School school)
        {
            School = school;
        }
        public static void CreateDisciplines()
        {
            Disciplines.Add(new Discipline("Georgian Language", 15, 15));
            Disciplines.Add( new Discipline("English Languge", 10, 10));
            Disciplines.Add( new Discipline("Math", 15, 15));
            Disciplines.Add(new Discipline("Physics", 12, 12));
        }
        public static void CreateClasses()
        {
            Classes.Add(new Class("4A", School));
            Classes.Add(new Class("4B", School));
            Classes.Add(new Class("4C", School));
        }
        public static void CreateStudents()
        {
            Students.Add(new Student("Nodari"));
            Students.Add(new Student("Anzori"));
            Students.Add(new Student("Xoreshani"));
            Students.Add(new Student("Lamzira"));
            Students.Add(new Student("Tarasa"));
            Students.Add(new Student("Sozara"));

        }
        public static void CreateTeachers()
        {
            Teachers.Add(new Teacher("Lia", Disciplines[2]));
            Teachers.Add(new Teacher("Maia Tabidze", Disciplines[0]));
            Teachers.Add(new Teacher("Nino", Disciplines[1]));
            Teachers.Add(new Teacher("Lamzira", Disciplines[3]));

        }
        public static void AddDisciplines(params Discipline[] disciplines)
        {
            School.AddDisciplines(disciplines);
        }
        public static void AddClasses(params Class[] classes)
        {
            School.AddClasses(classes);
        }
        public static void AddStudentsToSchool(params Student[] students)
        {
            School.AddStudentsToSchool(students);
        }
        public static void AddStudentsToClass()
        {
            Classes[0].AddStudents(Students[0], Students[1], Students[2]);
        }
        public static void AddTeachers(params Teacher[] teachers)
        {
            School.AddTeachers(teachers);
        }
        public static void DisplayAllStudentsFromClass()
        {
            Classes[0].PrintStudents();
        }
        public static void DisplaySchoolName()
        {
            Console.WriteLine();
            School.DisplayName();
        }
    }
}
