using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System.Data.SQLite;

namespace Server.Services
{
    public class HandleUserStatsService : UserStatHandler.UserStatHandlerBase
    {
        public override Task<Empty> UserIncrementMaze(UserMazeType request, ServerCallContext context) {
            using (SQLiteConnection conn = new("Data Source= mazeData.db; Version = 3; New = True; Compress = True; ")) {
                conn.Open();
                using SQLiteCommand cmd = conn.CreateCommand();
                switch (request.MazeType) {
                    case "Recursive Backtrack":
                        cmd.CommandText = $"UPDATE UserStats SET RecursiveBacktrackMazesGenerated = RecursiveBacktrackMazesGenerated + 1 WHERE UID = {request.UserID}";
                        cmd.ExecuteNonQuery();
                        break;
                }
            }
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UserUploadTime(UserTime request, ServerCallContext context) {
            List<int> milliseconds = new();
            List<string> displayTimes = new();

            using (SQLiteConnection conn = new("Data Source= mazeData.db; Version = 3; New = True; Compress = True; ")) {
                conn.Open();
                using SQLiteCommand cmd = conn.CreateCommand();

                cmd.CommandText = @$"SELECT Time1Milliseconds, Time2Milliseconds, Time3Milliseconds, Time4Milliseconds, Time5Milliseconds, Time6Milliseconds, Time7Milliseconds, Time8Milliseconds, Time9Milliseconds, Time10Milliseconds
                                    FROM UserStats
                                    WHERE UID = {request.UserID}";
                using SQLiteDataReader readerMilliseconds = cmd.ExecuteReader();
                while (readerMilliseconds.Read()) {
                    for (int i = 0; i < 10; i++) {
                        milliseconds.Add(readerMilliseconds.GetInt32(i));
                    }
                }
                readerMilliseconds.Close();

                cmd.CommandText = @$"SELECT Time1Display, Time2Display, Time3Display, Time4Display, Time5Display, Time6Display, Time7Display, Time8Display, Time9Display, Time10Display
                                    FROM UserStats
                                    WHERE UID = {request.UserID}";
                using SQLiteDataReader readerDisplay = cmd.ExecuteReader();
                while (readerDisplay.Read()) {
                    for (int i = 0; i < 10; i++) {
                        displayTimes.Add(readerDisplay.GetString(i));
                    }
                }
                readerDisplay.Close();

                

                int place = -1;
                for (int i = 0; i < 10; i++) {
                    if (request.TimeMilliseconds < milliseconds[i] || milliseconds[i] == -1) {
                        milliseconds.Insert(i, request.TimeMilliseconds);
                        place = i;
                        if (milliseconds.Count > 10) milliseconds.RemoveAt(milliseconds.Count - 1);
                        break;
                    }
                }

                if (place == -1) { return Task.FromResult(new Empty()); }

                displayTimes.Insert(place, request.Time);
                if (displayTimes.Count > 10) displayTimes.RemoveAt(displayTimes.Count - 1);




                for (int i = 0; i < 10; i++) {
                    cmd.CommandText = $"UPDATE UserStats SET Time{i + 1}Milliseconds = {milliseconds[i]} WHERE UID = {request.UserID}";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = $"UPDATE UserStats SET Time{i + 1}Display = '{displayTimes[i]}' WHERE UID = {request.UserID}";
                    cmd.ExecuteNonQuery();
                }
            }
            return Task.FromResult(new Empty());
        }
    }
}
