using Grpc.Core;
using System.Data.SQLite;

namespace Server.Services
{
    public class DeleteMazeService : DeleterMazes.DeleterMazesBase
    {
        public override Task<SuccessAcknowledge> DeleteMaze(DeleteRequest request, ServerCallContext context) {
            try {
                using (SQLiteConnection conn = new("Data Source= mazeData.db; Version = 3; New = True; Compress = True; ")) {
                    conn.Open();
                    using SQLiteCommand cmd = conn.CreateCommand();

                    cmd.CommandText = "DELETE FROM Mazes WHERE @MazeID = MazeID AND @UserID = UID";
                    cmd.Parameters.AddWithValue("@MazeID", request.MazeID);
                    cmd.Parameters.AddWithValue("@UserID", request.UserID);
                    cmd.ExecuteNonQuery();
                }

                return Task.FromResult(new SuccessAcknowledge { Success = true });

            }
            catch (Exception) {
                return Task.FromResult(new SuccessAcknowledge { Success = false });
            }
        }
    }
}
