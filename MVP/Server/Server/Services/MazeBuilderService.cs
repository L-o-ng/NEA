using Grpc.Core;
using Newtonsoft.Json;
using System.Text;

namespace Server.Services
{
    public class MazeBuilderService : MazeBuilder.MazeBuilderBase
    {
        public override Task<BuiltMaze> BuildMaze(MazeRequest request, ServerCallContext context) {

            //exitLocation and removeWalls are still unused which i need to add
            Maze maze = null;

            switch (request.Algorithm) {
                case "Recursive Backtrack":
                    maze = new DepthFirstGeneration((int)request.Width, (int)request.Height);
                    break;
            }

            maze.InitMaze();
            maze.BuildMaze(maze.MazeCoordinates[1, 1]);
            maze.CreateEntranceExit();

            string jsonMaze;
            using (MemoryStream memoryStream = new MemoryStream())
            using (JsonWriter jsonWriter = new JsonTextWriter(new StreamWriter(memoryStream))) {
                JsonSerializer.CreateDefault().Serialize(jsonWriter, maze);
                jsonWriter.Flush();
                jsonMaze = Encoding.UTF8.GetString(memoryStream.ToArray());
            }

            
            return Task.FromResult(new BuiltMaze { Maze = jsonMaze });
        }
    }
}
