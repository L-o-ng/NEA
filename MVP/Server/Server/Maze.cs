namespace Server
{
    internal abstract class Maze
    {
        #region Properties
        private int mazeActualWidth;
        public int MazeActualWidth
        {
            get { return mazeActualWidth; }
            set { mazeActualWidth = value; }
        }

        private int mazeActualHeight;
        public int MazeActualHeight
        {
            get { return mazeActualHeight; }
            set { mazeActualHeight = value; }
        }

        private int mazeCellWidth;
        public int MazeCellWidth
        {
            get { return mazeCellWidth; }
            set { mazeCellWidth = value; }
        }

        private int mazeCellHeight;
        public int MazeCellHeight
        {
            get { return mazeCellHeight; }
            set { mazeCellHeight = value; }
        }

        private bool[,]? mazeWalls;
        public bool[,]? MazeWalls
        {
            get { return mazeWalls; }
            set { mazeWalls = value; }
        }

        private Coordinate[,]? mazeCoordinates;
        public Coordinate[,]? MazeCoordinates
        {
            get { return mazeCoordinates; }
            set { mazeCoordinates = value; }
        }

        private Coordinate? mazeEntranceCoordinate;
        public Coordinate? MazeEntranceCoordinate
        {
            get { return mazeEntranceCoordinate; }
            set { mazeEntranceCoordinate = value; }
        }

        private Coordinate? mazeExitCoordinate;
        public Coordinate? MazeExitCoordinate
        {
            get { return mazeExitCoordinate; }
            set { mazeExitCoordinate = value; }
        }

        protected Random rgen = new();
        #endregion

        #region Methods
        public abstract void InitMaze();
        public abstract void BuildMaze(Coordinate startCell);
        public abstract void CreateEntranceExit(bool atBorder);
        public abstract void RemoveWalls(int wallsToRemove);
        protected virtual bool CellVisited(Coordinate cellPos)
        {
            return cellPos.Visited;
        }
        protected void ResetVisited()
        {
            foreach (Coordinate v in mazeCoordinates)
            {
                v.Visited = false;
            }
        }
        #endregion
    }
}
