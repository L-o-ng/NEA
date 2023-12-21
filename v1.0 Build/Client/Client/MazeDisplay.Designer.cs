namespace Client
{
    partial class frm_mazeDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_mazeDisplay));
            pnl_mazeContainer = new Panel();
            tlp_MazeDisplay = new TableLayoutPanel();
            btn_requestSolve = new Button();
            btn_left = new Button();
            btn_right = new Button();
            btn_up = new Button();
            btn_down = new Button();
            lbl_notice = new Label();
            cbx_solveType = new ComboBox();
            btn_close = new Button();
            lbl_solved = new Label();
            lbl_timer = new Label();
            btn_serverSave = new Button();
            btn_localSave = new Button();
            lbl_error = new Label();
            txb_mazeName = new TextBox();
            lbl_mazeName = new Label();
            pnl_mazeContainer.SuspendLayout();
            SuspendLayout();
            // 
            // pnl_mazeContainer
            // 
            pnl_mazeContainer.BorderStyle = BorderStyle.Fixed3D;
            pnl_mazeContainer.Controls.Add(tlp_MazeDisplay);
            pnl_mazeContainer.Location = new Point(8, 99);
            pnl_mazeContainer.Margin = new Padding(0);
            pnl_mazeContainer.Name = "pnl_mazeContainer";
            pnl_mazeContainer.Size = new Size(685, 233);
            pnl_mazeContainer.TabIndex = 0;
            // 
            // tlp_MazeDisplay
            // 
            tlp_MazeDisplay.ColumnCount = 2;
            tlp_MazeDisplay.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_MazeDisplay.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_MazeDisplay.Dock = DockStyle.Fill;
            tlp_MazeDisplay.Location = new Point(0, 0);
            tlp_MazeDisplay.Margin = new Padding(0);
            tlp_MazeDisplay.Name = "tlp_MazeDisplay";
            tlp_MazeDisplay.RowCount = 2;
            tlp_MazeDisplay.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_MazeDisplay.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_MazeDisplay.Size = new Size(681, 229);
            tlp_MazeDisplay.TabIndex = 0;
            tlp_MazeDisplay.CellPaint += tlp_MazeDisplay_CellPaint;
            // 
            // btn_requestSolve
            // 
            btn_requestSolve.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_requestSolve.Location = new Point(8, 12);
            btn_requestSolve.Name = "btn_requestSolve";
            btn_requestSolve.Size = new Size(97, 23);
            btn_requestSolve.TabIndex = 1;
            btn_requestSolve.TabStop = false;
            btn_requestSolve.Text = "Request Solve";
            btn_requestSolve.UseVisualStyleBackColor = true;
            btn_requestSolve.Click += btn_requestSolve_Click;
            btn_requestSolve.KeyDown += btn_requestSolve_KeyDown;
            // 
            // btn_left
            // 
            btn_left.Location = new Point(110, 12);
            btn_left.Name = "btn_left";
            btn_left.Size = new Size(23, 23);
            btn_left.TabIndex = 2;
            btn_left.Text = "←";
            btn_left.UseVisualStyleBackColor = true;
            btn_left.Click += btn_left_Click;
            btn_left.KeyDown += btn_left_KeyDown;
            // 
            // btn_right
            // 
            btn_right.Location = new Point(140, 12);
            btn_right.Name = "btn_right";
            btn_right.Size = new Size(23, 23);
            btn_right.TabIndex = 3;
            btn_right.Text = "→";
            btn_right.UseVisualStyleBackColor = true;
            btn_right.Click += btn_right_Click;
            btn_right.KeyDown += btn_right_KeyDown;
            // 
            // btn_up
            // 
            btn_up.Location = new Point(169, 12);
            btn_up.Name = "btn_up";
            btn_up.Size = new Size(23, 23);
            btn_up.TabIndex = 4;
            btn_up.Text = "↑";
            btn_up.UseVisualStyleBackColor = true;
            btn_up.Click += btn_up_Click;
            btn_up.KeyDown += btn_up_KeyDown;
            // 
            // btn_down
            // 
            btn_down.Location = new Point(198, 12);
            btn_down.Name = "btn_down";
            btn_down.Size = new Size(23, 23);
            btn_down.TabIndex = 5;
            btn_down.Text = "↓";
            btn_down.UseVisualStyleBackColor = true;
            btn_down.Click += btn_down_Click;
            btn_down.KeyDown += btn_down_KeyDown;
            // 
            // lbl_notice
            // 
            lbl_notice.AutoSize = true;
            lbl_notice.Location = new Point(110, 38);
            lbl_notice.Name = "lbl_notice";
            lbl_notice.Size = new Size(118, 15);
            lbl_notice.TabIndex = 6;
            lbl_notice.Text = "Or keyboard controls";
            // 
            // cbx_solveType
            // 
            cbx_solveType.FormattingEnabled = true;
            cbx_solveType.Items.AddRange(new object[] { "Depth First" });
            cbx_solveType.Location = new Point(8, 41);
            cbx_solveType.Name = "cbx_solveType";
            cbx_solveType.Size = new Size(97, 23);
            cbx_solveType.TabIndex = 7;
            cbx_solveType.TabStop = false;
            cbx_solveType.SelectedIndexChanged += cbx_solveType_SelectedIndexChanged;
            cbx_solveType.KeyDown += cbx_solveType_KeyDown;
            // 
            // btn_close
            // 
            btn_close.Enabled = false;
            btn_close.Location = new Point(227, 12);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(75, 23);
            btn_close.TabIndex = 8;
            btn_close.Text = "Close";
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            // 
            // lbl_solved
            // 
            lbl_solved.AutoSize = true;
            lbl_solved.Location = new Point(243, 38);
            lbl_solved.Name = "lbl_solved";
            lbl_solved.Size = new Size(0, 15);
            lbl_solved.TabIndex = 9;
            // 
            // lbl_timer
            // 
            lbl_timer.AutoSize = true;
            lbl_timer.Location = new Point(111, 53);
            lbl_timer.Name = "lbl_timer";
            lbl_timer.Size = new Size(0, 15);
            lbl_timer.TabIndex = 10;
            // 
            // btn_serverSave
            // 
            btn_serverSave.Location = new Point(308, 12);
            btn_serverSave.Name = "btn_serverSave";
            btn_serverSave.Size = new Size(75, 23);
            btn_serverSave.TabIndex = 11;
            btn_serverSave.TabStop = false;
            btn_serverSave.Text = "Server Save";
            btn_serverSave.UseVisualStyleBackColor = true;
            btn_serverSave.Click += btn_serverSave_Click;
            btn_serverSave.KeyDown += btn_serverSave_KeyDown;
            // 
            // btn_localSave
            // 
            btn_localSave.Location = new Point(308, 41);
            btn_localSave.Name = "btn_localSave";
            btn_localSave.Size = new Size(75, 23);
            btn_localSave.TabIndex = 12;
            btn_localSave.TabStop = false;
            btn_localSave.Text = "Local Save";
            btn_localSave.UseVisualStyleBackColor = true;
            btn_localSave.Click += btn_localSave_Click;
            btn_localSave.KeyDown += btn_localSave_KeyDown;
            // 
            // lbl_error
            // 
            lbl_error.AutoSize = true;
            lbl_error.Location = new Point(227, 38);
            lbl_error.Name = "lbl_error";
            lbl_error.Size = new Size(0, 15);
            lbl_error.TabIndex = 13;
            // 
            // txb_mazeName
            // 
            txb_mazeName.Location = new Point(389, 13);
            txb_mazeName.MaxLength = 10;
            txb_mazeName.Name = "txb_mazeName";
            txb_mazeName.Size = new Size(100, 23);
            txb_mazeName.TabIndex = 14;
            txb_mazeName.TabStop = false;
            // 
            // lbl_mazeName
            // 
            lbl_mazeName.AutoSize = true;
            lbl_mazeName.Location = new Point(396, 44);
            lbl_mazeName.Name = "lbl_mazeName";
            lbl_mazeName.Size = new Size(86, 15);
            lbl_mazeName.TabIndex = 15;
            lbl_mazeName.Text = "^Maze Name^";
            // 
            // frm_mazeDisplay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(lbl_mazeName);
            Controls.Add(txb_mazeName);
            Controls.Add(lbl_error);
            Controls.Add(btn_localSave);
            Controls.Add(btn_serverSave);
            Controls.Add(lbl_timer);
            Controls.Add(lbl_solved);
            Controls.Add(btn_close);
            Controls.Add(cbx_solveType);
            Controls.Add(lbl_notice);
            Controls.Add(btn_down);
            Controls.Add(btn_up);
            Controls.Add(btn_right);
            Controls.Add(btn_left);
            Controls.Add(btn_requestSolve);
            Controls.Add(pnl_mazeContainer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "frm_mazeDisplay";
            Text = "MazeClient v1.0";
            Load += frm_mazeDisplay_Load;
            KeyDown += frm_mazeDisplay_KeyDown;
            pnl_mazeContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnl_mazeContainer;
        private TableLayoutPanel tlp_MazeDisplay;
        private Button btn_requestSolve;
        private Button btn_left;
        private Button btn_right;
        private Button btn_up;
        private Button btn_down;
        private Label lbl_notice;
        private ComboBox cbx_solveType;
        private Button btn_close;
        private Label lbl_solved;
        private Label lbl_timer;
        private Button btn_serverSave;
        private Button btn_localSave;
        private Label lbl_error;
        private TextBox txb_mazeName;
        private Label lbl_mazeName;
    }
}