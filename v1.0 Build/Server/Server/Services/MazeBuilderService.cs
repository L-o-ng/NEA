using Grpc.Core;
using Newtonsoft.Json;
using System.Text;

namespace Server.Services
{
    public class MazeBuilderService : MazeBuilder.MazeBuilderBase
    {
        public override Task<BuiltMaze> BuildMaze(MazeRequest request, ServerCallContext context) {

            Maze maze = null;

            switch (request.Algorithm) {
                case "Recursive Backtrack":
                    maze = new RecursiveBacktrackGeneration((int)request.Width, (int)request.Height);
                    maze.InitMaze();
                    maze.BuildMaze(maze.MazeCoordinates[1, 1]);
                    maze.RemoveWalls((int)request.RemoveWalls);
                    maze.CreateEntranceExit(request.ExitLocation == "Border");
                    break;
                case "Wilson's":
                    maze = new WilsonsGeneration((int)request.Width, (int)request.Height, request.ExitLocation == "Border");
                    maze.InitMaze();
                    maze.CreateEntranceExit(request.ExitLocation == "Border");
                    maze.BuildMaze(maze.MazeCoordinates[1, 1]);
                    maze.RemoveWalls((int)request.RemoveWalls);
                    break;
                case "Growing Tree":
                    maze = new GrowingTreeGeneration((int)request.Width, (int)request.Height);
                    maze.InitMaze();
                    maze.BuildMaze(null); //startCoordinate unnecessary for this algorithm
                    maze.RemoveWalls((int)request.RemoveWalls);
                    maze.CreateEntranceExit(request.ExitLocation == "Border");
                    break;

                    
            }

            string jsonMaze = JsonConvert.SerializeObject(maze);
            
            return Task.FromResult(new BuiltMaze { Maze = jsonMaze });
        }
    }
}