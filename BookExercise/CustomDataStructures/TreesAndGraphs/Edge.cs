using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CustomDataStructures.TreesAndGraphs
{
    public class Edge
    {
        public int To { get; set; }
        public int Weight { get; set; }
        public Edge(int to, int weight)
        {
            To = to;
            Weight = weight;
        }

    }
}
