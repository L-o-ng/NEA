using Client_Mazes;
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
        private bool connected = false;
        private bool algorithmSelected = false;
        private bool exitSelected = false;

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
                            connected = true;
                            HandleAllowSend();
                        });

                    }
                    catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded) {
                        Invoke(() => {
                            HandleServerError();
                        });
                    }
                    catch (ObjectDisposedException) { }

                    Thread.Sleep(10000);
                }
            }, cts.Token);
        }

        private void HandleServerError() {
            lbl_connectionError.Text = "Not connected to server!";
            lbl_connectionError.ForeColor = Color.Red;
            connected = false;
            HandleAllowSend();
        }

        private void HandleAllowSend() {
            if (connected &&
                algorithmSelected &&
                exitSelected) {
                btn_requestMaze.Enabled = true;
            }
            else {
                btn_requestMaze.Enabled = false;
            }
        }

        private async void btn_requestMaze_Click(object sender, EventArgs e) {
            btn_requestMaze.Enabled = false;
            string mazeToDisplay = await RequestMaze();
            if (mazeToDisplay != string.Empty)
                ChangeForm(mazeToDisplay, cbx_algorithm.Text);
        }

        private async Task<string> RequestMaze() {
            using var channel = GrpcChannel.ForAddress("https://localhost:7178");

            var clientBuild = new MazeBuilder.MazeBuilderClient(channel);
            BuiltMaze replyBuild;
            try {
                replyBuild = await clientBuild.BuildMazeAsync(new MazeRequest {
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
                HandleServerError();
                return string.Empty;
            }

            var clientStatsGlobal = new GlobalStatHandler.GlobalStatHandlerClient(channel);
            try {
                var replyStatsGlobal = await clientStatsGlobal.IncrementMazeAsync(new MazeType { MazeType_ = cbx_algorithm.Text }, deadline: DateTime.UtcNow.AddSeconds(3));
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded) { }

            var clientStatsUser = new UserStatHandler.UserStatHandlerClient(channel);
            try {
                var replyStatsUser = await clientStatsUser.UserIncrementMazeAsync(new UserMazeType { MazeType = cbx_algorithm.Text, UserID = (int)Globals.g_userID },
                    deadline: DateTime.UtcNow.AddSeconds(3));
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded) { }

            return replyBuild.Maze;
        }

        private void ChangeForm(string maze, string algorithm) {
            Form mazeDisplay = new frm_mazeDisplay(maze, algorithm);
            mazeDisplay.FormClosed += (s, args) => HandleAllowSend();
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

                ChangeForm(reply.Maze, reply.MazeGenAlg);

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
                    cbx_loadedMazes.SelectedIndex = -1;
                }
                else {
                    lbl_loadError.Text = "Error Deleting\nmaze!";
                }

            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded) {
                lbl_loadError.Text = "Error Deleting\nmaze!";
            }
        }

        private async void btn_displayStats_Click(object sender, EventArgs e) {
            if (cbx_statType.Text == string.Empty) return;

            using var channel = GrpcChannel.ForAddress("https://localhost:7178");
            var client = new StatsGetter.StatsGetterClient(channel);

            if (cbx_statType.Text == "Mazes Generated" && chbx_globalStats.Checked) {
                try {
                    var reply = await client.GetGlobalMazesGeneratedAsync(new GetGlobalMazesGeneratedRequest { },
                        deadline: DateTime.UtcNow.AddSeconds(3));

                    Chart chrt_mazesGenerated = HandleMazesGeneratedStatsView();
                    Series series = new("Maze Types Generated");
                    series.ChartType = SeriesChartType.Pie;

                    string[] segmentNames = { "Recursive Backtrack", "Growing tree", "Wilson's" };
                    double[] segmentValues = { reply.RecursiveBacktrackMazesGenerated, reply.GrowingTreeMazesGenerated, reply.WilsonsMazesGenerated };
                    series.Points.DataBindXY(segmentNames, segmentValues);

                    chrt_mazesGenerated.Series.Add(series);
                }
                catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded) {
                    HandleServerError();
                }
            }
            else if (cbx_statType.Text == "Mazes Generated" && !chbx_globalStats.Checked) {
                try {
                    var reply = await client.GetUserMazesGeneratedAsync(new GetUserMazesGeneratedRequest { UserID = (int)Globals.g_userID },
                        deadline: DateTime.UtcNow.AddSeconds(3));

                    Chart chrt_mazesGenerated = HandleMazesGeneratedStatsView();
                    Series series = new("Maze Types Generated");
                    series.ChartType = SeriesChartType.Pie;

                    string[] segmentNames = { "Recursive Backtrack", "Growing Tree", "Wilson's" };
                    double[] segmentValues = { reply.RecursiveBacktrackMazesGenerated, reply.GrowingTreeMazesGenerated, reply.WilsonsMazesGenerated };
                    series.Points.DataBindXY(segmentNames, segmentValues);

                    chrt_mazesGenerated.Series.Add(series);
                }
                catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded) {
                    HandleServerError();
                }
            }
            else if (cbx_statType.Text == "Best Times" && chbx_globalStats.Checked) {
                try {
                    var reply = await client.GetGlobalTimesAsync(new GetGlobalTimesRequest { },
                        deadline: DateTime.UtcNow.AddSeconds(3));

                    RichTextBox rtb_times = HandleTimeStatsView();
                    rtb_times.Text += "Global Best Times\n";
                    rtb_times.Text += $"1st:  {reply.Time1Username} : {reply.Time1DisplayTime}\n2nd:  {reply.Time2Username} : {reply.Time2DisplayTime}\n3rd:  {reply.Time3Username} : {reply.Time3DisplayTime}\n4th:  {reply.Time4Username} : {reply.Time4DisplayTime}\n5th:  {reply.Time5Username} : {reply.Time5DisplayTime}\n6th:  {reply.Time6Username} : {reply.Time6DisplayTime}\n7th:  {reply.Time7Username} : {reply.Time7DisplayTime}\n8th:  {reply.Time8Username} : {reply.Time8DisplayTime}\n9th:  {reply.Time9Username} : {reply.Time9DisplayTime}\n10th: {reply.Time10Username} : {reply.Time10DisplayTime}";
                }
                catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded) {
                    HandleServerError();
                }
            }
            else if (cbx_statType.Text == "Best Times" && !chbx_globalStats.Checked) {
                try {
                    var reply = await client.GetUserTimesAsync(new GetUserTimesRequest { UserID = (int)Globals.g_userID },
                        deadline: DateTime.UtcNow.AddSeconds(3));

                    RichTextBox rtb_times = HandleTimeStatsView();
                    rtb_times.Font = new Font("Calibri", 20, FontStyle.Bold);
                    rtb_times.Text += "Your Best Times\n";
                    rtb_times.Font = DefaultFont;
                    rtb_times.Text += $"1st:  {reply.Time1DisplayTime}\n2nd:  {reply.Time2DisplayTime}\n3rd:  {reply.Time3DisplayTime}\n4th:  {reply.Time4DisplayTime}\n5th:  {reply.Time5DisplayTime}\n6th:  {reply.Time6DisplayTime}\n7th:  {reply.Time7DisplayTime}\n8th:  {reply.Time8DisplayTime}\n9th:  {reply.Time9DisplayTime}\n10th: {reply.Time10DisplayTime}";
                }
                catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded) {
                    HandleServerError();
                }
            }
        }

        private RichTextBox HandleTimeStatsView() {
            RichTextBox rtb_times;
            pnl_graph.Controls.Clear();
            pnl_graph.Controls.Add(rtb_times = new());

            rtb_times.Dock = DockStyle.Fill;

            return rtb_times;
        }

        private Chart HandleMazesGeneratedStatsView() {
            Chart chrt_generatedStats;
            pnl_graph.Controls.Clear();
            pnl_graph.Controls.Add(chrt_generatedStats = new());

            chrt_generatedStats.Dock = DockStyle.Fill;
            chrt_generatedStats.ChartAreas.Add(new ChartArea("MazeChartArea"));
            chrt_generatedStats.ChartAreas["MazeChartArea"].Area3DStyle.Enable3D = true;


            return chrt_generatedStats;
        }

        private void cbx_algorithm_SelectedIndexChanged(object sender, EventArgs e) {
            algorithmSelected = true;
            HandleAllowSend();
        }

        private void cbx_whereExit_SelectedIndexChanged(object sender, EventArgs e) {
            exitSelected = true;
            HandleAllowSend();
        }
    }
}