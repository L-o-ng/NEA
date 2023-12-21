namespace Algorithm_testing
{
    internal class Coordinate
    {
        public Coordinate(int xPos, int yPos) {
            this.xPos = xPos;
            this.yPos = yPos;
            visited = false;
        }
        public Coordinate(Tuple<int, int> pos) {
            xPos = pos.Item1;
            yPos = pos.Item2;
            visited = false;
        }

        #region Properties
        private int xPos;
        public int Xpos {
            get { return xPos; }
            private set { xPos = value; }
        }

        private int yPos;
        public int Ypos {
            get { return yPos; }
            private set { yPos = value; }
        }

        private bool visited;
        public bool Visited {
            get { return visited; }
            set { visited = value; }
        }
        #endregion

        #region Methods
        public (int x, int y) GetCartesianCoordinates(Maze maze) {
            return (xPos + 1, (maze.MazeActualHeight - yPos) + 1);
        }
        public float GetManhattanDistance(Coordinate endPoint) {
            throw new NotImplementedException();
        }

        public bool Equals(Coordinate target) {
            return xPos == target.xPos && yPos == target.yPos;
        }
        #endregion
    }
}
