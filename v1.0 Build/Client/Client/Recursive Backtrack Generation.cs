using Newtonsoft.Json;

namespace Client_Mazes
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
