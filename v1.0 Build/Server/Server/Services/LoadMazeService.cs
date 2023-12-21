using Grpc.Core;
using System.Data.SQLite;

namespace Server.Services
{
    public class LoadMazeService : LoaderMazes.LoaderMazesBase
    {
        public override Task<MazeToLoad> LoadMaze(LoadRequest request, ServerCallContext context) {
            string maze;
            string mazeGenAlg;

            using (SQLiteConnection conn = new("Data Source= mazeData.db; Version = 3; New = True; Compress = True; ")) {
                conn.Open();

                using SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT MazeObject, MazeGenAlg FROM Mazes WHERE @MazeID = MazeID AND @UserID = UID";
                cmd.Parameters.AddWithValue("@MazeID", request.MazeID);
                cmd.Parameters.AddWithValue("@UserID", request.UserID);

                using SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) {
                    maze = reader.GetString(0);
                    mazeGenAlg = reader.GetString(1);
                }
                else {
                    maze = string.Empty; 
                    mazeGenAlg = string.Empty;
                }
            }

            return Task.FromResult(new MazeToLoad { Maze = maze, MazeGenAlg = mazeGenAlg });
        }
    }
}
