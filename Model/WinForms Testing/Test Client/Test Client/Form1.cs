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

        private async void btn_add_Click(object sender, EventArgs e)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7131");
            var client = new Add.AddClient(channel);
            var reply = await client.AddNumsAsync(new Numbers { Num1 = Convert.ToInt32(txt_num1.Text), Num2 = Convert.ToInt32(txt_num2.Text) });

            lbl_sum.Text = reply.Sum_.ToString();
            Task.Delay(5000).Wait();
            lbl_sum.Text = string.Empty;
        }
    }
}