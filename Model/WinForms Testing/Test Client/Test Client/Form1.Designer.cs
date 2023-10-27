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
            txt_num1 = new TextBox();
            txt_num2 = new TextBox();
            btn_add = new Button();
            lbl_sum = new Label();
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
            // txt_num1
            // 
            txt_num1.Location = new Point(12, 60);
            txt_num1.Name = "txt_num1";
            txt_num1.Size = new Size(87, 23);
            txt_num1.TabIndex = 2;
            txt_num1.Text = "Enter a number";
            // 
            // txt_num2
            // 
            txt_num2.Location = new Point(105, 60);
            txt_num2.Name = "txt_num2";
            txt_num2.Size = new Size(87, 23);
            txt_num2.TabIndex = 3;
            txt_num2.Text = "Enter a number";
            // 
            // btn_add
            // 
            btn_add.Location = new Point(198, 59);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(41, 23);
            btn_add.TabIndex = 4;
            btn_add.Text = "Add";
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_add_Click;
            // 
            // lbl_sum
            // 
            lbl_sum.AutoSize = true;
            lbl_sum.Location = new Point(261, 63);
            lbl_sum.Name = "lbl_sum";
            lbl_sum.Size = new Size(0, 15);
            lbl_sum.TabIndex = 5;
            // 
            // frm_ClientPingTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(347, 104);
            Controls.Add(lbl_sum);
            Controls.Add(btn_add);
            Controls.Add(txt_num2);
            Controls.Add(txt_num1);
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
        private TextBox txt_num1;
        private TextBox txt_num2;
        private Button btn_add;
        private Label lbl_sum;
    }
}