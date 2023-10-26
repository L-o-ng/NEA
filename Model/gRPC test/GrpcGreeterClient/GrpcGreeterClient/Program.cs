using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;


using var channel = GrpcChannel.ForAddress("https://localhost:7169");
var client = new Greeter.GreeterClient(channel);


while (true)
{
	var reply = await client.SayHelloAsync(new HelloRequest { Name = Console.ReadKey().KeyChar.ToString() });
	Console.WriteLine("Greeting: " + reply.Message);
}