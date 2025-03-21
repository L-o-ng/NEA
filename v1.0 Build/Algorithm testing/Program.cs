﻿using Algorithm_testing;
using System.Diagnostics;

while (true) {
    Maze maze = new WilsonsGeneration(10, 10, true);
    maze.InitMaze();
    maze.CreateEntranceExit(true);
    maze.BuildMaze(maze.MazeCoordinates[1, 1]);
    maze.RemoveWalls(100);

    Stopwatch sw = Stopwatch.StartNew();
    SolvingAlgorithm solver = new Breadth_First_Solve();
    List<Coordinate> solution = solver.SolveMaze(maze);
    Console.WriteLine($"Ticks: {sw.ElapsedTicks}\nMilliseconds: {sw.ElapsedMilliseconds}");

    global.PrintMaze(maze, solution);

    Console.ReadKey(true);
    Console.Clear();
}



static class global
{
    public static void PrintMaze(Maze maze, List<Coordinate> solution) {
        for (int i = 0; i < maze.MazeActualHeight; i++) {
            for (int j = 0; j < maze.MazeActualWidth; j++) {
                if (maze.MazeEntranceCoordinate != null && maze.MazeExitCoordinate != null)
                    if (maze.MazeEntranceCoordinate.Xpos == j && maze.MazeEntranceCoordinate.Ypos == i)
                        Console.BackgroundColor = ConsoleColor.Green;

                else if (maze.MazeExitCoordinate.Xpos == j && maze.MazeExitCoordinate.Ypos == i)
                    Console.BackgroundColor = ConsoleColor.Red;
                foreach (Coordinate coord in solution) {
                    if (coord.Xpos == j && coord.Ypos == i) Console.BackgroundColor = ConsoleColor.Magenta;
                }
                //implement solution path colour
                Console.Write(maze.MazeWalls[i, j] ? "\u2588\u2588" : "  ");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine();
        }
    }
}
