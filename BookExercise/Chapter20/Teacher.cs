using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Chapter20
{
    internal class Teacher : Person
    {
       
        private readonly IList<Course> _courses;
        public IReadOnlyList<Course> Courses
        {
            get
            {
                return _courses.AsReadOnly();
            }
        }
        public Teacher(string name, IList<Course> courses) : base(name)
        {
            _courses = courses;
        }
        public void AddCourse(Course course)
        {
            _courses.Add(course);
        }
    }
}
