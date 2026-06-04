using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Chapter20
{
    internal class School
    {
        private readonly IList<SchoolClass> _classes;
        public IReadOnlyList<SchoolClass> Classes
        {
            get { return _classes.AsReadOnly(); }
        }
        
        public School(IList<SchoolClass> classes)
        {
            _classes = classes;
        }
        public void AddClass(SchoolClass c)
        {
            _classes.Add(c);
        }
    }
}
