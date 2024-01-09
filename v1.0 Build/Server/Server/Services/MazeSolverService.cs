using Grpc.Core;
using Newtonsoft.Json;

namespace Server.Services
{
    public class MazeSolverService : MazeSolver.MazeSolverBase
    {
        public override Task<Path> SolveMaze(SolveRequest request, ServerCallContext context)
        {
            SolvingAlgorithm solver = null;
            Maze maze = null;

            switch (request.MazeGenerationAlgorithm) {
                case "Recursive Backtrack":
                    maze = JsonConvert.DeserializeObject<RecursiveBacktrackGeneration>(request.Maze);
                    break;
                case "Wilson's":
                    maze = JsonConvert.DeserializeObject<WilsonsGeneration>(request.Maze);
                    break;
                case "Growing Tree":
                    maze = JsonConvert.DeserializeObject<GrowingTreeGeneration>(request.Maze);
                    break;
            }
            

            switch (request.Algorithm) {
                case "Depth First":
                    solver = new DepthFirstSolve();
                    break;
                case "Maze Routing":
                    solver = new MazeRoutingSolve();
                    break;
            }

            List<Coordinate> path = solver.SolveMaze(maze);

            return Task.FromResult(new Path { Path_ = JsonConvert.SerializeObject(path) });
        }
    }
}
