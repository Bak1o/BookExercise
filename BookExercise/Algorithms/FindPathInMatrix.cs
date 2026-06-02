using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms
{
    internal static class FindPathInMatrix
    {
        static char[,] lab =
{
{' ', ' ', ' ', '*', ' ', ' ', ' '},
{'*', '*', ' ', '*', ' ', '*', ' '},
{' ', ' ', ' ', ' ', ' ', ' ', ' '},
{' ', '*', '*', '*', '*', '*', ' '},
{' ', ' ', ' ', ' ', ' ', ' ', 'e'},
};
        static char[] path = new char[lab.GetLength(0) * lab.GetLength(1)];
        static int position = 0;
        static void FindPath(int row, int col, char direction)
        {
            Console.WriteLine($"Enter: ({row}, {col})");
            if (row < 0 || col < 0 || row >= lab.GetLength(0) || col >= lab.GetLength(1))
            {
                Console.WriteLine(" outside of maze ");
                return;
            }
            path[position] = direction;
            position++;
            if (lab[row, col] == 'e')
            {
                PrintPath(path, 1, position - 1);

            }

            //if(lab[row, col] != ' ')
            //{
            //    Console.WriteLine($"Blocked or visited: ({row}, {col})");
            //    return;
            //}
            if (lab[row, col] == ' ')
            {

                lab[row, col] = 's';
                Console.WriteLine($"Mark: ({row}, {col})");
                Console.WriteLine($"Try LEFT from ({row}, {col})");
                FindPath(row, col - 1, 'L');

                Console.WriteLine($"Try RIGHT from ({row}, {col})");
                FindPath(row, col + 1, 'R');

                Console.WriteLine($"Try UP from ({row}, {col})");
                FindPath(row - 1, col, 'U');

                Console.WriteLine($"Try DOWN from ({row}, {col})");
                FindPath(row + 1, col, 'D');

                Console.WriteLine($"Backtrack (leave): ({row}, {col})");
                lab[row, col] = ' ';
            }
            position--;

        }

        private static void PrintPath(char[] path, int startPos, int endPos)
        {
            Console.Write(" Found path to exit: ");
            for (int pos = startPos; pos <= endPos; pos++)
            {
                Console.Write($" {path[pos]} ");
            }
            Console.WriteLine();
        }
    }
}
