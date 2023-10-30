using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    public partial class MazeClient : Form
    {
        public MazeClient() {
            InitializeComponent();
        }

        private void MazeClient_Load(object sender, EventArgs e) {
            //tlp_maze.Parent = pnl_mazeBorder;
            //tlp_maze.Dock = DockStyle.Fill;
        }

        private void btn_requestMaze_Click(object sender, EventArgs e) {
            while (tlp_maze.Controls.Count > 0) {
                tlp_maze.Controls[0].Dispose();
            }
            tlp_maze.RowStyles.Clear();
            tlp_maze.ColumnStyles.Clear();

            //tlp_maze.RowCount = 2 * (int)nud_mazeHeight.Value + 1;
            //tlp_maze.ColumnCount = 2 * (int)nud_mazeWidth.Value + 1;
            tlp_maze.RowCount = (int)nud_mazeHeight.Value;
            tlp_maze.ColumnCount = (int)nud_mazeWidth.Value;


            for (int i = 0; i < tlp_maze.RowCount; i++) {
                tlp_maze.RowStyles.Add(new RowStyle(SizeType.Absolute, (tlp_maze.Height / tlp_maze.RowCount) + ((tlp_maze.Height % tlp_maze.RowCount) / tlp_maze.RowCount)));
            }
            for (int i = 0; i < tlp_maze.ColumnCount; i++) {
                tlp_maze.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, (tlp_maze.Width / tlp_maze.ColumnCount) + ((tlp_maze.Width % tlp_maze.ColumnCount) / tlp_maze.ColumnCount)));
            }
        }

        private void tlp_maze_CellPaint(object sender, TableLayoutCellPaintEventArgs e) {
            if ((e.Column + e.Row) % 2 == 1)
                e.Graphics.FillRectangle(Brushes.Black, e.CellBounds);
            else
                e.Graphics.FillRectangle(Brushes.White, e.CellBounds);
        }
    }
}