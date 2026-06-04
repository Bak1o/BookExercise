using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Chapter20
{
    internal class SchoolClass
    {
        public readonly string Id;
        private readonly IList<Teacher> _teachers;
        private readonly IList<Studenttt> _students;
        public IReadOnlyList<Teacher> Teachers => _teachers.AsReadOnly();
        public IReadOnlyList<Studenttt> Students => _students.AsReadOnly();
        
        public SchoolClass(string id, IList<Teacher> teachers, IList<Studenttt> students)
        {
             Id = id;
            _teachers = teachers;
            _students = students;
        }
        public void AddTeacher(Teacher teacher)
        {
            _teachers.Add(teacher);
        }
        public void AddStudent (Studenttt studenttt)
        {
            _students.Add(studenttt);
        }
    }
}
