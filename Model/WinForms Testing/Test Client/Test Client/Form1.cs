using System.Threading.Tasks;
using Grpc.Net.Client;
using Test_Client;

namespace Test_Client
{
    public partial class frm_ClientPingTest : Form
    {
        public frm_ClientPingTest()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7131");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = System.Environment.MachineName });

            lbl_PingServer.Text = reply.Message;
            Task.Delay(3000).Wait();
            lbl_PingServer.Text = string.Empty;
        }
    }
}