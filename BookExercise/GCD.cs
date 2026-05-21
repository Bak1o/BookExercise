using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise
{
    internal class GCD
    {
        public static int Calculate(int a, int b)
        {
            int temp;
            if (a < b)
            {
                while (b != 0)
                {
                    temp = b;
                    b = b % a;
                    a = temp;
                    
                }
                return a;
            }
            else
            {
                while (a != 0)
                {
                    temp = a; 
                    a = a % b;
                    b = temp;
                }
                return b;
            }
        }
    }
}
