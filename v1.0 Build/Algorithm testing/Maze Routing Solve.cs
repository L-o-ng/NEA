using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_testing
{
    internal class MazeRoutingSolve : SolvingAlgorithm
    {
        (char direction, int BestMD) bestPath = (' ', 99999999);
        const int depth = 3;

        public override List<Coordinate> SolveMaze(Maze maze) {
            List<Coordinate> solution = new List<Coordinate>();
            Coordinate solver = new Coordinate(maze.MazeEntranceCoordinate.Xpos, maze.MazeEntranceCoordinate.Ypos);

            int bestMD = solver.GetManhattanDistance(maze.MazeExitCoordinate);
            solution.Add(solver);

            maze.MazeCoordinates[solver.Ypos, solver.Xpos].Visited = true;

            while (!solver.Equals(maze.MazeExitCoordinate)) {
                List<(Coordinate coordinate, char direction)> unvisited = GetUnvisitedNeighbours(maze, solver);
                global.PrintMaze(maze, solution);
                if (unvisited.Count == 0) {
                    do {
                        solution.Remove(solution.Last());
                        solver = new Coordinate(solution[^1].Xpos, solution[^1].Ypos);
                        unvisited = GetUnvisitedNeighbours(maze, solver);
                    } while (unvisited.Count == 0);
                    continue;
                }
                else if (unvisited.Count == 1) {
                    solver = new Coordinate(unvisited[0].coordinate.Xpos, unvisited[0].coordinate.Ypos);
                    solution.Add(maze.MazeCoordinates[solver.Ypos, solver.Xpos]);
                    maze.MazeCoordinates[solver.Ypos, solver.Xpos].Visited = true;
                }
                else {
                    char directionToMove = TryPaths(maze, unvisited, 1);
                    Coordinate cellToMoveTo = null;
                    foreach (var cell in unvisited) {
                        if (cell.direction == directionToMove) {
                            cellToMoveTo = cell.coordinate; 
                            break;
                        }
                    }
                    solver = new Coordinate(cellToMoveTo.Xpos, cellToMoveTo.Ypos);
                    solution.Add(maze.MazeCoordinates[solver.Ypos, solver.Xpos]);
                    maze.MazeCoordinates[solver.Ypos, solver.Xpos].Visited = true;
                }
            }
            

            return solution;
        }

        private char TryPaths(Maze maze, List<(Coordinate coordinate, char direction)> paths, uint CurrentDepth) {
            uint currentDepth = CurrentDepth;
            Coordinate tempSolver;
            List<Coordinate> cellsVisited = new List<Coordinate>();

            foreach (var path in paths) {
                List<(Coordinate coordinate, char direction)> unvisited;

                do {
                    tempSolver = new Coordinate(path.coordinate.Xpos, path.coordinate.Ypos);
                    unvisited = GetUnvisitedNeighbours(maze, tempSolver);

                    if (unvisited.Count == 1) {
                        tempSolver = new Coordinate(unvisited[0].coordinate.Xpos, unvisited[0].coordinate.Ypos);
                        cellsVisited.Add(maze.MazeCoordinates[tempSolver.Ypos, tempSolver.Xpos]);
                        maze.MazeCoordinates[tempSolver.Ypos, tempSolver.Xpos].Visited = true;
                    }
                    else {
                        int MD = tempSolver.GetManhattanDistance(maze.MazeExitCoordinate);

                        if (MD < bestPath.BestMD) {
                            bestPath = (path.direction, MD);
                        }
                        if (currentDepth != depth)
                            TryPaths(maze, unvisited, currentDepth + 1);
                    }
                } while (unvisited.Count == 1);
            }

            foreach (var cell in cellsVisited) {
                cell.Visited = false;
            }

            return bestPath.direction;
        }

        private List<(Coordinate coordinate, char direction)> GetUnvisitedNeighbours(Maze maze, Coordinate cell) {
            List<(Coordinate coordinate, char direction)> cells = new();

            if (cell.Ypos - 1 >= 0 && !maze.MazeCoordinates[cell.Ypos - 1, cell.Xpos].Visited && !maze.MazeWalls[cell.Ypos - 1, cell.Xpos])
                cells.Add((maze.MazeCoordinates[cell.Ypos - 1, cell.Xpos], 'N'));

            if (cell.Xpos + 1 < maze.MazeActualWidth && !maze.MazeCoordinates[cell.Ypos, cell.Xpos + 1].Visited && !maze.MazeWalls[cell.Ypos, cell.Xpos + 1])
                cells.Add((maze.MazeCoordinates[cell.Ypos, cell.Xpos + 1], 'E'));

            if (cell.Ypos + 1 < maze.MazeActualHeight && !maze.MazeCoordinates[cell.Ypos + 1, cell.Xpos].Visited && !maze.MazeWalls[cell.Ypos + 1, cell.Xpos])
                cells.Add((maze.MazeCoordinates[cell.Ypos + 1, cell.Xpos], 'S'));

            if (cell.Xpos - 1 >= 0 && !maze.MazeCoordinates[cell.Ypos, cell.Xpos - 1].Visited && !maze.MazeWalls[cell.Ypos, cell.Xpos - 1])
                cells.Add((maze.MazeCoordinates[cell.Ypos, cell.Xpos - 1], 'W'));

            return cells;
        }
    }
}
