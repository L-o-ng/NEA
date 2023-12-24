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
                    break;
                    
            }

            maze.InitMaze();
            maze.BuildMaze(maze.MazeCoordinates[1, 1]);
            maze.RemoveWalls((int)request.RemoveWalls);
            maze.CreateEntranceExit(request.ExitLocation == "Border");

            string jsonMaze = JsonConvert.SerializeObject(maze);

            
            return Task.FromResult(new BuiltMaze { Maze = jsonMaze });
        }
    }
}