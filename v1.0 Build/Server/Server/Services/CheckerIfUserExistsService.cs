using Grpc.Core;
using System.Data.SQLite;

namespace Server.Services
{
    public class CheckerIfUserExistsService : CheckerIfUserExists.CheckerIfUserExistsBase
    {
        public override Task<Exists> CheckUser(Query request, ServerCallContext context) {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=mazeData.db; Version=3; New=True; Compress=True; ")) {
                conn.Open();

                using (SQLiteCommand cmd = conn.CreateCommand()) {
                    cmd.CommandText = "SELECT COUNT(*) FROM Login WHERE Username = @username";
                    cmd.Parameters.AddWithValue("@username", request.Username);

                    int rowCount = Convert.ToInt32(cmd.ExecuteScalar());

                    if (rowCount > 0) {
                        return Task.FromResult(new Exists { UserExists = true });
                    }
                    else {
                        return Task.FromResult(new Exists { UserExists = false });
                    }
                }
            }
        }
    }
}
