using Client_Mazes;
using Grpc.Core;
using Grpc.Net.Client;
using Newtonsoft.Json;
using Server;
using System.Diagnostics;

namespace Client
{
    public partial class frm_mazeDisplay : Form
    {
        private readonly Maze maze;
        private Coordinate player;
        private List<Coordinate> solution;
        private string mazeType;

        private bool solved = false;
        private bool startedManualSolve = false;
        private Stopwatch sw = new();

        //forces form to fully render before displaying, removing flickering.
        protected override CreateParams CreateParams
        {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x2000000;
                return cp;
            }
        }

        public frm_mazeDisplay(string mazeToDisplay, string mazeType) {
            InitializeComponent();

            this.mazeType = mazeType;

            switch (mazeType) {
                case "Recursive Backtrack":
                    maze = JsonConvert.DeserializeObject<RecursiveBacktrackGeneration>(mazeToDisplay);
                    break;
                case "Wilson's":
                    maze = JsonConvert.DeserializeObject<WilsonsGeneration>(mazeToDisplay);
                    break;
            }

            player = new Coordinate(maze.MazeEntranceCoordinate.Xpos, maze.MazeEntranceCoordinate.Ypos);

            btn_requestSolve.Enabled = false;
            cbx_solveType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private async void btn_requestSolve_Click(object sender, EventArgs e) {
            player = null;
            string mazeToSolve = JsonConvert.SerializeObject(maze);
            using var channel = GrpcChannel.ForAddress("https://localhost:7178");
            var client = new MazeSolver.MazeSolverClient(channel);
            var reply = await client.SolveMazeAsync(new SolveRequest {
                Maze = mazeToSolve,
                Algorithm = cbx_solveType.Text,
                MazeGenerationAlgorithm = mazeType
            });

            HandleSolveRender(reply);
        }

        private void HandleSolveRender(Server.Path reply) {
            solution = JsonConvert.DeserializeObject<List<Coordinate>>(reply.Path_);

            solved = true;

            btn_close.Enabled = true;
            btn_requestSolve.Enabled = false;
            btn_left.Enabled = false;
            btn_right.Enabled = false;
            btn_up.Enabled = false;
            btn_down.Enabled = false;

            sw = null;

            tlp_MazeDisplay.Refresh();
        }

        private void SetDisplaySize() {
            Width = (45 + Globals.g_cellWidth * maze.MazeActualWidth > 510) ? 45 + Globals.g_cellWidth * maze.MazeActualWidth : 510;
            Height = 145 + Globals.g_cellHeight * maze.MazeActualHeight;
            pnl_mazeContainer.Width = Globals.g_cellWidth * maze.MazeActualWidth + 5;
            pnl_mazeContainer.Height = Globals.g_cellHeight * maze.MazeActualHeight + 5;
            pnl_mazeContainer.Location = new Point(10, 80);
        }

        private void tlp_MazeDisplay_CellPaint(object sender, TableLayoutCellPaintEventArgs e) {
            if (player != null && player.Equals(new Coordinate(e.Column, e.Row))) //Draw player.
                e.Graphics.FillRectangle(Brushes.Blue, e.CellBounds); //Blue

            else if (maze.MazeEntranceCoordinate.Equals(new Coordinate(e.Column, e.Row))) //Draw entrance.
                e.Graphics.FillRectangle(Brushes.Red, e.CellBounds); //Red

            else if (maze.MazeExitCoordinate.Equals(new Coordinate(e.Column, e.Row))) //Draw exit.
                e.Graphics.FillRectangle(Brushes.LawnGreen, e.CellBounds); //LawnGreen

            else if (maze.MazeWalls[e.Row, e.Column]) //Draw wall.
                e.Graphics.FillRectangle(Brushes.Black, e.CellBounds); //Black

            else if (solution != null) { //Draw solution.
                foreach (Coordinate c in solution) {
                    if (c.Xpos == e.Column && c.Ypos == e.Row)
                        e.Graphics.FillRectangle(Brushes.Purple, e.CellBounds); //Purple
                }
            }

            else //Draw path.
                e.Graphics.FillRectangle(Brushes.White, e.CellBounds); //White
        }

        private void frm_mazeDisplay_Load(object sender, EventArgs e) {
            SetDisplaySize();

            Text = $"MazeClient {Globals.g_version}";

            tlp_MazeDisplay.ColumnStyles.Clear();
            tlp_MazeDisplay.RowStyles.Clear();

            tlp_MazeDisplay.RowCount = maze.MazeActualHeight;
            tlp_MazeDisplay.ColumnCount = maze.MazeActualWidth;

            for (int i = 0; i < maze.MazeActualHeight; i++)
                tlp_MazeDisplay.RowStyles.Add(new RowStyle(SizeType.Absolute, Globals.g_cellHeight));
            for (int i = 0; i < maze.MazeActualWidth; i++)
                tlp_MazeDisplay.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Globals.g_cellWidth));

        }
        private void btn_close_Click(object sender, EventArgs e) {
            Close();
        }

        private async void CheckSolved() {
            if (!startedManualSolve) {
                startedManualSolve = true;
                HandleTimer();
            }

            if (!player.Equals(maze.MazeExitCoordinate)) return;

            solved = true;
            lbl_solved.ForeColor = Color.Green;
            lbl_solved.Text = "Solved!";
            btn_close.Enabled = true;
            btn_requestSolve.Enabled = false;
            btn_left.Enabled = false;
            btn_right.Enabled = false;
            btn_up.Enabled = false;
            btn_down.Enabled = false;

            using var channel = GrpcChannel.ForAddress("https://localhost:7178");

            var clientGlobal = new GlobalStatHandler.GlobalStatHandlerClient(channel);
            try {
                var replyGlobal = await clientGlobal.UploadTimeAsync(new Time {
                    TimeMilliseconds = (int)sw.ElapsedMilliseconds,
                    Time_ = sw.Elapsed.ToString(),
                    Username = Globals.g_username
                });
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded){ }

            var clientUser = new UserStatHandler.UserStatHandlerClient(channel);
            try {
                var replyUser = await clientUser.UserUploadTimeAsync(new UserTime {
                    TimeMilliseconds = (int)sw.ElapsedMilliseconds,
                    Time = sw.Elapsed.ToString(),
                    UserID = (int)Globals.g_userID
                });
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded) { }
        }

        private void HandleTimer() {
            sw.Start();


            ThreadPool.QueueUserWorkItem((state) => {
                try {
                    while (!solved)
                        Invoke(() => {
                            if (sw != null)
                                lbl_timer.Text = sw.Elapsed.ToString();
                            else
                                lbl_timer.Text = string.Empty;
                        });
                }
                catch { }
            });
        }

        private bool IsWall(Coordinate player, string direction) {
            try {
                return direction switch {
                    "Up" => !maze.MazeWalls[player.Ypos - 1, player.Xpos],
                    "Down" => !maze.MazeWalls[player.Ypos + 1, player.Xpos],
                    "Left" => !maze.MazeWalls[player.Ypos, player.Xpos - 1],
                    "Right" => !maze.MazeWalls[player.Ypos, player.Xpos + 1],
                    _ => true
                };
            }
            catch { return false; }
        }
        private void frm_mazeDisplay_KeyDown(object sender, KeyEventArgs e) {
            if (solved) return;

            switch (e.KeyCode) {
                case Keys.W:
                    if (IsWall(player, "Up"))
                        player = new Coordinate(player.Xpos, player.Ypos - 1);
                    break;

                case Keys.S:
                    if (IsWall(player, "Down"))
                        player = new Coordinate(player.Xpos, player.Ypos + 1);
                    break;

                case Keys.A:
                    if (IsWall(player, "Left"))
                        player = new Coordinate(player.Xpos - 1, player.Ypos);
                    break;

                case Keys.D:
                    if (IsWall(player, "Right"))
                        player = new Coordinate(player.Xpos + 1, player.Ypos);
                    break;

                default:
                    break;
            }

            if (new Keys[] { Keys.W, Keys.A, Keys.S, Keys.D }.Contains(e.KeyCode)) {
                tlp_MazeDisplay.Refresh();
                CheckSolved();
            }
        }

        private void btn_left_Click(object sender, EventArgs e) {
            if (solved) return;

            if (IsWall(player, "Left"))
                player = new Coordinate(player.Xpos - 1, player.Ypos);
            tlp_MazeDisplay.Refresh();
            CheckSolved();
        }

        private void btn_right_Click(object sender, EventArgs e) {
            if (solved) return;

            if (IsWall(player, "Right"))
                player = new Coordinate(player.Xpos + 1, player.Ypos);
            tlp_MazeDisplay.Refresh();
            CheckSolved();
        }

        private void btn_up_Click(object sender, EventArgs e) {
            if (solved) return;

            if (IsWall(player, "Up"))
                player = new Coordinate(player.Xpos, player.Ypos - 1);
            tlp_MazeDisplay.Refresh();
            CheckSolved();
        }

        private void btn_down_Click(object sender, EventArgs e) {
            if (solved) return;

            if (IsWall(player, "Down"))
                player = new Coordinate(player.Xpos, player.Ypos + 1);
            tlp_MazeDisplay.Refresh();
            CheckSolved();
        }

        #region Extra WASD input listeners
        private void btn_left_KeyDown(object sender, KeyEventArgs e) {
            if (solved) return;

            switch (e.KeyCode) {
                case Keys.W:
                    if (IsWall(player, "Up"))
                        player = new Coordinate(player.Xpos, player.Ypos - 1);
                    break;

                case Keys.S:
                    if (IsWall(player, "Down"))
                        player = new Coordinate(player.Xpos, player.Ypos + 1);
                    break;

                case Keys.A:
                    if (IsWall(player, "Left"))
                        player = new Coordinate(player.Xpos - 1, player.Ypos);
                    break;

                case Keys.D:
                    if (IsWall(player, "Right"))
                        player = new Coordinate(player.Xpos + 1, player.Ypos);
                    break;

                default:
                    break;
            }
            if (new Keys[] { Keys.W, Keys.A, Keys.S, Keys.D }.Contains(e.KeyCode)) {
                tlp_MazeDisplay.Refresh();
                CheckSolved();
            }
        }

        private void btn_right_KeyDown(object sender, KeyEventArgs e) {
            if (solved) return;

            switch (e.KeyCode) {
                case Keys.W:
                    if (IsWall(player, "Up"))
                        player = new Coordinate(player.Xpos, player.Ypos - 1);
                    break;

                case Keys.S:
                    if (IsWall(player, "Down"))
                        player = new Coordinate(player.Xpos, player.Ypos + 1);
                    break;

                case Keys.A:
                    if (IsWall(player, "Left"))
                        player = new Coordinate(player.Xpos - 1, player.Ypos);
                    break;

                case Keys.D:
                    if (IsWall(player, "Right"))
                        player = new Coordinate(player.Xpos + 1, player.Ypos);
                    break;

                default:
                    break;
            }
            if (new Keys[] { Keys.W, Keys.A, Keys.S, Keys.D }.Contains(e.KeyCode)) {
                tlp_MazeDisplay.Refresh();
                CheckSolved();
            }
        }

        private void btn_up_KeyDown(object sender, KeyEventArgs e) {
            if (solved) return;

            switch (e.KeyCode) {
                case Keys.W:
                    if (IsWall(player, "Up"))
                        player = new Coordinate(player.Xpos, player.Ypos - 1);
                    break;

                case Keys.S:
                    if (IsWall(player, "Down"))
                        player = new Coordinate(player.Xpos, player.Ypos + 1);
                    break;

                case Keys.A:
                    if (IsWall(player, "Left"))
                        player = new Coordinate(player.Xpos - 1, player.Ypos);
                    break;

                case Keys.D:
                    if (IsWall(player, "Right"))
                        player = new Coordinate(player.Xpos + 1, player.Ypos);
                    break;

                default:
                    break;
            }
            if (new Keys[] { Keys.W, Keys.A, Keys.S, Keys.D }.Contains(e.KeyCode)) {
                tlp_MazeDisplay.Refresh();
                CheckSolved();
            }
        }

        private void btn_down_KeyDown(object sender, KeyEventArgs e) {
            if (solved) return;

            switch (e.KeyCode) {
                case Keys.W:
                    if (IsWall(player, "Up"))
                        player = new Coordinate(player.Xpos, player.Ypos - 1);
                    break;

                case Keys.S:
                    if (IsWall(player, "Down"))
                        player = new Coordinate(player.Xpos, player.Ypos + 1);
                    break;

                case Keys.A:
                    if (IsWall(player, "Left"))
                        player = new Coordinate(player.Xpos - 1, player.Ypos);
                    break;

                case Keys.D:
                    if (IsWall(player, "Right"))
                        player = new Coordinate(player.Xpos + 1, player.Ypos);
                    break;

                default:
                    break;
            }
            if (new Keys[] { Keys.W, Keys.A, Keys.S, Keys.D }.Contains(e.KeyCode)) {
                tlp_MazeDisplay.Refresh();
                CheckSolved();
            }
        }
        private void btn_requestSolve_KeyDown(object sender, KeyEventArgs e) {
            if (solved) return;

            switch (e.KeyCode) {
                case Keys.W:
                    if (IsWall(player, "Up"))
                        player = new Coordinate(player.Xpos, player.Ypos - 1);
                    break;

                case Keys.S:
                    if (IsWall(player, "Down"))
                        player = new Coordinate(player.Xpos, player.Ypos + 1);
                    break;

                case Keys.A:
                    if (IsWall(player, "Left"))
                        player = new Coordinate(player.Xpos - 1, player.Ypos);
                    break;

                case Keys.D:
                    if (IsWall(player, "Right"))
                        player = new Coordinate(player.Xpos + 1, player.Ypos);
                    break;

                default:
                    break;
            }
            if (new Keys[] { Keys.W, Keys.A, Keys.S, Keys.D }.Contains(e.KeyCode)) {
                tlp_MazeDisplay.Refresh();
                CheckSolved();
            }
        }

        private void cbx_solveType_KeyDown(object sender, KeyEventArgs e) {
            if (solved) return;

            switch (e.KeyCode) {
                case Keys.W:
                    if (IsWall(player, "Up"))
                        player = new Coordinate(player.Xpos, player.Ypos - 1);
                    break;

                case Keys.S:
                    if (IsWall(player, "Down"))
                        player = new Coordinate(player.Xpos, player.Ypos + 1);
                    break;

                case Keys.A:
                    if (IsWall(player, "Left"))
                        player = new Coordinate(player.Xpos - 1, player.Ypos);
                    break;

                case Keys.D:
                    if (IsWall(player, "Right"))
                        player = new Coordinate(player.Xpos + 1, player.Ypos);
                    break;

                default:
                    break;
            }
            if (new Keys[] { Keys.W, Keys.A, Keys.S, Keys.D }.Contains(e.KeyCode)) {
                tlp_MazeDisplay.Refresh();
                CheckSolved();
            }
        }
        private void btn_serverSave_KeyDown(object sender, KeyEventArgs e) {
            if (solved) return;

            switch (e.KeyCode) {
                case Keys.W:
                    if (IsWall(player, "Up"))
                        player = new Coordinate(player.Xpos, player.Ypos - 1);
                    break;

                case Keys.S:
                    if (IsWall(player, "Down"))
                        player = new Coordinate(player.Xpos, player.Ypos + 1);
                    break;

                case Keys.A:
                    if (IsWall(player, "Left"))
                        player = new Coordinate(player.Xpos - 1, player.Ypos);
                    break;

                case Keys.D:
                    if (IsWall(player, "Right"))
                        player = new Coordinate(player.Xpos + 1, player.Ypos);
                    break;

                default:
                    break;
            }
            if (new Keys[] { Keys.W, Keys.A, Keys.S, Keys.D }.Contains(e.KeyCode)) {
                tlp_MazeDisplay.Refresh();
                CheckSolved();
            }
        }

        private void btn_localSave_KeyDown(object sender, KeyEventArgs e) {
            if (solved) return;

            switch (e.KeyCode) {
                case Keys.W:
                    if (IsWall(player, "Up"))
                        player = new Coordinate(player.Xpos, player.Ypos - 1);
                    break;

                case Keys.S:
                    if (IsWall(player, "Down"))
                        player = new Coordinate(player.Xpos, player.Ypos + 1);
                    break;

                case Keys.A:
                    if (IsWall(player, "Left"))
                        player = new Coordinate(player.Xpos - 1, player.Ypos);
                    break;

                case Keys.D:
                    if (IsWall(player, "Right"))
                        player = new Coordinate(player.Xpos + 1, player.Ypos);
                    break;

                default:
                    break;
            }
            if (new Keys[] { Keys.W, Keys.A, Keys.S, Keys.D }.Contains(e.KeyCode)) {
                tlp_MazeDisplay.Refresh();
                CheckSolved();
            }
        }

        #endregion

        private void cbx_solveType_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbx_solveType.Text != string.Empty) {
                btn_requestSolve.Enabled = true;
            }
            else {
                btn_requestSolve.Enabled = false;
            }
        }

        private void btn_localSave_Click(object sender, EventArgs e) {
            Coordinate tempPlayer = player;
            player = null;
            tlp_MazeDisplay.Refresh();

            int width = tlp_MazeDisplay.Size.Width;
            int height = tlp_MazeDisplay.Size.Height;

            Bitmap mazeToSave = new(width, height);
            tlp_MazeDisplay.DrawToBitmap(mazeToSave, new Rectangle(0, 0, width, height));

            SaveFileDialog sf = new();
            sf.Filter = "JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png";
            sf.ShowDialog();
            var path = sf.FileName;

            mazeToSave.Save(path);

            player = tempPlayer;
            tlp_MazeDisplay.Refresh();
        }

        private async void btn_serverSave_Click(object sender, EventArgs e) {

            if (txb_mazeName.Text == string.Empty) {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = "Maze needs a name!";
                ThreadPool.QueueUserWorkItem((state) => {
                    Thread.Sleep(1000);
                    Invoke(() => lbl_error.Text = string.Empty);
                });
                return;
            }

            this.maze.ResetVisited();

            string maze = JsonConvert.SerializeObject(this.maze);
            using var channel = GrpcChannel.ForAddress("https://localhost:7178");
            var client = new Saver.SaverClient(channel);
            try {
                var reply = await client.SaveMazeAsync(new SaveRequest {
                    MazeName = txb_mazeName.Text,
                    MazeType = mazeType,
                    MazeJson = maze,
                    UserID = (int)Globals.g_userID
                },
                deadline: DateTime.UtcNow.AddSeconds(3));

                if (reply.Success) {
                    lbl_error.ForeColor = Color.Green;
                    lbl_error.Text = "Success!";
                    ThreadPool.QueueUserWorkItem((state) => {
                        Thread.Sleep(1000);
                        Invoke(() => lbl_error.Text = string.Empty);
                    });
                }
                else {
                    lbl_error.ForeColor = Color.Red;
                    lbl_error.Text = "Error!";
                    ThreadPool.QueueUserWorkItem((state) => {
                        Thread.Sleep(1000);
                        Invoke(() => lbl_error.Text = string.Empty);
                    });
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded) {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = "Error!";
                ThreadPool.QueueUserWorkItem((state) => {
                    Thread.Sleep(1000);
                    Invoke(() => lbl_error.Text = string.Empty);
                });
            }
        }


    }
}
