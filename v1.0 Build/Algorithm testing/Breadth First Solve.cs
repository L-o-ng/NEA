using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_testing
{
    internal class Breadth_First_Solve : SolvingAlgorithm
    {
        List<(Coordinate cell, Coordinate parentCell)> paths = new List<(Coordinate cell, Coordinate parentCell)>();
        List<(Coordinate cell, Coordinate parentCell)> activeCells = new List<(Coordinate cell, Coordinate parentCell)>();
        public override List<Coordinate> SolveMaze(Maze maze) {
            

            List<Coordinate> cellsNeighbouringEntrance = GetUnvisitedNeighbours(maze.MazeEntranceCoordinate, maze);
            Coordinate startCell = new Coordinate(cellsNeighbouringEntrance[0].Xpos, cellsNeighbouringEntrance[0].Ypos);
            paths.Add((maze.MazeCoordinates[startCell.Ypos, startCell.Xpos], maze.MazeEntranceCoordinate));
            activeCells.Add((maze.MazeCoordinates[startCell.Ypos, startCell.Xpos], maze.MazeEntranceCoordinate));
            maze.MazeCoordinates[startCell.Ypos, startCell.Xpos].Visited = true;

            bool finished = false;

            for (int i = 0; i < activeCells.Count && !finished; i++) {
                (Coordinate cell, Coordinate parentCell) = activeCells[i];
                List<Coordinate> neighbourCells = GetUnvisitedNeighbours(cell, maze);

                foreach (Coordinate neighbourCell in neighbourCells) {
                    paths.Add((maze.MazeCoordinates[neighbourCell.Ypos, neighbourCell.Xpos], maze.MazeCoordinates[cell.Ypos, cell.Xpos]));
                    activeCells.Add((maze.MazeCoordinates[neighbourCell.Ypos, neighbourCell.Xpos], maze.MazeCoordinates[cell.Ypos, cell.Xpos]));
                    maze.MazeCoordinates[neighbourCell.Ypos, neighbourCell.Xpos].Visited = true;
                    if (neighbourCell.Equals(maze.MazeExitCoordinate)) finished = true;

                    global.PrintMaze(maze, GetSolution2(paths, maze, neighbourCell));
                    Thread.Sleep(100);
                }

                activeCells.RemoveAt(i);
                i--;
            }



            return GetSolution(paths, maze);
        }

        private List<Coordinate> GetSolution2(List<(Coordinate cell, Coordinate parentCell)> paths, Maze maze, Coordinate endCell) {
            List<Coordinate> solution = new();

            Coordinate parentCoordinate = null;
            foreach (var cell in paths) {
                if (cell.cell.Equals(endCell)) {
                    solution.Add(cell.cell);
                    parentCoordinate = cell.parentCell;
                    break;
                }
            }

            while (!parentCoordinate.Equals(maze.MazeEntranceCoordinate)) {
                foreach (var cell in paths) {
                    if (cell.cell.Equals(parentCoordinate)) {
                        solution.Add(cell.cell);
                        parentCoordinate = cell.parentCell;
                        break;
                    }
                }
            }

            return solution;
        }

        private List<Coordinate> GetSolution(List<(Coordinate cell, Coordinate parentCell)> paths, Maze maze) {
            List<Coordinate> solution = new();

            Coordinate parentCoordinate = null;
            foreach (var cell in paths) {
                if (cell.cell.Equals(maze.MazeExitCoordinate)) {
                    solution.Add(cell.cell);
                    parentCoordinate = cell.parentCell;
                    break;
                }
            }

            while (!parentCoordinate.Equals(maze.MazeEntranceCoordinate)) {
                foreach (var cell in paths) {
                    if (cell.cell.Equals(parentCoordinate)) {
                        solution.Add(cell.cell);
                        parentCoordinate = cell.parentCell;
                        break;
                    }
                }
            }

            return solution;
        }

        private List<Coordinate> GetUnvisitedNeighbours(Coordinate cell, Maze maze) {

            List<Coordinate> cells = new();

            if (cell.Ypos - 1 >= 0 && !maze.MazeCoordinates[cell.Ypos - 1, cell.Xpos].Visited && !maze.MazeWalls[cell.Ypos - 1, cell.Xpos] && !IsInPath(maze.MazeCoordinates[cell.Ypos - 1, cell.Xpos]))
                cells.Add(maze.MazeCoordinates[cell.Ypos - 1, cell.Xpos]);

            if (cell.Xpos + 1 < maze.MazeActualWidth && !maze.MazeCoordinates[cell.Ypos, cell.Xpos + 1].Visited && !maze.MazeWalls[cell.Ypos, cell.Xpos + 1] && !IsInPath(maze.MazeCoordinates[cell.Ypos, cell.Xpos + 1]))
                cells.Add(maze.MazeCoordinates[cell.Ypos, cell.Xpos + 1]);

            if (cell.Ypos + 1 < maze.MazeActualHeight && !maze.MazeCoordinates[cell.Ypos + 1, cell.Xpos].Visited && !maze.MazeWalls[cell.Ypos + 1, cell.Xpos] && !IsInPath(maze.MazeCoordinates[cell.Ypos + 1, cell.Xpos]))
                cells.Add(maze.MazeCoordinates[cell.Ypos + 1, cell.Xpos]);

            if (cell.Xpos - 1 >= 0 && !maze.MazeCoordinates[cell.Ypos, cell.Xpos - 1].Visited && !maze.MazeWalls[cell.Ypos, cell.Xpos - 1] && !IsInPath(maze.MazeCoordinates[cell.Ypos, cell.Xpos - 1]))
                cells.Add(maze.MazeCoordinates[cell.Ypos, cell.Xpos - 1]);

            return cells;
        }

        private bool IsInPath(Coordinate cell) {
            
            foreach (var coordinate in paths) {
                if (coordinate.cell.Equals(cell) || coordinate.parentCell.Equals(cell)) return true;
            }
            return false;
        }
    }
}
