using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms
{
    internal static class DFSForMatrix
    {

        static char[,] lab =
{
{' ', ' ', ' ', '*', ' ', ' ', ' '},
{'*', '*', ' ', '*', ' ', '*', ' '},
{' ', ' ', ' ', ' ', ' ', ' ', ' '},
{' ', '*', '*', '*', '*', '*', ' '},
{' ', ' ', ' ', ' ', ' ', ' ', 'e'},
};
        public static void Dfs(int startRow, int startCol)
        {
            int rows = lab.GetLength(0);
            int cols = lab.GetLength(1);
            bool[,] visited = new bool[rows, cols];
            Stack<(int row, int col)> stack = new Stack<(int, int)>();
            stack.Push((startRow, startCol));
            visited[startRow, startCol] = true;

            while (stack.Count > 0)
            {
                (int row, int col) = stack.Pop();
                if (lab[row, col] == 'e')
                {
                    Console.WriteLine(" Exit was found");
                    return;
                }

                TryMove(row, col - 1, stack, visited); //Left
                TryMove(row, col + 1, stack, visited); //right
                TryMove(row - 1, col, stack, visited); // up
                TryMove(row + 1, col, stack, visited); // down

            }
            Console.WriteLine(" exit was not found ");
        }
        public static void TryMove(int toMoveRow, int toMoveCol, Stack<(int, int)> s, bool[,] visited)
        {
            if (toMoveRow < 0 || toMoveCol < 0 || toMoveRow >= visited.GetLength(0) || toMoveCol >= visited.GetLength(1))
                return;
            if (visited[toMoveRow, toMoveCol])
                return;
            if (lab[toMoveRow, toMoveCol] == '*')
                return;
            visited[toMoveRow, toMoveCol] = true;
            s.Push((toMoveRow, toMoveCol));
        }
    }
}
