namespace Client
{
    partial class frm_mazeLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_mazeLogin));
            lbl_login = new Label();
            lbl_username = new Label();
            lbl_password = new Label();
            txb_username = new TextBox();
            txb_password = new TextBox();
            llb_register = new LinkLabel();
            btn_login = new Button();
            lbl_error = new Label();
            SuspendLayout();
            // 
            // lbl_login
            // 
            lbl_login.AutoSize = true;
            lbl_login.Font = new Font("Calibri", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_login.Location = new Point(12, 9);
            lbl_login.Name = "lbl_login";
            lbl_login.Size = new Size(218, 33);
            lbl_login.TabIndex = 0;
            lbl_login.Text = "Welcome to Maze";
            // 
            // lbl_username
            // 
            lbl_username.AutoSize = true;
            lbl_username.Location = new Point(12, 64);
            lbl_username.Name = "lbl_username";
            lbl_username.Size = new Size(60, 15);
            lbl_username.TabIndex = 1;
            lbl_username.Text = "Username";
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.Location = new Point(12, 103);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(57, 15);
            lbl_password.TabIndex = 2;
            lbl_password.Text = "Password";
            // 
            // txb_username
            // 
            txb_username.Location = new Point(105, 61);
            txb_username.Name = "txb_username";
            txb_username.Size = new Size(100, 23);
            txb_username.TabIndex = 3;
            // 
            // txb_password
            // 
            txb_password.Location = new Point(105, 100);
            txb_password.Name = "txb_password";
            txb_password.PasswordChar = '•';
            txb_password.Size = new Size(100, 23);
            txb_password.TabIndex = 4;
            txb_password.UseSystemPasswordChar = true;
            // 
            // llb_register
            // 
            llb_register.AutoSize = true;
            llb_register.LinkColor = Color.Blue;
            llb_register.Location = new Point(23, 157);
            llb_register.Name = "llb_register";
            llb_register.Size = new Size(49, 15);
            llb_register.TabIndex = 5;
            llb_register.TabStop = true;
            llb_register.Text = "Register";
            llb_register.VisitedLinkColor = Color.Blue;
            llb_register.LinkClicked += llb_register_LinkClicked;
            // 
            // btn_login
            // 
            btn_login.Location = new Point(12, 131);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(75, 23);
            btn_login.TabIndex = 6;
            btn_login.Text = "Login";
            btn_login.UseVisualStyleBackColor = true;
            btn_login.Click += btn_login_Click;
            // 
            // lbl_error
            // 
            lbl_error.AutoSize = true;
            lbl_error.Location = new Point(105, 135);
            lbl_error.Name = "lbl_error";
            lbl_error.Size = new Size(0, 15);
            lbl_error.TabIndex = 7;
            // 
            // frm_mazeLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(241, 181);
            Controls.Add(lbl_error);
            Controls.Add(btn_login);
            Controls.Add(llb_register);
            Controls.Add(txb_password);
            Controls.Add(txb_username);
            Controls.Add(lbl_password);
            Controls.Add(lbl_username);
            Controls.Add(lbl_login);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frm_mazeLogin";
            Text = "MazeClient v1.0";
            Load += frm_mazeLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_login;
        private Label lbl_username;
        private Label lbl_password;
        private TextBox txb_username;
        private TextBox txb_password;
        private LinkLabel llb_register;
        private Button btn_login;
        private Label lbl_error;
    }
}