namespace Server
{
    internal class DepthFirstGeneration : Maze
    {

        public DepthFirstGeneration(int cellWidth, int cellHeight)
        {
            MazeCellWidth = cellWidth;
            MazeCellHeight = cellHeight;
            rgen = new();
        }




        public override void InitMaze()
        {
            MazeActualHeight = 2 * MazeCellHeight + 1;
            MazeActualWidth = 2 * MazeCellWidth + 1;

            MazeWalls = new bool[MazeActualHeight, MazeActualWidth];
            MazeCoordinates = new Coordinate[MazeActualHeight, MazeActualWidth];

            for (int y = 0; y < MazeActualHeight; y++)
            {
                for (int x = 0; x < MazeActualWidth; x++)
                {
                    if (y % 2 != 0 && x % 2 != 0)
                        MazeWalls[y, x] = false;
                    else
                        MazeWalls[y, x] = true;

                    MazeCoordinates[y, x] = new Coordinate(x, y);
                }
            }
        }

        public override void BuildMaze(Coordinate cell)
        {
            cell.Visited = true;

            List<Coordinate> neighbourCells = GetUnvisitedNeighbours(cell);

            while (neighbourCells.Count > 0)
            {
                Coordinate targetCell = neighbourCells[rgen.Next(0, neighbourCells.Count)];
                if (targetCell.Visited) return;
                DestroyWall(cell, targetCell);
                neighbourCells.Remove(targetCell);
                BuildMaze(targetCell);
            }
        }

        private List<Coordinate> GetUnvisitedNeighbours(Coordinate cell)
        {

            List<Coordinate> cells = new();

            try
            {
                if (!MazeCoordinates[cell.Ypos - 2, cell.Xpos].Visited)
                    cells.Add(MazeCoordinates[cell.Ypos - 2, cell.Xpos]);
            }
            catch { }

            try
            {
                if (!MazeCoordinates[cell.Ypos, cell.Xpos + 2].Visited)
                    cells.Add(MazeCoordinates[cell.Ypos, cell.Xpos + 2]);
            }
            catch { }

            try
            {
                if (!MazeCoordinates[cell.Ypos + 2, cell.Xpos].Visited)
                    cells.Add(MazeCoordinates[cell.Ypos + 2, cell.Xpos]);
            }
            catch { }

            try
            {
                if (!MazeCoordinates[cell.Ypos, cell.Xpos - 2].Visited)
                    cells.Add(MazeCoordinates[cell.Ypos, cell.Xpos - 2]);
            }
            catch { }

            return cells;
        }

        private void DestroyWall(Coordinate cell1, Coordinate cell2)
        {
            int midX = Math.Min(cell1.Xpos, cell2.Xpos) + Math.Abs(cell1.Xpos - cell2.Xpos) / 2;
            int midY = Math.Min(cell1.Ypos, cell2.Ypos) + Math.Abs(cell1.Ypos - cell2.Ypos) / 2;
            MazeWalls[midY, midX] = false;
        }

        public override void CreateEntranceExit()
        { //need to implement entrance/exit randomization and positioning parameters
            MazeWalls[1, 0] = false; //entrance
            MazeEntranceCoordinate = new Coordinate(0, 1);

            Maze​Walls[MazeActualHeight - 2, MazeActualWidth - 1] = false; //exit
            MazeExitCoordinate = new Coordinate(MazeActualWidth - 1, MazeActualHeight - 2);

            ResetVisited();
        }
    }
}
