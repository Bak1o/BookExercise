using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise
{
    internal class Dog
    {
        private string _name;
        private int _age;

        public string Name
        {
            get { return _name; } 
            set { _name = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public Dog(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public Dog() : this("Default Name", 0)
        {
            
        }
        public Dog(string name) : this(name, 0) 
        {
            
        }
        public Dog(int age) : this("Default Name", age) 
        {
            
        }
       
    }
}
