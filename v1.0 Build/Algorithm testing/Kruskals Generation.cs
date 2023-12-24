using Algorithm_testing;

internal class KruskalsGeneration : Maze
{
    public override void InitMaze() {
        
    }

    public override void BuildMaze(Coordinate startCell) {
        
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