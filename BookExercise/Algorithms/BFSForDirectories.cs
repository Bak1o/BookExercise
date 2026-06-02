using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms
{
    internal static class BFSForDirectories
    {
        public static void BfsForDirs(string startPath)
        {
            Queue<string> q = new Queue<string>();
            q.Enqueue(startPath);
            while (q.Count > 0)
            {
                string current = q.Dequeue();
                Console.WriteLine(current);
                try
                {
                    var subDirs = Directory.GetDirectories(current);
                    foreach (string dir in subDirs)
                    {
                        q.Enqueue(dir);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("access denied" + current);
                }
                catch (Exception e)
                {
                    Console.WriteLine("error : " + e.Message);
                }
            }
        }
    }
}
