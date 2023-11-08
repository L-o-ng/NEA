using Algorithm_testing;

while (true) {
    Maze maze = new DepthFirstGeneration(20, 19);
    maze.InitMaze();
    maze.BuildMaze(maze.MazeCoordinates[1, 1]);
    maze.MazeWalls[1, 0] = false;
    maze.MazeWalls[maze.MazeActualHeight - 2, maze.MazeActualWidth - 1] = false;
    PrintMaze(maze);

    Console.ReadKey(true);
    Console.Clear();
}




static void PrintMaze(Maze maze) { for (int i = 0; i < maze.MazeActualHeight; i++) { for (int j = 0; j < maze.MazeActualWidth; j++) { Console.Write(maze.MazeWalls[i, j] ? "\u2588\u2588" : "  "); } Console.WriteLine(); } }