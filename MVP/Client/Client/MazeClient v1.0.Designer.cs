namespace Client
{
    partial class MazeClient
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            lbl_title = new Label();
            lbl_algorithm = new Label();
            cbx_algorithm = new ComboBox();
            lbl_mazeWidth = new Label();
            nud_mazeWidth = new NumericUpDown();
            nud_mazeHeight = new NumericUpDown();
            lbl_mazeHeight = new Label();
            nud_removeWalls = new NumericUpDown();
            lbl_removeWalls = new Label();
            btn_requestMaze = new Button();
            lbl_error = new Label();
            tlp_maze = new TableLayoutPanel();
            cbx_whereExit = new ComboBox();
            lbl_whereExit = new Label();
            ((System.ComponentModel.ISupportInitialize)nud_mazeWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_mazeHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_removeWalls).BeginInit();
            SuspendLayout();
            // 
            // lbl_title
            // 
            lbl_title.AutoSize = true;
            lbl_title.Font = new Font("Calibri", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_title.Location = new Point(12, 9);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(170, 33);
            lbl_title.TabIndex = 0;
            lbl_title.Text = "Maze Options";
            // 
            // lbl_algorithm
            // 
            lbl_algorithm.AutoSize = true;
            lbl_algorithm.Location = new Point(12, 65);
            lbl_algorithm.Name = "lbl_algorithm";
            lbl_algorithm.Size = new Size(61, 15);
            lbl_algorithm.TabIndex = 1;
            lbl_algorithm.Text = "Algorithm";
            // 
            // cbx_algorithm
            // 
            cbx_algorithm.FormattingEnabled = true;
            cbx_algorithm.Items.AddRange(new object[] { "Recursive Backtrack" });
            cbx_algorithm.Location = new Point(95, 63);
            cbx_algorithm.Name = "cbx_algorithm";
            cbx_algorithm.Size = new Size(132, 23);
            cbx_algorithm.TabIndex = 2;
            // 
            // lbl_mazeWidth
            // 
            lbl_mazeWidth.AutoSize = true;
            lbl_mazeWidth.Location = new Point(12, 94);
            lbl_mazeWidth.Name = "lbl_mazeWidth";
            lbl_mazeWidth.Size = new Size(39, 15);
            lbl_mazeWidth.TabIndex = 3;
            lbl_mazeWidth.Text = "Width";
            // 
            // nud_mazeWidth
            // 
            nud_mazeWidth.Location = new Point(95, 92);
            nud_mazeWidth.Maximum = new decimal(new int[] { 80, 0, 0, 0 });
            nud_mazeWidth.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            nud_mazeWidth.Name = "nud_mazeWidth";
            nud_mazeWidth.Size = new Size(132, 23);
            nud_mazeWidth.TabIndex = 4;
            nud_mazeWidth.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // nud_mazeHeight
            // 
            nud_mazeHeight.Location = new Point(95, 121);
            nud_mazeHeight.Maximum = new decimal(new int[] { 80, 0, 0, 0 });
            nud_mazeHeight.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            nud_mazeHeight.Name = "nud_mazeHeight";
            nud_mazeHeight.Size = new Size(132, 23);
            nud_mazeHeight.TabIndex = 6;
            nud_mazeHeight.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // lbl_mazeHeight
            // 
            lbl_mazeHeight.AutoSize = true;
            lbl_mazeHeight.Location = new Point(12, 123);
            lbl_mazeHeight.Name = "lbl_mazeHeight";
            lbl_mazeHeight.Size = new Size(43, 15);
            lbl_mazeHeight.TabIndex = 5;
            lbl_mazeHeight.Text = "Height";
            // 
            // nud_removeWalls
            // 
            nud_removeWalls.Location = new Point(95, 150);
            nud_removeWalls.Name = "nud_removeWalls";
            nud_removeWalls.Size = new Size(132, 23);
            nud_removeWalls.TabIndex = 8;
            // 
            // lbl_removeWalls
            // 
            lbl_removeWalls.AutoSize = true;
            lbl_removeWalls.Location = new Point(12, 152);
            lbl_removeWalls.Name = "lbl_removeWalls";
            lbl_removeWalls.Size = new Size(81, 15);
            lbl_removeWalls.TabIndex = 7;
            lbl_removeWalls.Text = "Remove Walls";
            // 
            // btn_requestMaze
            // 
            btn_requestMaze.Location = new Point(12, 217);
            btn_requestMaze.Name = "btn_requestMaze";
            btn_requestMaze.Size = new Size(215, 35);
            btn_requestMaze.TabIndex = 9;
            btn_requestMaze.Text = "Request Maze";
            btn_requestMaze.UseVisualStyleBackColor = true;
            btn_requestMaze.Click += btn_requestMaze_Click;
            // 
            // lbl_error
            // 
            lbl_error.AutoSize = true;
            lbl_error.ForeColor = Color.Red;
            lbl_error.Location = new Point(95, 217);
            lbl_error.Name = "lbl_error";
            lbl_error.Size = new Size(0, 15);
            lbl_error.TabIndex = 10;
            // 
            // tlp_maze
            // 
            tlp_maze.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlp_maze.AutoScroll = true;
            tlp_maze.AutoSize = true;
            tlp_maze.BackColor = SystemColors.Control;
            tlp_maze.ColumnCount = 1;
            tlp_maze.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_maze.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tlp_maze.Location = new Point(330, 25);
            tlp_maze.Name = "tlp_maze";
            tlp_maze.RowCount = 1;
            tlp_maze.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_maze.Size = new Size(300, 300);
            tlp_maze.TabIndex = 11;
            tlp_maze.CellPaint += tlp_maze_CellPaint;
            // 
            // cbx_whereExit
            // 
            cbx_whereExit.FormattingEnabled = true;
            cbx_whereExit.Items.AddRange(new object[] { "Centre", "Border" });
            cbx_whereExit.Location = new Point(95, 179);
            cbx_whereExit.Name = "cbx_whereExit";
            cbx_whereExit.Size = new Size(132, 23);
            cbx_whereExit.TabIndex = 13;
            // 
            // lbl_whereExit
            // 
            lbl_whereExit.AutoSize = true;
            lbl_whereExit.Location = new Point(12, 181);
            lbl_whereExit.Name = "lbl_whereExit";
            lbl_whereExit.Size = new Size(75, 15);
            lbl_whereExit.TabIndex = 12;
            lbl_whereExit.Text = "Exit Location";
            // 
            // MazeClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 351);
            Controls.Add(tlp_maze);
            Controls.Add(cbx_whereExit);
            Controls.Add(lbl_whereExit);
            Controls.Add(lbl_error);
            Controls.Add(btn_requestMaze);
            Controls.Add(nud_removeWalls);
            Controls.Add(lbl_removeWalls);
            Controls.Add(nud_mazeHeight);
            Controls.Add(lbl_mazeHeight);
            Controls.Add(nud_mazeWidth);
            Controls.Add(lbl_mazeWidth);
            Controls.Add(cbx_algorithm);
            Controls.Add(lbl_algorithm);
            Controls.Add(lbl_title);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MazeClient";
            Text = "MazeClient v1.0";
            Load += MazeClient_Load;
            ((System.ComponentModel.ISupportInitialize)nud_mazeWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_mazeHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_removeWalls).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_title;
        private Label lbl_algorithm;
        private ComboBox cbx_algorithm;
        private Label lbl_mazeWidth;
        private NumericUpDown nud_mazeWidth;
        private NumericUpDown nud_mazeHeight;
        private Label lbl_mazeHeight;
        private NumericUpDown nud_removeWalls;
        private Label lbl_removeWalls;
        private Button btn_requestMaze;
        private Label lbl_error;
        private TableLayoutPanel tlp_maze;
        private ComboBox cbx_whereExit;
        private Label lbl_whereExit;
    }
}