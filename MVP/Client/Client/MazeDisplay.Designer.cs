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
            pnl_mazeContainer.SuspendLayout();
            SuspendLayout();
            // 
            // pnl_mazeContainer
            // 
            pnl_mazeContainer.BorderStyle = BorderStyle.Fixed3D;
            pnl_mazeContainer.Controls.Add(tlp_MazeDisplay);
            pnl_mazeContainer.Location = new Point(9, 58);
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
            // frm_mazeDisplay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnl_mazeContainer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frm_mazeDisplay";
            Text = "MazeClient v1.0";
            Load += frm_mazeDisplay_Load;
            pnl_mazeContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnl_mazeContainer;
        private TableLayoutPanel tlp_MazeDisplay;
    }
}