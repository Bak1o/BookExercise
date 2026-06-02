using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms
{
    internal static class BFSForMatrix
    {
        static char[,] lab =
{
{' ', ' ', ' ', '*', ' ', ' ', ' '},
{'*', '*', ' ', '*', ' ', '*', ' '},
{' ', ' ', ' ', ' ', ' ', ' ', ' '},
{' ', '*', '*', '*', '*', '*', ' '},
{' ', ' ', ' ', ' ', ' ', ' ', 'e'},
};
        public static void Bfs(int startRow, int startCol)
        {
            int rows = lab.GetLength(0);
            int cols = lab.GetLength(1);
            bool[,] visited = new bool[rows, cols];
            Queue<(int row, int col)> queue = new Queue<(int, int)>();
            queue.Enqueue((startRow, startCol));
            visited[startRow, startCol] = true;
            int stepCount = 0;

            while (queue.Count > 0)
            {
                (int row, int col) = queue.Dequeue();
                stepCount++;
                if (lab[row, col] == 'e')
                {
                    Console.WriteLine("Exit found");
                    Console.WriteLine($" step count : {stepCount} ");
                    return;
                }

                TryMove(row, col - 1, queue, visited);//Left
                TryMove(row, col + 1, queue, visited); //Right
                TryMove(row - 1, col, queue, visited); //Up
                TryMove(row + 1, col, queue, visited); //Down
            }
            Console.WriteLine("Exit was not found");



        }
        private static void TryMove(int toMoveRow, int toMoveCol, Queue<(int, int)> q, bool[,] visited)
        {
            if (toMoveRow < 0 || toMoveCol < 0 || toMoveRow >= visited.GetLength(0) || toMoveCol >= visited.GetLength(1))
                return;
            if (visited[toMoveRow, toMoveCol])
                return;
            if (lab[toMoveRow, toMoveCol] == '*')
                return;
            visited[toMoveRow, toMoveCol] = true;
            q.Enqueue((toMoveRow, toMoveCol));
        }
    }
}
