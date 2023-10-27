using Grpc.Core;


namespace Test_Server.Services
{
    public class AddService : Add.AddBase
    {
        public override Task<Sum> AddNums(Numbers request, ServerCallContext context)
        {
            return Task.FromResult(new Sum {Sum_ =  request.Num1 + request.Num2});
        }
    }
}
