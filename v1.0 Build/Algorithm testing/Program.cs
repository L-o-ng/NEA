using Algorithm_testing;

while (true) {
    Maze maze = new WilsonsGeneration(25, 27, true);
    maze.InitMaze();
    maze.CreateEntranceExit(true);
    maze.BuildMaze(maze.MazeCoordinates[1, 1]);
    

    //SolvingAlgorithm solver = new DepthFirstSolve();
    //List<Coordinate> solution = solver.SolveMaze(maze);

    PrintMaze(maze);

    Console.ReadKey(true);
    Console.Clear();
}




static void PrintMaze(Maze maze) { 
    for (int i = 0; i < maze.MazeActualHeight; i++) { 
        for (int j = 0; j < maze.MazeActualWidth; j++) { 
            if (maze.MazeEntranceCoordinate.Xpos == j && maze.MazeEntranceCoordinate.Ypos == i)
                Console.BackgroundColor = ConsoleColor.Green;

            else if (maze.MazeExitCoordinate.Xpos == j && maze.MazeExitCoordinate.Ypos == i)
                Console.BackgroundColor = ConsoleColor.Red;
            
            //implement solution path colour
            Console.Write(maze.MazeWalls[i, j] ? "\u2588\u2588" : "  ");
            Console.BackgroundColor = ConsoleColor.Black;
        } 
        Console.WriteLine(); 
    } 
}