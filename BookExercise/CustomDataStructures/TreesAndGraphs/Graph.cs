using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CustomDataStructures.TreesAndGraphs
{
    public class Graph
    {
        private List<int>[] _childNodes;
        public List<int>[] ChildNodes
        { 
            get 
            {
                return _childNodes;
            }
        }
        public Graph(int size)
        {
            this._childNodes = new List<int>[size];
            for (int i = 0; i < size; i++)
            {
                this._childNodes[i] = new List<int>();
            }
        }
        public Graph(List<int>[] childNodes)
        {
            _childNodes = childNodes;
        }
        public int Size
        {
            get
            {
                return _childNodes.Length;
            }
        }
        public void AddDirectedEdge(int u, int v)
        {
            _childNodes[u].Add(v);
        }
        public void AddUndirectedEdge(int u, int v)
        {
            _childNodes[u].Add(v);
            _childNodes[v].Add(u);
        }
        public void RemoveDirectedEdge(int u, int v)
        {
            _childNodes[u].Remove(v);
        }
        public void RemoveUndirectedEdge(int u, int v)
        {
            _childNodes[u].Remove(v);
            _childNodes[v].Remove(u);
        }
        public bool HasEdge(int u, int v)
        {
            bool hasEdge = _childNodes[u].Contains(v);
            return hasEdge;
        }
        public bool ChildHasEdge(int u)
        {
            bool hasEdge = _childNodes[u].Count > 0;
            return hasEdge;
        }
        
        public IList<int> GetSuccesors(int v)
        {
            return _childNodes[v];
        }
    }
}
