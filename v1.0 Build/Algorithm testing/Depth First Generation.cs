﻿using Newtonsoft.Json;

namespace Algorithm_testing
{
    internal class DepthFirstGeneration : Maze
    {
        [JsonConstructor]
        public DepthFirstGeneration() {

        }
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

        public override void RemoveWalls(int wallsToRemove)
        {
            int wallsRemoved = 0;

            while (wallsRemoved < wallsToRemove)
            {
                int xPos = rgen.Next(1, MazeActualWidth - 1);
                int yPos = rgen.Next(1, MazeActualHeight - 1);
                Coordinate cellToRemove = new(xPos, yPos);

                if (IsWall(cellToRemove)) 
                {
                    MazeWalls[yPos, xPos] = false;
                    wallsRemoved++;
                }           
            }
        }

        private bool IsWall(Coordinate cell)
        {
            if (MazeWalls[cell.Ypos + 1, cell.Xpos] == false
                && MazeWalls[cell.Ypos - 1, cell.Xpos] == false
                && MazeWalls[cell.Ypos, cell.Xpos + 1] == true
                && MazeWalls[cell.Ypos, cell.Xpos - 1] == true)
            {
                return true;
            }
            else if (MazeWalls[cell.Ypos + 1, cell.Xpos] == true
                && MazeWalls[cell.Ypos - 1, cell.Xpos] == true
                && MazeWalls[cell.Ypos, cell.Xpos + 1] == false
                && MazeWalls[cell.Ypos, cell.Xpos - 1] == false)
            {
                return true;
            }
            else return false;
        }

        private List<Coordinate> GetUnvisitedNeighbours(Coordinate cell)
        {

            List<Coordinate> cells = new();

            if (cell.Ypos - 2 >= 0 && !MazeCoordinates[cell.Ypos - 2, cell.Xpos].Visited)
                cells.Add(MazeCoordinates[cell.Ypos - 2, cell.Xpos]);

            if (cell.Xpos + 2 < MazeActualWidth && !MazeCoordinates[cell.Ypos, cell.Xpos + 2].Visited)
                cells.Add(MazeCoordinates[cell.Ypos, cell.Xpos + 2]);

            if (cell.Ypos + 2 < MazeActualHeight && !MazeCoordinates[cell.Ypos + 2, cell.Xpos].Visited)
                cells.Add(MazeCoordinates[cell.Ypos + 2, cell.Xpos]);

            if (cell.Xpos - 2 >= 0 && !MazeCoordinates[cell.Ypos, cell.Xpos - 2].Visited)
                cells.Add(MazeCoordinates[cell.Ypos, cell.Xpos - 2]);

            return cells;
        }

        private void DestroyWall(Coordinate cell1, Coordinate cell2)
        {
            int midX = Math.Min(cell1.Xpos, cell2.Xpos) + Math.Abs(cell1.Xpos - cell2.Xpos) / 2;
            int midY = Math.Min(cell1.Ypos, cell2.Ypos) + Math.Abs(cell1.Ypos - cell2.Ypos) / 2;
            MazeWalls[midY, midX] = false;
        }

        public override void CreateEntranceExit(bool atBorder)
        {
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
    }
}
