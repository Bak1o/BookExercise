using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.TreesAndGraphs
{
    public class CustomFile
    {
        private string _name;
        public string Name
        {
            get
            { 
                return _name; 
            }
        }
        private long _size;
        public long Size
        {
            get
            {
                return _size;
            }
        }
        public CustomFile(string name,long size)
        {
            _name = name;
            _size = size;
        }
    }
}
