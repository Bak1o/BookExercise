using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise
{
    internal class Fraction
    {
       public int Numerator {  get; set; }
       public int Denominator { get; set; }
        public Fraction(int numerator, int denominator)
        {
           if (DenominatorIsValid(denominator))
           Numerator = numerator;
            Denominator = denominator;
        }

        public static Fraction Parse(string s)
        {
            string[] items = s.Split('/');
            if (items.Length == 2)
            {
                if (int.TryParse(items[0], out int numerator) && int.TryParse(items[1], out int denominator))
                {
                    return new Fraction(numerator, denominator);
                }
                throw new ArgumentException(" Enter right string format ");
            }
            throw new ArgumentException(" enter corect fraction format ");
        }

        private bool DenominatorIsValid(int denominator)
        {
            if (denominator != 0)
            {
                return true;
            }
            throw new ArgumentException("denominator must not be a zero");
        }

        public void Cancel()
        {
            int a = Numerator;
            int b = Denominator;
            int temp;
            while (b != 0)
            {
                temp = b;
                b = b % a;
                a = temp;
            }

            int GreatestCommonDivisor = a;
            Numerator = Numerator / GreatestCommonDivisor;
            Denominator = Denominator / GreatestCommonDivisor;
        }
        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }
}
