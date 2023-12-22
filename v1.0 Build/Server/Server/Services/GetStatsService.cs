using Grpc.Core;

namespace Server.Services
{
    public class GetStatsService : StatsGetter.StatsGetterBase
    {
        public override Task<GlobalMazesGenerated> GetGlobalMazesGenerated(GetGlobalMazesGeneratedRequest request, ServerCallContext context) {
            return base.GetGlobalMazesGenerated(request, context);
        }

        public override Task<GlobalTimes> GetGlobalTimes(GetGlobalTimesRequest request, ServerCallContext context) {
            return base.GetGlobalTimes(request, context);
        }

        public override Task<UserMazesGenerated> GetUserMazesGenerated(GetUserMazesGeneratedRequest request, ServerCallContext context) {
            return base.GetUserMazesGenerated(request, context);
        }

        public override Task<UserTimes> GetUserTimes(GetUserTimesRequest request, ServerCallContext context) {
            return base.GetUserTimes(request, context);
        }
    }
}
