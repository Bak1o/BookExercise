using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise
{
    public class RandomPasswordGenerator
    {
        private const string CapitalLetters =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string SmallLetters =
            "abcdefghijklmnopqrstuvwxyz";
        private const string Digits =
            "0123456789";
        private const string SpecialChars =
            "~!@#$%^&*()_+={}[]|\';:.,/?<>";
        private const string AllChars =
            CapitalLetters + SmallLetters + Digits + SpecialChars;
        private static Random random = new Random();
        public RandomPasswordGenerator()
        {
            StringBuilder password = new StringBuilder();
            for (int i = 0; i < 2; i++)
            {
                char capitalLetter = GenerateChar(CapitalLetters);
                InsertAtRandomPosition(password, capitalLetter);
            }
            for (int i = 0; i < 2; i++)
            {
                char smallLetter = GenerateChar(SmallLetters);
                InsertAtRandomPosition(password, smallLetter);
            }
            for (int i = 0; i < 1; i++)
            {
                char randomDigit = GenerateChar(Digits);
                InsertAtRandomPosition(password, randomDigit);
            }

            for (int i = 0; i < 3; i++)
            {
                char randomSpecialChar = GenerateChar(SpecialChars);
                InsertAtRandomPosition(password, randomSpecialChar);
            }

            int count = random.Next(8);
            for (int i = 0; i <= count; i++)
            {
                char randomAllchar = GenerateChar(AllChars);
                InsertAtRandomPosition(password, randomAllchar);
            }

            Console.WriteLine(password);

        }
        

        private static void InsertAtRandomPosition(StringBuilder passwordArgument, char character)
        {
            int randomIndex = random.Next(passwordArgument.Length);
            passwordArgument.Insert(randomIndex, character);
        }
        private static char GenerateChar(string availableChars)
        {
            int randomIndex = random.Next(availableChars.Length);
            char randomChar = availableChars[randomIndex];
            return randomChar;
        }
    }
}
