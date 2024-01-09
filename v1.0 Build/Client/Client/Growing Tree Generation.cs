using Newtonsoft.Json;

namespace Client_Mazes
{
    internal class GrowingTreeGeneration : Maze
    {
        List<Coordinate> cellsInMaze = new();

        [JsonConstructor]
        public GrowingTreeGeneration() {

        }
        public GrowingTreeGeneration(int cellWidth, int cellHeight) {
            MazeCellWidth = cellWidth;
            MazeCellHeight = cellHeight;
            rgen = new();
        }
    }
}
