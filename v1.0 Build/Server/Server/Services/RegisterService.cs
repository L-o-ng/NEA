using Grpc.Core;
using System.Data.SQLite;


namespace Server.Services
{
    public class RegisterService : Registerer.RegistererBase
    {
        public override Task<Acknowledgement> Register(Account request, ServerCallContext context) {
            try {
                using (SQLiteConnection conn = new("Data Source= mazeData.db; Version = 3; New = True; Compress = True; ")) {
                    conn.Open();

                    using SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO Login(Username, Password, Salt) VALUES(@Username, @Password, @Salt)";
                    cmd.Parameters.AddWithValue("@Username", request.Username);
                    cmd.Parameters.AddWithValue("@Password", request.Password);
                    cmd.Parameters.AddWithValue("@Salt", request.Salt);

                    cmd.ExecuteNonQuery();
                }

                return Task.FromResult(new Acknowledgement { Success = true });
            }
            catch (Exception) {
                return Task.FromResult(new Acknowledgement { Success = false });
            }
        }
    }
}

// test code: retrieves all usernames and password hashes

//cmd.CommandText = "SELECT * FROM Login";
//SQLiteDataReader sqliteDataReader = cmd.ExecuteReader();

//while (sqliteDataReader.Read()) {
//    string myReader = $"{sqliteDataReader.GetString(0)}, {sqliteDataReader.GetString(1)}";
//    Console.WriteLine(myReader);
//}
//sqliteDataReader.Close();
