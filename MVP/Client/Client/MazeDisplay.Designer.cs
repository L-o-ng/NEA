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
            pnl_mazeContainer.SuspendLayout();
            SuspendLayout();
            // 
            // pnl_mazeContainer
            // 
            pnl_mazeContainer.BorderStyle = BorderStyle.Fixed3D;
            pnl_mazeContainer.Controls.Add(tlp_MazeDisplay);
            pnl_mazeContainer.Location = new Point(9, 59);
            pnl_mazeContainer.Margin = new Padding(0);
            pnl_mazeContainer.Name = "pnl_mazeContainer";
            pnl_mazeContainer.Size = new Size(782, 383);
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
            tlp_MazeDisplay.Size = new Size(778, 379);
            tlp_MazeDisplay.TabIndex = 0;
            tlp_MazeDisplay.CellPaint += tlp_MazeDisplay_CellPaint;
            // 
            // btn_requestSolve
            // 
            btn_requestSolve.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_requestSolve.Location = new Point(9, 16);
            btn_requestSolve.Margin = new Padding(3, 4, 3, 4);
            btn_requestSolve.Name = "btn_requestSolve";
            btn_requestSolve.Size = new Size(111, 31);
            btn_requestSolve.TabIndex = 1;
            btn_requestSolve.TabStop = false;
            btn_requestSolve.Text = "Request Solve";
            btn_requestSolve.UseVisualStyleBackColor = true;
            // 
            // btn_left
            // 
            btn_left.Location = new Point(126, 16);
            btn_left.Margin = new Padding(3, 4, 3, 4);
            btn_left.Name = "btn_left";
            btn_left.Size = new Size(26, 31);
            btn_left.TabIndex = 2;
            btn_left.TabStop = false;
            btn_left.Text = "←";
            btn_left.UseVisualStyleBackColor = true;
            btn_left.Click += btn_left_Click;
            // 
            // btn_right
            // 
            btn_right.Location = new Point(160, 16);
            btn_right.Margin = new Padding(3, 4, 3, 4);
            btn_right.Name = "btn_right";
            btn_right.Size = new Size(26, 31);
            btn_right.TabIndex = 3;
            btn_right.TabStop = false;
            btn_right.Text = "→";
            btn_right.UseVisualStyleBackColor = true;
            btn_right.Click += btn_right_Click;
            // 
            // btn_up
            // 
            btn_up.Location = new Point(193, 16);
            btn_up.Margin = new Padding(3, 4, 3, 4);
            btn_up.Name = "btn_up";
            btn_up.Size = new Size(26, 31);
            btn_up.TabIndex = 4;
            btn_up.TabStop = false;
            btn_up.Text = "↑";
            btn_up.UseVisualStyleBackColor = true;
            btn_up.Click += btn_up_Click;
            // 
            // btn_down
            // 
            btn_down.Location = new Point(226, 16);
            btn_down.Margin = new Padding(3, 4, 3, 4);
            btn_down.Name = "btn_down";
            btn_down.Size = new Size(26, 31);
            btn_down.TabIndex = 5;
            btn_down.TabStop = false;
            btn_down.Text = "↓";
            btn_down.UseVisualStyleBackColor = true;
            btn_down.Click += btn_down_Click;
            // 
            // lbl_notice
            // 
            lbl_notice.AutoSize = true;
            lbl_notice.Location = new Point(126, 51);
            lbl_notice.Name = "lbl_notice";
            lbl_notice.Size = new Size(148, 20);
            lbl_notice.TabIndex = 6;
            lbl_notice.Text = "Or keyboard controls";
            // 
            // frm_mazeDisplay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(lbl_notice);
            Controls.Add(btn_down);
            Controls.Add(btn_up);
            Controls.Add(btn_right);
            Controls.Add(btn_left);
            Controls.Add(btn_requestSolve);
            Controls.Add(pnl_mazeContainer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
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
    }
}