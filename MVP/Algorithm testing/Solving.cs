using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_testing
{
    internal abstract class SolvingAlgorithm
    {
        protected Random rgen = new();
        public abstract List<Coordinate> SolveMaze(Maze maze);
    }
}
