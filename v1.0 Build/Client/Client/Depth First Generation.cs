using Newtonsoft.Json;

namespace Algorithm_testing
{
    internal class DepthFirstGeneration : Maze
    {
        [JsonConstructor]
        public DepthFirstGeneration()
        {
            
        }

        public DepthFirstGeneration(int cellWidth, int cellHeight){
            MazeCellWidth = cellWidth;
            MazeCellHeight = cellHeight;
            rgen = new();
        }
    }
}
