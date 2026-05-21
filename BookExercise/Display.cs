using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BookExercise
{
    internal class Display
    {
       public double Size { get; set; }
       public int Colors { get; set; }
        public Display(double size, int colors)
        {
            Size = size;
            Colors = colors;
        }

        public void PrintInfo()
        {
            Console.WriteLine($" Display size : {Size}, Colors : {Colors}");
        }
        

    }
}
