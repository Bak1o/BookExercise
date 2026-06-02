using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms
{
    internal static class DFSForDirectories
    {
        public static void DfsForDirs(string startPath)
        {
            Stack<string> stack = new Stack<string>();
            HashSet<string> visited = new HashSet<string>();
            stack.Push(startPath);
            while (stack.Count > 0)
            {
                string current = stack.Pop();
                if (visited.Contains(current))
                    continue;
                visited.Add(current);
                Console.WriteLine(current);
                try
                {
                    var dirs = Directory.GetDirectories(current);
                    foreach (string dir in dirs)
                    {
                        stack.Push(dir);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Access denied " + current);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }

    }
}
