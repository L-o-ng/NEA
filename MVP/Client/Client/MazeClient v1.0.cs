using Grpc.Net.Client;
using Server;

namespace Client
{
    public partial class frm_mazeClient : Form
    {
        private CancellationTokenSource cts = new CancellationTokenSource();

        public frm_mazeClient()
        {
            InitializeComponent();
        }

        private void MazeClient_Load(object sender, EventArgs e)
        {
            btn_requestMaze.Enabled = false;

            ThreadPool.QueueUserWorkItem(async (state) =>
            {
                while (!cts.Token.IsCancellationRequested)
                {

                    using var channel = GrpcChannel.ForAddress("https://localhost:7178");
                    var client = new Greeter.GreeterClient(channel);
                    try
                    {
                        var reply = await client.SayHelloAsync(new HelloRequest { Name = Environment.MachineName });
                        Invoke(() =>
                        {
                            lbl_connectionError.Text = "Connected to server!";
                            lbl_connectionError.ForeColor = Color.Green;
                            btn_requestMaze.Enabled = true;
                        });

                    }
                    catch (Exception)
                    {
                        Invoke(() =>
                        {
                            lbl_connectionError.Text = "Not connected to server!";
                            lbl_connectionError.ForeColor = Color.Red;
                            btn_requestMaze.Enabled = false;
                        });
                    }

                    Thread.Sleep(10000);
                }
            });
        }

        private async void btn_requestMaze_Click(object sender, EventArgs e)
        {
            string mazeToDisplay = await RequestMaze();
            ChangeForm(mazeToDisplay);
        }

        private async Task<string> RequestMaze()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7178");
            var client = new MazeBuilder.MazeBuilderClient(channel);
            var reply = await client.BuildMazeAsync(new MazeRequest
            {
                Algorithm = cbx_algorithm.Text,
                Width = (int)nud_mazeWidth.Value,
                Height = (int)nud_mazeHeight.Value,
                RemoveWalls = (int)nud_removeWalls.Value,
                ExitLocation = cbx_whereExit.Text
            });
            return reply.Maze;
        }

        private void ChangeForm(string maze)
        {
            Form mazeDisplay = new frm_mazeDisplay(maze, cbx_algorithm.Text);
            mazeDisplay.ShowDialog();
        }

        private void frm_mazeClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts.Cancel();
        }
    }
}