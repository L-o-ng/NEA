using Grpc.Core;

namespace Server.Services
{
    public class MazeSolverService : MazeSolver.MazeSolverBase
    {
        public override Task<Path> SolveMaze(SolveRequest request, ServerCallContext context)
        {

            return Task.FromResult(new Path());
        }
    }
}
