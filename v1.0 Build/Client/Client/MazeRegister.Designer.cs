namespace Client
{
    partial class frm_mazeRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_mazeRegister));
            lbl_register = new Label();
            lbl_username = new Label();
            lbl_password = new Label();
            lbl_confirm = new Label();
            btn_register = new Button();
            lbl_error = new Label();
            txb_username = new TextBox();
            txb_password = new TextBox();
            txb_confirm = new TextBox();
            SuspendLayout();
            // 
            // lbl_register
            // 
            lbl_register.AutoSize = true;
            lbl_register.Font = new Font("Calibri", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_register.Location = new Point(52, 9);
            lbl_register.Name = "lbl_register";
            lbl_register.Size = new Size(108, 33);
            lbl_register.TabIndex = 0;
            lbl_register.Text = "Register";
            // 
            // lbl_username
            // 
            lbl_username.AutoSize = true;
            lbl_username.Location = new Point(12, 70);
            lbl_username.Name = "lbl_username";
            lbl_username.Size = new Size(60, 15);
            lbl_username.TabIndex = 1;
            lbl_username.Text = "Username";
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.Location = new Point(12, 108);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(57, 15);
            lbl_password.TabIndex = 2;
            lbl_password.Text = "Password";
            // 
            // lbl_confirm
            // 
            lbl_confirm.AutoSize = true;
            lbl_confirm.Location = new Point(12, 147);
            lbl_confirm.Name = "lbl_confirm";
            lbl_confirm.Size = new Size(77, 15);
            lbl_confirm.TabIndex = 3;
            lbl_confirm.Text = "Confirm Pass";
            // 
            // btn_register
            // 
            btn_register.Location = new Point(12, 184);
            btn_register.Name = "btn_register";
            btn_register.Size = new Size(75, 23);
            btn_register.TabIndex = 4;
            btn_register.Text = "Register";
            btn_register.UseVisualStyleBackColor = true;
            btn_register.Click += btn_register_Click;
            // 
            // lbl_error
            // 
            lbl_error.AutoSize = true;
            lbl_error.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_error.Location = new Point(93, 188);
            lbl_error.Name = "lbl_error";
            lbl_error.Size = new Size(0, 12);
            lbl_error.TabIndex = 5;
            // 
            // txb_username
            // 
            txb_username.Location = new Point(104, 67);
            txb_username.Name = "txb_username";
            txb_username.Size = new Size(100, 23);
            txb_username.TabIndex = 6;
            // 
            // txb_password
            // 
            txb_password.Location = new Point(104, 105);
            txb_password.Name = "txb_password";
            txb_password.PasswordChar = '•';
            txb_password.Size = new Size(100, 23);
            txb_password.TabIndex = 7;
            txb_password.UseSystemPasswordChar = true;
            // 
            // txb_confirm
            // 
            txb_confirm.Location = new Point(104, 144);
            txb_confirm.Name = "txb_confirm";
            txb_confirm.PasswordChar = '•';
            txb_confirm.Size = new Size(100, 23);
            txb_confirm.TabIndex = 8;
            txb_confirm.UseSystemPasswordChar = true;
            // 
            // frm_mazeRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(216, 224);
            Controls.Add(txb_confirm);
            Controls.Add(txb_password);
            Controls.Add(txb_username);
            Controls.Add(lbl_error);
            Controls.Add(btn_register);
            Controls.Add(lbl_confirm);
            Controls.Add(lbl_password);
            Controls.Add(lbl_username);
            Controls.Add(lbl_register);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frm_mazeRegister";
            Text = "MazeClient v1.0";
            Load += frm_mazeRegister_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_register;
        private Label lbl_username;
        private Label lbl_password;
        private Label lbl_confirm;
        private Button btn_register;
        private Label lbl_error;
        private TextBox txb_username;
        private TextBox txb_password;
        private TextBox txb_confirm;
    }
}