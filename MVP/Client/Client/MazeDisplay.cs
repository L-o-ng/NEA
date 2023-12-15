using Algorithm_testing;
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
        private const int cellWidth = 10;
        private const int cellHeight = 10;
        private bool solved = false;
        private bool startedManualSolve = false;
        private Stopwatch sw = new();
        //forces form to fully render before displaying, removing flickering.
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x2000000;
                return cp;
            }
        }

        public frm_mazeDisplay(string mazeToDisplay, string mazeType)
        {
            InitializeComponent();
            switch (mazeType)
            {
                case "Recursive Backtrack":
                    maze = JsonConvert.DeserializeObject<DepthFirstGeneration>(mazeToDisplay);
                    break;
            }
            player = new Coordinate(maze.MazeEntranceCoordinate.Xpos, maze.MazeEntranceCoordinate.Ypos);
        }

        private async void btn_requestSolve_Click(object sender, EventArgs e)
        {
            string mazeToSolve = JsonConvert.SerializeObject(maze);
            using var channel = GrpcChannel.ForAddress("https://localhost:7178");
            var client = new MazeSolver.MazeSolverClient(channel);
            var reply = await client.SolveMazeAsync(new SolveRequest
            {
                Maze = mazeToSolve
            });

            HandleSolveRender();
        }

        private void HandleSolveRender()
        {
            throw new NotImplementedException();
        }

        private void SetDisplaySize()
        {
            Width = (45 + cellWidth * maze.MazeActualWidth > 325) ? 45 + cellWidth * maze.MazeActualWidth : 325;
            Height = 145 + cellHeight * maze.MazeActualHeight;
            pnl_mazeContainer.Width = cellWidth * maze.MazeActualWidth + 5;
            pnl_mazeContainer.Height = cellHeight * maze.MazeActualHeight + 5;
            pnl_mazeContainer.Location = new Point(10, 80);
        }

        private void tlp_MazeDisplay_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (player.Equals(new Coordinate(e.Column, e.Row)))
                e.Graphics.FillRectangle(Brushes.Blue, e.CellBounds);
            else if (maze.MazeEntranceCoordinate.Equals(new Coordinate(e.Column, e.Row)))
                e.Graphics.FillRectangle(Brushes.Red, e.CellBounds);
            else if (maze.MazeExitCoordinate.Equals(new Coordinate(e.Column, e.Row)))
                e.Graphics.FillRectangle(Brushes.LawnGreen, e.CellBounds);
            else if (maze.MazeWalls[e.Row, e.Column])
                e.Graphics.FillRectangle(Brushes.Black, e.CellBounds);
            else
                e.Graphics.FillRectangle(Brushes.White, e.CellBounds);
        }

        private void frm_mazeDisplay_Load(object sender, EventArgs e)
        {
            SetDisplaySize();

            tlp_MazeDisplay.ColumnStyles.Clear();
            tlp_MazeDisplay.RowStyles.Clear();

            tlp_MazeDisplay.RowCount = maze.MazeActualHeight;
            tlp_MazeDisplay.ColumnCount = maze.MazeActualWidth;

            for (int i = 0; i < maze.MazeActualHeight; i++)
                tlp_MazeDisplay.RowStyles.Add(new RowStyle(SizeType.Absolute, cellHeight));
            for (int i = 0; i < maze.MazeActualWidth; i++)
                tlp_MazeDisplay.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, cellWidth));

        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CheckSolved()
        {
            if (!startedManualSolve)
            {
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
        }

        private void HandleTimer()
        {
            sw.Start();


            ThreadPool.QueueUserWorkItem((state) =>
            {
                try
                {
                    while (!solved)
                        Invoke(() => lbl_timer.Text = sw.Elapsed.ToString());
                }
                catch { }
            });
        }

        private bool IsWall(Coordinate player, string direction)
        {
            try
            {
                return direction switch
                {
                    "Up" => !maze.MazeWalls[player.Ypos - 1, player.Xpos],
                    "Down" => !maze.MazeWalls[player.Ypos + 1, player.Xpos],
                    "Left" => !maze.MazeWalls[player.Ypos, player.Xpos - 1],
                    "Right" => !maze.MazeWalls[player.Ypos, player.Xpos + 1],
                    _ => true
                };
            }
            catch { return false; }
        }
        private void frm_mazeDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            if (solved) return;

            switch (e.KeyCode)
            {
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
            tlp_MazeDisplay.Refresh();
            CheckSolved();
        }

        private void btn_left_Click(object sender, EventArgs e)
        {
            if (solved) return;

            if (IsWall(player, "Left"))
                player = new Coordinate(player.Xpos - 1, player.Ypos);
            tlp_MazeDisplay.Refresh();
            CheckSolved();
        }

        private void btn_right_Click(object sender, EventArgs e)
        {
            if (solved) return;

            if (IsWall(player, "Right"))
                player = new Coordinate(player.Xpos + 1, player.Ypos);
            tlp_MazeDisplay.Refresh();
            CheckSolved();
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            if (solved) return;

            if (IsWall(player, "Up"))
                player = new Coordinate(player.Xpos, player.Ypos - 1);
            tlp_MazeDisplay.Refresh();
            CheckSolved();
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            if (solved) return;

            if (IsWall(player, "Down"))
                player = new Coordinate(player.Xpos, player.Ypos + 1);
            tlp_MazeDisplay.Refresh();
            CheckSolved();
        }

        #region Extra WASD input listeners
        private void btn_left_KeyDown(object sender, KeyEventArgs e)
        {
            if (solved) return;

            switch (e.KeyCode)
            {
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
            tlp_MazeDisplay.Refresh();
            CheckSolved();
        }

        private void btn_right_KeyDown(object sender, KeyEventArgs e)
        {
            if (solved) return;

            switch (e.KeyCode)
            {
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
            tlp_MazeDisplay.Refresh();
            CheckSolved();
        }

        private void btn_up_KeyDown(object sender, KeyEventArgs e)
        {
            if (solved) return;

            switch (e.KeyCode)
            {
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
            tlp_MazeDisplay.Refresh();
            CheckSolved();
        }

        private void btn_down_KeyDown(object sender, KeyEventArgs e)
        {
            if (solved) return;

            switch (e.KeyCode)
            {
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
            tlp_MazeDisplay.Refresh();
            CheckSolved();
        }
        private void btn_requestSolve_KeyDown(object sender, KeyEventArgs e)
        {
            if (solved) return;

            switch (e.KeyCode)
            {
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
            tlp_MazeDisplay.Refresh();
            CheckSolved();
        }

        private void cbx_solveType_KeyDown(object sender, KeyEventArgs e)
        {
            if (solved) return;

            switch (e.KeyCode)
            {
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
            tlp_MazeDisplay.Refresh();
            CheckSolved();
        }
        #endregion
    }
}
