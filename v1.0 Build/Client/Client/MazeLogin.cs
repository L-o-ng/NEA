using Grpc.Core;
using Grpc.Net.Client;
using Server;

namespace Client
{
    public partial class frm_mazeLogin : Form
    {
        public frm_mazeLogin() {
            InitializeComponent();
        }

        private void frm_mazeLogin_Load(object sender, EventArgs e) {
            Text = $"MazeClient {Globals.g_version}";
            lbl_error.ForeColor = Color.Red;
        }

        private void llb_register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Form register = new frm_mazeRegister();
            register.ShowDialog();
        }

        private async void btn_login_Click(object sender, EventArgs e) {
            using var channel = GrpcChannel.ForAddress("https://localhost:7178");

            var clientGreet = new Greeter.GreeterClient(channel);
            try {
                var replyGreet = await clientGreet.SayHelloAsync(new HelloRequest { Name = Environment.MachineName },
                    deadline: DateTime.UtcNow.AddSeconds(3));
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded) {
                lbl_error.Text = "Cannot connect to\nserver!";
                ThreadPool.QueueUserWorkItem((state) => {
                    Thread.Sleep(3000);
                    Invoke(() => lbl_error.Text = string.Empty);
                });
                return;
            }

            var clientLogin = new LoginHandler.LoginHandlerClient(channel);
            var replyLogin = await clientLogin.LoginAsync(new Credentials {
                Username = txb_username.Text,
                Password = txb_password.Text
            });

            if (replyLogin.LoggedIn) {
                Globals.g_userID = replyLogin.UserID;
                Globals.g_username = txb_username.Text;
                Form mazeParams = new frm_mazeParams();
                Hide();
                mazeParams.Closed += (s, args) => Close();
                mazeParams.Show();
            }
            else {
                lbl_error.Text = "Username or Password\nincorrect!";
                ThreadPool.QueueUserWorkItem((state) => {
                    Thread.Sleep(3000);
                    Invoke(() => lbl_error.Text = string.Empty);
                });
            }
        }
    }
}
