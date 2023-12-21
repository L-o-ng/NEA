using Grpc.Net.Client;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;
using Server;
using System.Diagnostics;
using Grpc.Core;

namespace Client
{
    public partial class frm_mazeRegister : Form
    {
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public frm_mazeRegister() {
            InitializeComponent();
        }
        private void frm_mazeRegister_Load(object sender, EventArgs e) {
            Text = $"MazeClient {Globals.g_version}";
            lbl_error.ForeColor = Color.Red;
        }

        private async void btn_register_Click(object sender, EventArgs e) {
            using var channel = GrpcChannel.ForAddress("https://localhost:7178");
            var clientGreet = new Greeter.GreeterClient(channel);
            try {
                var replyGreet = await clientGreet.SayHelloAsync(new HelloRequest { Name = Environment.MachineName },
                    deadline: DateTime.UtcNow.AddSeconds(3));
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded) {
                lbl_error.Text = "Cannot connect to server!";
                ThreadPool.QueueUserWorkItem((state) => {
                    Thread.Sleep(3000);
                    Invoke(() => lbl_error.Text = string.Empty);
                });
                return;
            }

            if (await CheckCrendentials()) {

                var password = HashPasword(txb_password.Text, out var salt);

                var clientRegister = new Registerer.RegistererClient(channel);
                var replyRegister = await clientRegister.RegisterAsync(new Account {
                    Username = txb_username.Text,
                    Password = password,
                    Salt = Convert.ToHexString(salt),
                });

                if (replyRegister.Success) {
                    lbl_error.ForeColor = Color.Green;
                    lbl_error.Text = "Registered!";
                    Task.Delay(1000).Wait();
                    Close();
                }
                else {
                    lbl_error.ForeColor = Color.Red;
                    lbl_error.Text = "Failed to register!";
                    Task.Delay(1000).Wait();
                    lbl_error.Text = string.Empty;
                }
            }
        }


        private async Task<bool> CheckCrendentials() {
            using var channel = GrpcChannel.ForAddress("https://localhost:7178");
            var client = new CheckerIfUserExists.CheckerIfUserExistsClient(channel);
            var reply = await client.CheckUserAsync(new Query { Username = txb_username.Text });

            if (reply.UserExists) {
                lbl_error.Text = "Username already taken!";
                ThreadPool.QueueUserWorkItem((state) => {
                    Thread.Sleep(3000);
                    Invoke(() => lbl_error.Text = string.Empty);
                });
                return false;
            }
            if (txb_password.Text.Length < 7) {
                lbl_error.Text = "Password must be at least\n 7 characters!";
                ThreadPool.QueueUserWorkItem((state) => {
                    Thread.Sleep(3000);
                    Invoke(() => lbl_error.Text = string.Empty);
                });
                return false;
            }
            if (!Regex.IsMatch(txb_password.Text, @"[!-\/:-@[-`{-~]")) {
                lbl_error.Text = "Password must contain at\n least 1 special character!";
                ThreadPool.QueueUserWorkItem((state) => {
                    Thread.Sleep(3000);
                    Invoke(() => lbl_error.Text = string.Empty);
                });
                return false;
            }
            if (txb_password.Text != txb_confirm.Text) {
                lbl_error.Text = "Passwords do not match!";
                ThreadPool.QueueUserWorkItem((state) => {
                    Thread.Sleep(3000);
                    Invoke(() => lbl_error.Text = string.Empty);
                });
                return false;
            }

            return true;
        }

        // SOURCE: https://code-maze.com/csharp-hashing-salting-passwords-best-practices/
        string HashPasword(string password, out byte[] salt) {
            salt = RandomNumberGenerator.GetBytes(Globals.g_keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                Globals.g_iterations,
                hashAlgorithm,
                Globals.g_keySize);
            return Convert.ToHexString(hash);
        }
    }
}

