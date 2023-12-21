using Algorithm_testing;
using Grpc.Core;
using Grpc.Net.Client;
using Newtonsoft.Json;
using Server;
using System.Windows.Forms.DataVisualization.Charting;

namespace Client
{
    public partial class frm_mazeParams : Form
    {
        private CancellationTokenSource cts = new CancellationTokenSource();

        public frm_mazeParams() {
            InitializeComponent();
        }

        private void MazeClient_Load(object sender, EventArgs e) {
            btn_requestMaze.Enabled = false;

            cbx_algorithm.DropDownStyle = ComboBoxStyle.DropDownList;
            cbx_whereExit.DropDownStyle = ComboBoxStyle.DropDownList;
            cbx_statType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbx_loadedMazes.DropDownStyle = ComboBoxStyle.DropDownList;

            Text = $"MazeClient {Globals.g_version} : Welcome {Globals.g_username}";

            ThreadPool.QueueUserWorkItem(async (state) => {
                while (true) {

                    using var channel = GrpcChannel.ForAddress("https://localhost:7178");
                    var client = new Greeter.GreeterClient(channel);
                    try {
                        var reply = await client.SayHelloAsync(new HelloRequest { Name = Environment.MachineName },
                            deadline: DateTime.UtcNow.AddSeconds(3));
                        Invoke(() => {
                            lbl_connectionError.Text = "Connected to server!";
                            lbl_connectionError.ForeColor = Color.Green;
                            btn_requestMaze.Enabled = true;
                        });

                    }
                    catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded) {
                        Invoke(() => {
                            lbl_connectionError.Text = "Not connected to server!";
                            lbl_connectionError.ForeColor = Color.Red;
                            btn_requestMaze.Enabled = false;
                        });
                    }

                    Thread.Sleep(10000);
                }
            }, cts.Token);
        }

        private async void btn_requestMaze_Click(object sender, EventArgs e) {
            string mazeToDisplay = await RequestMaze();
            if (mazeToDisplay != string.Empty)
                ChangeForm(mazeToDisplay, cbx_algorithm.Text);
        }

        private async Task<string> RequestMaze() {
            using var channel = GrpcChannel.ForAddress("https://localhost:7178");
            var client = new MazeBuilder.MazeBuilderClient(channel);
            BuiltMaze reply;
            try {
                reply = await client.BuildMazeAsync(new MazeRequest {
                    Algorithm = cbx_algorithm.Text,
                    Width = (int)nud_mazeWidth.Value,
                    Height = (int)nud_mazeHeight.Value,
                    RemoveWalls = (int)nud_removeWalls.Value,
                    ExitLocation = cbx_whereExit.Text
                }, deadline: DateTime.UtcNow.AddSeconds(3));
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded) {
                lbl_connectionError.Text = "Not connected to server!";
                lbl_connectionError.ForeColor = Color.Red;
                btn_requestMaze.Enabled = false;
                return string.Empty;
            }
            return reply.Maze;
        }

        private void ChangeForm(string maze, string algorithm) {
            Form mazeDisplay = new frm_mazeDisplay(maze, algorithm);
            mazeDisplay.ShowDialog();
            mazeDisplay.Focus();
        }

        private void frm_mazeParams_FormClosing(object sender, FormClosingEventArgs e) {
            cts.Cancel();
            cts.Dispose();
        }

        private async void btn_getMazes_Click(object sender, EventArgs e) {
            cbx_loadedMazes.Items.Clear();

            using var channel = GrpcChannel.ForAddress("https://localhost:7178");
            var client = new GetterMazes.GetterMazesClient(channel);
            try {
                var reply = await client.GetMazesAsync(new Request { UserID = (int)Globals.g_userID }, deadline: DateTime.UtcNow.AddSeconds(3));
                List<(int mazeID, string mazeName)> mazes = JsonConvert.DeserializeObject<List<(int mazeID, string mazeName)>>(reply.Mazes);
                foreach (var maze in mazes) {
                    cbx_loadedMazes.Items.Add($"{maze.mazeID}: {maze.mazeName}");
                }
                lbl_loadError.Text = $"Found {mazes.Count} mazes!";
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded) {
                lbl_loadError.Text = "Error fetching\nmazes!";
            }
        }

        private async void btn_loadMaze_Click(object sender, EventArgs e) {
            if (cbx_loadedMazes.Text == string.Empty) return;

            using var channel = GrpcChannel.ForAddress("https://localhost:7178");
            var client = new LoaderMazes.LoaderMazesClient(channel);
            try {
                var reply = await client.LoadMazeAsync(new LoadRequest { UserID = (int)Globals.g_userID, MazeID = Convert.ToInt32(cbx_loadedMazes.Text.Split(':')[0]) }, 
                    deadline: DateTime.UtcNow.AddSeconds(3));


                switch (reply.MazeGenAlg) {
                    case "Recursive Backtrack":
                        ChangeForm(reply.Maze, reply.MazeGenAlg);
                        break;
                    default:
                        lbl_loadError.Text = "Error loading\nmazes!";
                        break;
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded) {
                lbl_loadError.Text = "Error loading\nmazes!";
            }
        }

        private async void btn_deleteMaze_Click(object sender, EventArgs e) {
            if (cbx_loadedMazes.Text == string.Empty) return;

            using var channel = GrpcChannel.ForAddress("https://localhost:7178");
            var client = new DeleterMazes.DeleterMazesClient(channel);
            try {
                var reply = await client.DeleteMazeAsync(new DeleteRequest { UserID = (int)Globals.g_userID, MazeID = Convert.ToInt32(cbx_loadedMazes.Text.Split(':')[0]) },
                    deadline: DateTime.UtcNow.AddSeconds(3));
                if (reply.Success) {
                    lbl_loadError.Text = "Deleted maze\nsuccessfully!";
                    cbx_loadedMazes.Items.RemoveAt(cbx_loadedMazes.SelectedIndex);
                }
                else {
                    lbl_loadError.Text = "Error Deleting\nmaze!";
                }

            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded) {
                lbl_loadError.Text = "Error Deleting\nmaze!";
            }
        }
    }
}