namespace Client
{
    partial class frm_mazeClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_mazeClient));
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
            cbx_whereExit = new ComboBox();
            lbl_whereExit = new Label();
            pnl_graph = new Panel();
            lbl_connectionError = new Label();
            ((System.ComponentModel.ISupportInitialize)nud_mazeWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_mazeHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_removeWalls).BeginInit();
            SuspendLayout();
            // 
            // lbl_title
            // 
            lbl_title.AutoSize = true;
            lbl_title.Font = new Font("Calibri", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_title.Location = new Point(14, 12);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(214, 41);
            lbl_title.TabIndex = 0;
            lbl_title.Text = "Maze Options";
            // 
            // lbl_algorithm
            // 
            lbl_algorithm.AutoSize = true;
            lbl_algorithm.Location = new Point(14, 87);
            lbl_algorithm.Name = "lbl_algorithm";
            lbl_algorithm.Size = new Size(76, 20);
            lbl_algorithm.TabIndex = 1;
            lbl_algorithm.Text = "Algorithm";
            // 
            // cbx_algorithm
            // 
            cbx_algorithm.FormattingEnabled = true;
            cbx_algorithm.Items.AddRange(new object[] { "Recursive Backtrack" });
            cbx_algorithm.Location = new Point(119, 84);
            cbx_algorithm.Margin = new Padding(3, 4, 3, 4);
            cbx_algorithm.Name = "cbx_algorithm";
            cbx_algorithm.Size = new Size(150, 28);
            cbx_algorithm.TabIndex = 2;
            // 
            // lbl_mazeWidth
            // 
            lbl_mazeWidth.AutoSize = true;
            lbl_mazeWidth.Location = new Point(14, 125);
            lbl_mazeWidth.Name = "lbl_mazeWidth";
            lbl_mazeWidth.Size = new Size(49, 20);
            lbl_mazeWidth.TabIndex = 3;
            lbl_mazeWidth.Text = "Width";
            // 
            // nud_mazeWidth
            // 
            nud_mazeWidth.Location = new Point(119, 123);
            nud_mazeWidth.Margin = new Padding(3, 4, 3, 4);
            nud_mazeWidth.Maximum = new decimal(new int[] { 80, 0, 0, 0 });
            nud_mazeWidth.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            nud_mazeWidth.Name = "nud_mazeWidth";
            nud_mazeWidth.Size = new Size(151, 27);
            nud_mazeWidth.TabIndex = 4;
            nud_mazeWidth.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // nud_mazeHeight
            // 
            nud_mazeHeight.Location = new Point(119, 161);
            nud_mazeHeight.Margin = new Padding(3, 4, 3, 4);
            nud_mazeHeight.Maximum = new decimal(new int[] { 80, 0, 0, 0 });
            nud_mazeHeight.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            nud_mazeHeight.Name = "nud_mazeHeight";
            nud_mazeHeight.Size = new Size(151, 27);
            nud_mazeHeight.TabIndex = 6;
            nud_mazeHeight.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // lbl_mazeHeight
            // 
            lbl_mazeHeight.AutoSize = true;
            lbl_mazeHeight.Location = new Point(14, 164);
            lbl_mazeHeight.Name = "lbl_mazeHeight";
            lbl_mazeHeight.Size = new Size(54, 20);
            lbl_mazeHeight.TabIndex = 5;
            lbl_mazeHeight.Text = "Height";
            // 
            // nud_removeWalls
            // 
            nud_removeWalls.Location = new Point(119, 200);
            nud_removeWalls.Margin = new Padding(3, 4, 3, 4);
            nud_removeWalls.Name = "nud_removeWalls";
            nud_removeWalls.Size = new Size(151, 27);
            nud_removeWalls.TabIndex = 8;
            // 
            // lbl_removeWalls
            // 
            lbl_removeWalls.AutoSize = true;
            lbl_removeWalls.Location = new Point(14, 203);
            lbl_removeWalls.Name = "lbl_removeWalls";
            lbl_removeWalls.Size = new Size(102, 20);
            lbl_removeWalls.TabIndex = 7;
            lbl_removeWalls.Text = "Remove Walls";
            // 
            // btn_requestMaze
            // 
            btn_requestMaze.Location = new Point(14, 289);
            btn_requestMaze.Margin = new Padding(3, 4, 3, 4);
            btn_requestMaze.Name = "btn_requestMaze";
            btn_requestMaze.Size = new Size(246, 47);
            btn_requestMaze.TabIndex = 9;
            btn_requestMaze.Text = "Request Maze";
            btn_requestMaze.UseVisualStyleBackColor = true;
            btn_requestMaze.Click += btn_requestMaze_Click;
            // 
            // lbl_error
            // 
            lbl_error.AutoSize = true;
            lbl_error.ForeColor = Color.Red;
            lbl_error.Location = new Point(109, 289);
            lbl_error.Name = "lbl_error";
            lbl_error.Size = new Size(0, 20);
            lbl_error.TabIndex = 10;
            // 
            // cbx_whereExit
            // 
            cbx_whereExit.FormattingEnabled = true;
            cbx_whereExit.Items.AddRange(new object[] { "Centre", "Border" });
            cbx_whereExit.Location = new Point(119, 239);
            cbx_whereExit.Margin = new Padding(3, 4, 3, 4);
            cbx_whereExit.Name = "cbx_whereExit";
            cbx_whereExit.Size = new Size(150, 28);
            cbx_whereExit.TabIndex = 13;
            // 
            // lbl_whereExit
            // 
            lbl_whereExit.AutoSize = true;
            lbl_whereExit.Location = new Point(14, 241);
            lbl_whereExit.Name = "lbl_whereExit";
            lbl_whereExit.Size = new Size(94, 20);
            lbl_whereExit.TabIndex = 12;
            lbl_whereExit.Text = "Exit Location";
            // 
            // pnl_graph
            // 
            pnl_graph.BorderStyle = BorderStyle.Fixed3D;
            pnl_graph.Location = new Point(276, 12);
            pnl_graph.Name = "pnl_graph";
            pnl_graph.Size = new Size(459, 329);
            pnl_graph.TabIndex = 14;
            // 
            // lbl_connectionError
            // 
            lbl_connectionError.AutoSize = true;
            lbl_connectionError.Location = new Point(18, 53);
            lbl_connectionError.Name = "lbl_connectionError";
            lbl_connectionError.Size = new Size(0, 20);
            lbl_connectionError.TabIndex = 15;
            // 
            // frm_mazeClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(747, 353);
            Controls.Add(lbl_connectionError);
            Controls.Add(pnl_graph);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "frm_mazeClient";
            Text = "MazeClient v1.0";
            FormClosing += frm_mazeClient_FormClosing;
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
        private ComboBox cbx_whereExit;
        private Label lbl_whereExit;
        private Panel pnl_graph;
        private Label lbl_connectionError;
    }
}