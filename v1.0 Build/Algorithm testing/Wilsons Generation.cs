using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Algorithm_testing
{
    internal class WilsonsGeneration : Maze
    {
        List<Coordinate> cellsInMaze = new();
        bool exitAtBorder;
        [JsonConstructor]
        public WilsonsGeneration() {

        }
        public WilsonsGeneration(int cellWidth, int cellHeight, bool exitAtBorder) {
            MazeCellWidth = cellWidth;
            MazeCellHeight = cellHeight;
            rgen = new();
            this.exitAtBorder = exitAtBorder;
        }
        public override void BuildMaze(Coordinate startCell) {

            //startCoordinate and endCoordinate should be where the algorithm starts and ends, but since these are in the walls, they are
            //inaccessible to the algorithm, so we must pick the neighbouring cells.

            //pick 2 coordinates (might as well use entrance and exit)
            //randomized loop erased walk between them
            //add to maze
            //pick random coordinate not in maze, ie any cell in cellsInMaze
            //randomized loop erased walk from that coordinate until it hits the maze
            //add its path to the maze
            //etc

            //we can handle adding things to the maze with careful management of the 'visited' property. This means we will have to reimplement getUnivisitedNeighbours
            //to account for not just being able to go if !Visited. We will instead redefine unvisited as having all 4 walls and the visited property being true will
            //mean being part of the maze.

            //initial LEW
            Console.WriteLine($"exit({MazeExitCoordinate.Xpos}, {MazeExitCoordinate.Ypos})");
            Thread.Sleep( 1000 );
            InitialLoopErasedWalk(MazeCoordinates[1, 1],
                MazeCoordinates[MazeExitCoordinate.Ypos, MazeExitCoordinate.Xpos - 1]);
        }

        private void InitialLoopErasedWalk(Coordinate startCoordinate, Coordinate endCoordinate) {
            List<Coordinate> path = new List<Coordinate>();
            Coordinate ctor = new Coordinate(startCoordinate.Xpos, startCoordinate.Ypos);
            path.Add(MazeCoordinates[ctor.Ypos, ctor.Xpos]);
            MazeCoordinates[ctor.Ypos, ctor.Xpos].Visited = true;

            while (!ctor.Equals(endCoordinate)) {
                List<Coordinate> unvisitedCells = GetUnvisitedNeighbours(ctor);
                Console.WriteLine(unvisitedCells.Count);
                Coordinate targetCell;
                do {
                    int index = rgen.Next(unvisitedCells.Count);
                    targetCell = unvisitedCells[index];
                    if (path.Contains(targetCell)) unvisitedCells.RemoveAt(index);
                    if (unvisitedCells.Count == 0) break;
                } while (path.Contains(targetCell));
                

                if (!path.Contains(targetCell)) { // keep walking, we will destroy all walls after the walk. We cannot do this dynamically as we have to backtrack sometimes
                    ctor = new Coordinate(targetCell.Xpos, targetCell.Ypos);
                    path.Add(MazeCoordinates[ctor.Ypos, ctor.Xpos]);
                    MazeCoordinates[ctor.Ypos, ctor.Xpos].Visited = true;
                    Console.WriteLine("Walking");
                }
                else { //we must have looped, so backtrack until ctor = targetCell and try again
                    backtrack:
                    while(!ctor.Equals(targetCell)) {
                        MazeCoordinates[ctor.Ypos, ctor.Xpos].Visited = false;
                        
                        path.RemoveAt(path.Count - 1);
                        ctor = new Coordinate(path.Last().Xpos, path.Last().Ypos);

                        Console.WriteLine("Backtracking");
                    }
                }
                Console.WriteLine($"{path.Count} out of {cellsInMaze.Count}");
            }
            foreach (Coordinate coord in path) {
                Console.WriteLine($"({coord.Xpos}, {coord.Ypos})");
            }
            DestroyAllWallsInPath(path);
            if (exitAtBorder)
                Maze​Walls[MazeActualHeight - 2, MazeActualWidth - 1] = false;
            else {
                int centerX = MazeActualWidth / 2;
                int centerY = MazeActualHeight / 2;
                MazeWalls[centerY, centerX] = false;
            }
        }
        private void LoopErasedWalk(Coordinate startCoordinate) { //walk until we hit the maze

        }

        private void DestroyAllWallsInPath(List<Coordinate> pathToDestroy) {
            for (int i = 0; i < pathToDestroy.Count - 1; i++) {
                DestroyWall(pathToDestroy[i], pathToDestroy[i + 1]);
            }
        }

        private void DestroyWall(Coordinate cell1, Coordinate cell2) {
            int midX = Math.Min(cell1.Xpos, cell2.Xpos) + Math.Abs(cell1.Xpos - cell2.Xpos) / 2;
            int midY = Math.Min(cell1.Ypos, cell2.Ypos) + Math.Abs(cell1.Ypos - cell2.Ypos) / 2;
            MazeWalls[midY, midX] = false;
        }

        //private List<Coordinate> GetUnvisitedNeighbours(Coordinate cell) {
        //    //we want to check if the given cell's neighbouring cells have all 4 walls intact. If they are all there, add them to the list.
        //    /*
        //     * N: Ypos - 2, Xpos
        //     * E: Ypos, Xpos + 2
        //     * S: Ypos + 2, Xpos
        //     * W: Ypos, Xpos - 2
        //     */
        //    List<Coordinate> cells = new();

        //    if (MazeWalls[cell.Ypos - 2 - 1, cell.Xpos] &&
        //        MazeWalls[cell.Ypos - 2, cell.Xpos + 1] &&
        //        MazeWalls[cell.Ypos - 2 + 1, cell.Xpos] &&
        //        MazeWalls[cell.Ypos - 2, cell.Xpos - 1]) //N
        //        cells.Add(MazeCoordinates[cell.Ypos - 2, cell.Xpos]);
        //    if (MazeWalls[cell.Ypos - 1, cell.Xpos + 2] &&
        //        MazeWalls[cell.Ypos, cell.Xpos + 2 + 1] &&
        //        MazeWalls[cell.Ypos + 1, cell.Xpos + 2] &&
        //        MazeWalls[cell.Ypos, cell.Xpos + 2 - 1]) //E
        //        cells.Add(MazeCoordinates[cell.Ypos, cell.Xpos + 2]);
        //    if (MazeWalls[cell.Ypos + 2 - 1, cell.Xpos] &&
        //        MazeWalls[cell.Ypos + 2, cell.Xpos + 1] &&
        //        MazeWalls[cell.Ypos + 2 + 1, cell.Xpos] &&
        //        MazeWalls[cell.Ypos + 2, cell.Xpos - 1]) //S
        //        cells.Add(MazeCoordinates[cell.Ypos - 2, cell.Xpos]);
        //    if (MazeWalls[cell.Ypos - 1, cell.Xpos - 2] &&
        //        MazeWalls[cell.Ypos, cell.Xpos - 2 + 1] &&
        //        MazeWalls[cell.Ypos + 1, cell.Xpos - 2] &&
        //        MazeWalls[cell.Ypos, cell.Xpos - 2 - 1]) //W
        //        cells.Add(MazeCoordinates[cell.Ypos, cell.Xpos - 2]);

        //    return cells;
        //}

        private List<Coordinate> GetUnvisitedNeighbours(Coordinate cell) {
            List<Coordinate> cells = new List<Coordinate>();

            if (cell.Ypos - 2 >= 0 &&
                MazeWalls[cell.Ypos - 2 - 1, cell.Xpos] &&
                MazeWalls[cell.Ypos - 2, cell.Xpos + 1] &&
                MazeWalls[cell.Ypos - 2 + 1, cell.Xpos] &&
                MazeWalls[cell.Ypos - 2, cell.Xpos - 1]) // N
                cells.Add(MazeCoordinates[cell.Ypos - 2, cell.Xpos]);
            if (cell.Xpos + 2 < MazeActualWidth &&
                MazeWalls[cell.Ypos - 1, cell.Xpos + 2] &&
                MazeWalls[cell.Ypos, cell.Xpos + 2 + 1] &&
                MazeWalls[cell.Ypos + 1, cell.Xpos + 2] &&
                MazeWalls[cell.Ypos, cell.Xpos + 2 - 1]) // E
                cells.Add(MazeCoordinates[cell.Ypos, cell.Xpos + 2]);
            if (cell.Ypos + 2 < MazeActualHeight &&
                MazeWalls[cell.Ypos + 2 - 1, cell.Xpos] &&
                MazeWalls[cell.Ypos + 2, cell.Xpos + 1] &&
                MazeWalls[cell.Ypos + 2 + 1, cell.Xpos] &&
                MazeWalls[cell.Ypos + 2, cell.Xpos - 1]) // S
                cells.Add(MazeCoordinates[cell.Ypos + 2, cell.Xpos]);
            if (cell.Xpos - 2 >= 0 &&
                MazeWalls[cell.Ypos - 1, cell.Xpos - 2] &&
                MazeWalls[cell.Ypos, cell.Xpos - 2 + 1] &&
                MazeWalls[cell.Ypos + 1, cell.Xpos - 2] &&
                MazeWalls[cell.Ypos, cell.Xpos - 2 - 1]) // W
                cells.Add(MazeCoordinates[cell.Ypos, cell.Xpos - 2]);
            
            return cells;
        }


        public override void CreateEntranceExit(bool atBorder) {
            MazeWalls[1, 0] = false; //entrance
            MazeEntranceCoordinate = new Coordinate(0, 1);

            if (atBorder) //border exit
            {
                 //exit
                MazeExitCoordinate = new Coordinate(MazeActualWidth - 1, MazeActualHeight - 2);
            }
            else //central exit
            {
                int centerX, centerY;
                centerX = MazeActualWidth / 2;
                centerY = MazeActualHeight / 2;
                
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
