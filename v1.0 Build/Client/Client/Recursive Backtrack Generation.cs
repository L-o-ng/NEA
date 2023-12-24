using Newtonsoft.Json;

namespace Algorithm_testing
{
    internal class RecursiveBacktrackGeneration : Maze
    {
        [JsonConstructor]
        public RecursiveBacktrackGeneration()
        {
            
        }

        public RecursiveBacktrackGeneration(int cellWidth, int cellHeight){
            MazeCellWidth = cellWidth;
            MazeCellHeight = cellHeight;
            rgen = new();
        }
    }
}
