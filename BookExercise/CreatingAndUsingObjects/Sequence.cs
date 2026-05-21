using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CreatingAndUsingObjects
{
    internal class Sequence
    {
        public static int NextValue(int value) 
        {
            value++;
            return value;
        }
        public static int Sum(string value)
        {
            string[] splitNumbers = value.Split(' ');
            int sum = 0;
            for (int i = 0; i < splitNumbers.Length; i++)
            {
                if (int.TryParse(splitNumbers[i], out int number))
                {
                    sum = sum + number;
                }
            }
            return sum;

        }
    }
}
