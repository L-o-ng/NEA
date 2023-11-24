namespace Algorithm_testing
{
    internal abstract class Maze {
        #region Properties
        private int mazeActualWidth;
        public int MazeActualWidth {
            get { return mazeActualWidth; }
            protected set { mazeActualWidth = value; }
        }

        private int mazeActualHeight;
        public int MazeActualHeight {
            get { return mazeActualHeight; }
            protected set { mazeActualHeight = value; }
        }

        private int mazeCellWidth;
        public int MazeCellWidth {
            get { return mazeCellWidth; }
            protected set { mazeCellWidth = value; }
        }

        private int mazeCellHeight;
        public int MazeCellHeight {
            get { return mazeCellHeight; }
            protected set { mazeCellHeight = value; }
        }

        private bool[,]? mazeWalls;
        public bool[,]? MazeWalls {
            get { return mazeWalls; }
            protected set { mazeWalls = value; }
        }

        private Coordinate[,]? mazeCoordinates;
        public Coordinate[,]? MazeCoordinates {
            get { return mazeCoordinates; }
            protected set { mazeCoordinates = value; }
        }
        #endregion

        #region Methods
        public abstract void InitMaze();
        public abstract void BuildMaze(Coordinate startCell);
        protected virtual bool CellVisited(Coordinate cellPos) {
            return cellPos.Visited;
        }
        #endregion


    }
}
