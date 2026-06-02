using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms
{
    internal static class BFSForMazeMatrix
    {
        static char[,] lab =
{
{' ', ' ', ' ', '*', ' ', ' ', ' '},
{'*', '*', ' ', '*', ' ', '*', ' '},
{' ', ' ', ' ', ' ', ' ', ' ', ' '},
{' ', '*', '*', '*', '*', '*', ' '},
{' ', ' ', ' ', ' ', ' ', ' ', 'e'},
};
      
        public static string[,] BfsForLabyrinth(string[,] maze, int startRow, int startCol)
        {
            int rows = maze.GetLength(0);
            int cols = maze.GetLength(1);
            Queue<(int row, int col)> q = new Queue<(int, int)>();
            int[,] dist = new int[rows, cols];
            (int, int)[,] parent = new (int, int)[rows, cols];

            int[] dr = { -1, 1, 0, 0 };
            int[] dc = { 0, 0, -1, 1 };


            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    dist[r, c] = -1;
                }
            }

            dist[startRow, startCol] = 0;
            parent[startRow, startCol] = (-1, -1);
            q.Enqueue((startRow, startCol));
            while (q.Count > 0)
            {
                (int currentRow, int currentCol) = q.Dequeue();

                for (int i = 0; i < dr.Length && i < dc.Length; i++)
                {
                    int nr = currentRow + dr[i];
                    int nc = currentCol + dc[i];
                    if (nr < 0 || nr >= rows || nc < 0 || nc >= cols)
                        continue;
                    if (maze[nr, nc] == "0" && dist[nr, nc] == -1)
                    {
                        dist[nr, nc] = dist[currentRow, currentCol] + 1;
                        parent[nr, nc] = (currentRow, currentCol);

                        q.Enqueue((nr, nc));
                    }

                }
            }

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (maze[r, c] == "0")
                    {
                        maze[r, c] = dist[r, c] == -1
                            ? "u"
                            : dist[r, c].ToString();
                    }
                }
            }
            maze[startRow, startCol] = "*";
            return maze;
        }

    }
}
