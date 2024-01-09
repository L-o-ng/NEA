using Newtonsoft.Json;
namespace Client_Mazes
{
    internal class WilsonsGeneration : Maze
    {
        List<Coordinate> cellsInMaze = new();
        bool exitAtBorder;

        [JsonConstructor]
        public WilsonsGeneration() {

        }
        public WilsonsGeneration(int cellWidth, int cellHeight, bool exitAtBorder) {
            MazeCellWidth = cellWidth;
            MazeCellHeight = cellHeight;
            rgen = new();
            this.exitAtBorder = exitAtBorder;
        }
    }
}
