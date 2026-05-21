using BookExercise.CreatingAndUsingObjects;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.OtherNameSpace
{
    internal class Class1
    {
        public void CreateCat()
        {
            for (int i = 0; i < 10; i++)
            {
                Cat cat = new Cat(Sequence.NextValue(i));
            }
        }
    }
}
