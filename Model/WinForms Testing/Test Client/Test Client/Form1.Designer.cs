namespace Test_Client
{
    partial class frm_ClientPingTest
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_PingServer = new Button();
            lbl_PingServer = new Label();
            SuspendLayout();
            // 
            // btn_PingServer
            // 
            btn_PingServer.Location = new Point(12, 13);
            btn_PingServer.Name = "btn_PingServer";
            btn_PingServer.Size = new Size(75, 23);
            btn_PingServer.TabIndex = 0;
            btn_PingServer.Text = "Ping Server";
            btn_PingServer.UseVisualStyleBackColor = true;
            btn_PingServer.Click += button1_Click;
            // 
            // lbl_PingServer
            // 
            lbl_PingServer.AutoSize = true;
            lbl_PingServer.Location = new Point(138, 13);
            lbl_PingServer.Name = "lbl_PingServer";
            lbl_PingServer.Size = new Size(0, 15);
            lbl_PingServer.TabIndex = 1;
            // 
            // frm_ClientPingTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(347, 48);
            Controls.Add(lbl_PingServer);
            Controls.Add(btn_PingServer);
            Name = "frm_ClientPingTest";
            Text = "Client Ping Test";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_PingServer;
        private Label lbl_PingServer;
    }
}