using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise
{
    internal class FractionTest
    {

        private static Fraction _instance;
        public FractionTest(Fraction fraction) 
        {
            _instance = fraction;
        }
        public static void CancelFraction()
        {
            _instance.Cancel();
        }
        public static void DisplayFractionNumber()
        {
            Console.WriteLine(_instance.ToString());
        }
    }
}
