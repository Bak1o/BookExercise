using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CreatingAndUsingObjects
{
    internal class Cat
    {

        private const string _name = "Cat";
        private int _id;
        private string _fullName;

        public Cat(int id)
        {
            _id = id;
            _fullName = _name + id;
            SayMiau();
        }
        public void SayMiau()
        {
            Console.WriteLine($" the {_fullName} says: Miau ");
        }

    }
}
