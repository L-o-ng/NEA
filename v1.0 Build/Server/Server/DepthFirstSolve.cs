namespace Server
{
    internal class DepthFirstSolve : SolvingAlgorithm
    {
        public override List<Coordinate> SolveMaze(Maze maze) {
            Coordinate solver = new(maze.MazeEntranceCoordinate.Xpos, maze.MazeEntranceCoordinate.Ypos);
            List<Coordinate> path = new();
            path.Add(solver);
            maze.MazeCoordinates[solver.Ypos, solver.Xpos].Visited = true;

            while (!solver.Equals(maze.MazeExitCoordinate)) {
                List<Coordinate> unvisitedNeighbours = GetUnvisitedNeighbours(solver, maze);

                if (unvisitedNeighbours.Count > 0) { //if paths exist, take the first one.
                    solver = new(unvisitedNeighbours[0].Xpos, unvisitedNeighbours[0].Ypos);
                    path.Add(solver);
                    maze.MazeCoordinates[solver.Ypos, solver.Xpos].Visited = true;
                }
                else { //otherwise, backtrack.
                    solver = path[^2];
                    path.RemoveAt(path.Count - 1);
                }
            }

            return path;
        }
        private List<Coordinate> GetUnvisitedNeighbours(Coordinate cell, Maze maze) {

            List<Coordinate> cells = new();

            if (cell.Ypos - 1 >= 0 
                && !maze.MazeCoordinates[cell.Ypos - 1, cell.Xpos].Visited 
                && !maze.MazeWalls[cell.Ypos - 1, cell.Xpos])
                cells.Add(maze.MazeCoordinates[cell.Ypos - 1, cell.Xpos]);

            if (cell.Xpos + 1 < maze.MazeActualWidth 
                && !maze.MazeCoordinates[cell.Ypos, cell.Xpos + 1].Visited 
                && !maze.MazeWalls[cell.Ypos, cell.Xpos + 1])
                cells.Add(maze.MazeCoordinates[cell.Ypos, cell.Xpos + 1]);

            if (cell.Ypos + 1 < maze.MazeActualHeight 
                && !maze.MazeCoordinates[cell.Ypos + 1, cell.Xpos].Visited 
                && !maze.MazeWalls[cell.Ypos + 1, cell.Xpos])
                cells.Add(maze.MazeCoordinates[cell.Ypos + 1, cell.Xpos]);

            if (cell.Xpos - 1 >= 0 
                && !maze.MazeCoordinates[cell.Ypos, cell.Xpos - 1].Visited 
                && !maze.MazeWalls[cell.Ypos, cell.Xpos - 1])
                cells.Add(maze.MazeCoordinates[cell.Ypos, cell.Xpos - 1]);

            return cells;
        }
    }
}
