using Grpc.Core;
using Newtonsoft.Json;
using System.Data.SQLite;

namespace Server.Services
{
    public class GetMazesService : GetterMazes.GetterMazesBase
    {
        public override Task<MazesList> GetMazes(Request request, ServerCallContext context) {
            List<(int mazeID, string mazeName)> mazes = new();

            using (SQLiteConnection conn = new(
                "Data Source= mazeData.db; " +
                "Version = 3; " +
                "New = True; " +
                "Compress = True; ")) {
                conn.Open();

                using SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT MazeID, MazeName FROM Mazes WHERE @UID = UID";
                cmd.Parameters.AddWithValue("@UID", request.UserID);
                using SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    mazes.Add((reader.GetInt32(0), reader.GetString(1)));
                }
            }

            return Task.FromResult(new MazesList { 
                Mazes = JsonConvert.SerializeObject(mazes) 
            });
        }
    }
}
