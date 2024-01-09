using Newtonsoft.Json;

namespace Server
{
    internal class Coordinate
    {
        [JsonConstructor]
        public Coordinate() {

        }
        public Coordinate(int xPos, int yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            visited = false;
        }
        public Coordinate(Tuple<int, int> pos)
        {
            xPos = pos.Item1;
            yPos = pos.Item2;
            visited = false;
        }

        #region Properties
        private int xPos;
        public int Xpos
        {
            get { return xPos; }
            set { xPos = value; }
        }

        private int yPos;
        public int Ypos
        {
            get { return yPos; }
            set { yPos = value; }
        }

        private bool visited;
        public bool Visited
        {
            get { return visited; }
            set { visited = value; }
        }
        #endregion

        #region Methods
        public (int x, int y) GetCartesianCoordinates(Maze maze)
        {
            return (xPos + 1, maze.MazeActualHeight - yPos + 1);
        }
        public int GetManhattanDistance(Coordinate targetCoordinate)
        {
            return Math.Abs(Xpos - targetCoordinate.Xpos) + Math.Abs(Ypos - targetCoordinate.Ypos);
        }

        public bool Equals(Coordinate target)
        {
            return xPos == target.xPos && yPos == target.yPos;
        }
        #endregion
    }
}
