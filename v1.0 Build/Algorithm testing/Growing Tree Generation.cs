using Newtonsoft.Json;

namespace Algorithm_testing
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

        public override void BuildMaze(Coordinate startCell) {
            List<Coordinate> activeCells = new();
            List<Coordinate> visitedCells = new();
            activeCells.Add(cellsInMaze[rgen.Next(cellsInMaze.Count)]);

            while (activeCells.Count > 0) {
                Coordinate cell = activeCells[rgen.Next(activeCells.Count)];
                List<Coordinate> unvisited = GetUnvisitedNeighbours(cell, activeCells, visitedCells);
                
                if (unvisited.Count > 0) {
                    Coordinate targetCell = unvisited[rgen.Next(unvisited.Count)];
                    DestroyWall(cell, targetCell);
                    activeCells.Add(targetCell);
                }
                else {
                    activeCells.Remove(cell);
                    visitedCells.Add(cell);
                    continue;
                }
            }
        }
        private void DestroyWall(Coordinate cell1, Coordinate cell2) {
            int midX = Math.Min(cell1.Xpos, cell2.Xpos) + Math.Abs(cell1.Xpos - cell2.Xpos) / 2;
            int midY = Math.Min(cell1.Ypos, cell2.Ypos) + Math.Abs(cell1.Ypos - cell2.Ypos) / 2;
            MazeWalls[midY, midX] = false;
        }

        private List<Coordinate> GetUnvisitedNeighbours(Coordinate cell, List<Coordinate> activeCells, List<Coordinate> visitedCells) {
            List<Coordinate> unvisited = new();

            if (cell.Ypos - 2 >= 0)//N
                if (!activeCells.Contains(MazeCoordinates[cell.Ypos - 2, cell.Xpos]) &&
                    !visitedCells.Contains(MazeCoordinates[cell.Ypos - 2, cell.Xpos]))
                    unvisited.Add(MazeCoordinates[cell.Ypos - 2, cell.Xpos]);

            if (cell.Xpos + 2 < MazeActualWidth)//E
                if (!activeCells.Contains(MazeCoordinates[cell.Ypos, cell.Xpos + 2]) &&
                    !visitedCells.Contains(MazeCoordinates[cell.Ypos, cell.Xpos + 2]))
                    unvisited.Add(MazeCoordinates[cell.Ypos, cell.Xpos + 2]);

            if (cell.Ypos + 2 < MazeActualHeight)//S
                if (!activeCells.Contains(MazeCoordinates[cell.Ypos + 2, cell.Xpos]) &&
                    !visitedCells.Contains(MazeCoordinates[cell.Ypos + 2, cell.Xpos]))
                    unvisited.Add(MazeCoordinates[cell.Ypos + 2, cell.Xpos]);

            if (cell.Xpos - 2 >= 0)//W
                if (!activeCells.Contains(MazeCoordinates[cell.Ypos, cell.Xpos - 2]) &&
                    !visitedCells.Contains(MazeCoordinates[cell.Ypos, cell.Xpos - 2]))
                    unvisited.Add(MazeCoordinates[cell.Ypos, cell.Xpos - 2]);

            return unvisited;
        }


        public override void CreateEntranceExit(bool atBorder) {
            MazeWalls[1, 0] = false; //entrance
            MazeEntranceCoordinate = new Coordinate(0, 1);

            if (atBorder) //border exit
            {
                Maze​Walls[MazeActualHeight - 2, MazeActualWidth - 1] = false; //exit
                MazeExitCoordinate = new Coordinate(MazeActualWidth - 1, MazeActualHeight - 2);
            }
            else //central exit
            {
                int centerX, centerY;
                centerX = MazeActualWidth / 2;
                centerY = MazeActualHeight / 2;
                MazeWalls[centerY, centerX] = false;
                MazeExitCoordinate = new Coordinate(centerX, centerY);
            }


            ResetVisited();
        }

        public override void InitMaze() {
            MazeActualHeight = 2 * MazeCellHeight + 1;
            MazeActualWidth = 2 * MazeCellWidth + 1;

            MazeWalls = new bool[MazeActualHeight, MazeActualWidth];
            MazeCoordinates = new Coordinate[MazeActualHeight, MazeActualWidth];

            for (int y = 0; y < MazeActualHeight; y++) {
                for (int x = 0; x < MazeActualWidth; x++) {
                    MazeCoordinates[y, x] = new Coordinate(x, y);

                    if (y % 2 != 0 && x % 2 != 0) {
                        MazeWalls[y, x] = false;
                        cellsInMaze.Add(MazeCoordinates[y, x]);
                    }

                    else
                        MazeWalls[y, x] = true;
                }
            }
        }

        public override void RemoveWalls(int wallsToRemove) {
            int wallsRemoved = 0;

            while (wallsRemoved < wallsToRemove) {
                int xPos = rgen.Next(1, MazeActualWidth - 1);
                int yPos = rgen.Next(1, MazeActualHeight - 1);
                Coordinate cellToRemove = new(xPos, yPos);

                if (IsWall(cellToRemove)) {
                    MazeWalls[yPos, xPos] = false;
                    wallsRemoved++;
                }
            }
        }

        private bool IsWall(Coordinate cell) {
            if (MazeWalls[cell.Ypos + 1, cell.Xpos] == false
                && MazeWalls[cell.Ypos - 1, cell.Xpos] == false
                && MazeWalls[cell.Ypos, cell.Xpos + 1] == true
                && MazeWalls[cell.Ypos, cell.Xpos - 1] == true) {
                return true;
            }
            else if (MazeWalls[cell.Ypos + 1, cell.Xpos] == true
                && MazeWalls[cell.Ypos - 1, cell.Xpos] == true
                && MazeWalls[cell.Ypos, cell.Xpos + 1] == false
                && MazeWalls[cell.Ypos, cell.Xpos - 1] == false) {
                return true;
            }
            else return false;
        }
    }
}
