using Algorithm_testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class frm_mazeDisplay : Form
    {
        Maze maze;
        Coordinate player;
        const int cellWidth = 10;
        const int cellHeight = 10;
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





        private void SetDisplaySize()
        {
            Width = (45 + cellWidth * maze.MazeActualWidth > 235) ? 45 + cellWidth * maze.MazeActualWidth : 235;
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
                e.Graphics.FillRectangle(Brushes.LightGreen, e.CellBounds);
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

        private void frm_mazeDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
