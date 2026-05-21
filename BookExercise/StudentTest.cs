using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise
{
    public  class StudentTest
    {
        private static List<Student> _students = new List<Student>();
        public static IReadOnlyList<Student> Students => _students;

        static StudentTest()
        {
            _students.Add(new Student("nika janvelidze", "", "", "TSu", "test@gmail.com", "59924"));
            _students.Add(new Student("nikaaa janvelidze", "", "", "TSu", "test1@gmail.com", "599241"));
            _students.Add(new Student("nik janvelidze", "", "", "TSu", "test2@gmail.com", "599242"));
            _students.Add(new Student("roland janelidze", "macro economics", "", "Teusu", "test3@gmail.com", "555231"));
       
        }

        public static void AddStudent(Student student)
        {
            _students.Add(student);
        }
        public static void Printstudents()
        {
            foreach (Student student in _students)
            {
                student.PrintInfo();
            }
            
        }
    }
}
