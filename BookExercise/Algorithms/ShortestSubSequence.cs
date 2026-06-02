using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.Algorithms
{
    internal static class ShortestSubSequence
    {
        public static void Run(int n, int m)
        {
            int next;
            Queue<int> q = new Queue<int>();
            List<int> visited = new List<int>();
            Dictionary<int, int> parent = new Dictionary<int, int>();
            q.Enqueue(n);
            visited.Add(n);

            Console.Write(" S = ");
            while (q.Count > 0)
            {
                int current = q.Dequeue();
                if (current == m)
                    break;


                next = current + 1;
                if (!visited.Contains(next))
                {
                    q.Enqueue(next);
                    visited.Add(next);
                    parent.Add(next, current);
                }
                next = current + 2;
                if (!visited.Contains(next))
                {
                    q.Enqueue(next);
                    visited.Add(next);
                    parent.Add(next, current);
                }
                next = current * 2;
                if (!visited.Contains(next))
                {
                    q.Enqueue(next);
                    visited.Add(next);
                    parent.Add(next, current);
                }



            }
            List<int> sequence = new();
            int curr = m;
            sequence.Add(curr);
            while (parent.ContainsKey(curr))
            {

                curr = parent[curr];
                sequence.Add(curr);
            }

            sequence.Reverse();
            foreach (var item in sequence)
            {
                Console.Write($" {item}");
            }

        }
    }
}
