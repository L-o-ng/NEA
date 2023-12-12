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
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
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
            pnl_mazeContainer.Location = new Point(8, 44);
            pnl_mazeContainer.Margin = new Padding(0);
            pnl_mazeContainer.Name = "pnl_mazeContainer";
            pnl_mazeContainer.Size = new Size(685, 288);
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
            tlp_MazeDisplay.Size = new Size(681, 284);
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
            // 
            // btn_left
            // 
            btn_left.Location = new Point(110, 12);
            btn_left.Name = "btn_left";
            btn_left.Size = new Size(23, 23);
            btn_left.TabIndex = 2;
            btn_left.TabStop = false;
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
            btn_right.TabStop = false;
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
            btn_up.TabStop = false;
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
            btn_down.TabStop = false;
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
            // frm_mazeDisplay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
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