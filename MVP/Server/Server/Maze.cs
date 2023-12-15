namespace Server
{
    internal abstract class Maze
    {
        #region Properties
        private int mazeActualWidth;
        public int MazeActualWidth
        {
            get { return mazeActualWidth; }
            protected set { mazeActualWidth = value; }
        }

        private int mazeActualHeight;
        public int MazeActualHeight
        {
            get { return mazeActualHeight; }
            protected set { mazeActualHeight = value; }
        }

        private int mazeCellWidth;
        public int MazeCellWidth
        {
            get { return mazeCellWidth; }
            protected set { mazeCellWidth = value; }
        }

        private int mazeCellHeight;
        public int MazeCellHeight
        {
            get { return mazeCellHeight; }
            protected set { mazeCellHeight = value; }
        }

        private bool[,]? mazeWalls;
        public bool[,]? MazeWalls
        {
            get { return mazeWalls; }
            protected set { mazeWalls = value; }
        }

        private Coordinate[,]? mazeCoordinates;
        public Coordinate[,]? MazeCoordinates
        {
            get { return mazeCoordinates; }
            protected set { mazeCoordinates = value; }
        }

        private Coordinate? mazeEntranceCoordinate;
        public Coordinate? MazeEntranceCoordinate
        {
            get { return mazeEntranceCoordinate; }
            protected set { mazeEntranceCoordinate = value; }
        }

        private Coordinate? mazeExitCoordinate;
        public Coordinate? MazeExitCoordinate
        {
            get { return mazeExitCoordinate; }
            protected set { mazeExitCoordinate = value; }
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
