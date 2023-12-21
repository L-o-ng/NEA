using Grpc.Core;
using System.Data.SQLite;

namespace Server.Services
{
    public class SaveMazeService : Saver.SaverBase
    {
        public override Task<SuccessAck> SaveMaze(SaveRequest request, ServerCallContext context) {
            try {
                using (SQLiteConnection conn = new("Data Source= mazeData.db; Version = 3; New = True; Compress = True; ")) {
                    conn.Open();
                    using SQLiteCommand cmd = conn.CreateCommand();

                    cmd.CommandText = "INSERT INTO Mazes(MazeObject, MazeGenAlg, MazeName, UID) VALUES(@MazeObject, @MazeGenAlg, @MazeName, @UID)";
                    cmd.Parameters.AddWithValue("@MazeObject", request.MazeJson);
                    cmd.Parameters.AddWithValue("@MazeGenAlg", request.MazeType);
                    cmd.Parameters.AddWithValue("@MazeName", request.MazeName);
                    cmd.Parameters.AddWithValue("@UID", request.UserID);
                    cmd.ExecuteNonQuery();
                }

                return Task.FromResult(new SuccessAck { Success = true });
                
            }
            catch (Exception) {
                return Task.FromResult(new SuccessAck { Success = false });
            }
        }
    }
}
