using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_testing
{
    internal class DepthFirstSolve : SolvingAlgorithm
    {
        // returns the solution to the maze as a list of coordinates.
        public override List<Coordinate> SolveMaze(Maze maze) {
            Coordinate solver = new(maze.MazeEntranceCoordinate.Xpos, maze.MazeEntranceCoordinate.Ypos);
            List<Coordinate> solution = new();

            while (!solver.Equals(maze.MazeExitCoordinate)) {
                maze.MazeCoordinates[solver.Xpos, solver.Ypos].Visited = true;
                solution.Add(solver);
                List<Coordinate> neighbouringCells = GetNeighbouringCells(maze, solver);

                Console.WriteLine(neighbouringCells.Count);

                if (neighbouringCells.Count > 0) {
                    Coordinate target = neighbouringCells[rgen.Next(0, neighbouringCells.Count)];
                    solver = new Coordinate(target.Xpos, target.Ypos);

                    Console.WriteLine("Moving");
                }
                else {
                    solver = new Coordinate(solution[^2].Xpos, solution[^2].Ypos);
                    solution.RemoveAt(solution.Count - 1);

                    maze.MazeCoordinates[solver.Xpos, solver.Ypos].Visited = false; // Mark cell as unvisited

                    Console.WriteLine("Backtracking");
                }
            }

            return solution;
        }

        private List<Coordinate> GetNeighbouringCells(Maze maze, Coordinate currentCell) {
            List<Coordinate> neighbours = new();
            try {
                if (!maze.MazeWalls[currentCell.Xpos + 1, currentCell.Ypos] && !maze.MazeCoordinates[currentCell.Xpos + 1, currentCell.Ypos].Visited)
                    neighbours.Add(new Coordinate(currentCell.Xpos + 1, currentCell.Ypos));
            }
            catch (IndexOutOfRangeException) { }
            try {
                if (!maze.MazeWalls[currentCell.Xpos - 1, currentCell.Ypos] && !maze.MazeCoordinates[currentCell.Xpos - 1, currentCell.Ypos].Visited)
                    neighbours.Add(new Coordinate(currentCell.Xpos - 1, currentCell.Ypos));
            }
            catch (IndexOutOfRangeException) { }
            try {
                if (!maze.MazeWalls[currentCell.Xpos, currentCell.Ypos + 1] && !maze.MazeCoordinates[currentCell.Xpos, currentCell.Ypos + 1].Visited)
                    neighbours.Add(new Coordinate(currentCell.Xpos, currentCell.Ypos + 1));
            }
            catch (IndexOutOfRangeException) { }
            try {
                if (!maze.MazeWalls[currentCell.Xpos, currentCell.Ypos - 1] && !maze.MazeCoordinates[currentCell.Xpos, currentCell.Ypos - 1].Visited)
                    neighbours.Add(new Coordinate(currentCell.Xpos, currentCell.Ypos - 1));
            }
            catch (IndexOutOfRangeException) { }

            return neighbours;
        }
    }
}
