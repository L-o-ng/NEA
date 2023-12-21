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
                    maze = JsonConvert.DeserializeObject<DepthFirstGeneration>(request.Maze);
                    break;
            }
            

            switch (request.Algorithm) {
                case "Depth First":
                    solver = new DepthFirstSolve();
                    break;
            }

            List<Coordinate> path = solver.SolveMaze(maze);

            return Task.FromResult(new Path { Path_ = JsonConvert.SerializeObject(path) });
        }
    }
}
