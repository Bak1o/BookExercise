using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CustomDataStructures.TreesAndGraphs
{
    public class WeightedGraph
    {
        private List<Edge>[] _childNodes;
        public WeightedGraph(int size)
        {
            _childNodes = new List<Edge>[size];
            for (int i = 0; i < size; i++)
            {
                _childNodes[i] = new List<Edge> ();
            }
        }

        public int Size
        {
            get
            {
                return _childNodes.Length;
            }
        }
        public void AddDirectedEdge(int from, int to, int weight)
        {
            _childNodes[from].Add(new Edge(to, weight));
        }
        public IList<Edge> GetSuccesors(int v)
        {
            return _childNodes[v];
        }
    }
}
