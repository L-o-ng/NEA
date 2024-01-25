using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System.Data.SQLite;

namespace Server.Services
{
    public class GlobalStatHandlerService : GlobalStatHandler.GlobalStatHandlerBase
    {
        public override Task<Empty> IncrementMaze(MazeType request, ServerCallContext context) {
            using (SQLiteConnection conn = new("" +
                "Data Source= mazeData.db; " +
                "Version = 3; " +
                "New = True; " +
                "Compress = True; ")) {
                conn.Open();
                using SQLiteCommand cmd = conn.CreateCommand();
                switch (request.MazeType_) {
                    case "Recursive Backtrack":
                        cmd.CommandText = @"UPDATE GlobalStats 
                                            SET RecursiveBacktrackMazesGenerated = RecursiveBacktrackMazesGenerated + 1";
                        cmd.ExecuteNonQuery();
                        break;
                    case "Wilson's":
                        cmd.CommandText = @"UPDATE GlobalStats 
                                            SET WilsonsMazesGenerated = WilsonsMazesGenerated + 1";
                        cmd.ExecuteNonQuery();
                        break;
                    case "Growing Tree":
                        cmd.CommandText = @"UPDATE GlobalStats 
                                            SET GrowingTreeMazesGenerated = GrowingTreeMazesGenerated + 1";
                        cmd.ExecuteNonQuery();
                        break;
                }
            }
            return Task.FromResult(new Empty());
            
        }

        public override Task<Empty> UploadTime(Time request, ServerCallContext context) {
            List<int> milliseconds = new();
            List<string> displayTimes = new();
            List<string> usernames = new();

            using (SQLiteConnection conn = new(
                "Data Source= mazeData.db; " +
                "Version = 3; " +
                "New = True; " +
                "Compress = True; ")) {
                conn.Open();
                using SQLiteCommand cmd = conn.CreateCommand();

                cmd.CommandText = @"SELECT Time1Milliseconds, 
                                           Time2Milliseconds, 
                                           Time3Milliseconds, 
                                           Time4Milliseconds, 
                                           Time5Milliseconds, 
                                           Time6Milliseconds, 
                                           Time7Milliseconds, 
                                           Time8Milliseconds, 
                                           Time9Milliseconds, 
                                           Time10Milliseconds
                                    FROM GlobalStats";
                using SQLiteDataReader readerMilliseconds = cmd.ExecuteReader();
                while (readerMilliseconds.Read()) {
                    for (int i = 0; i < 10; i++) {
                        milliseconds.Add(readerMilliseconds.GetInt32(i));
                    }
                }
                readerMilliseconds.Close();

                cmd.CommandText = @"SELECT Time1Display, 
                                           Time2Display, 
                                           Time3Display, 
                                           Time4Display, 
                                           Time5Display, 
                                           Time6Display, 
                                           Time7Display, 
                                           Time8Display, 
                                           Time9Display,
                                           Time10Display
                                    FROM GlobalStats";
                using SQLiteDataReader readerDisplay = cmd.ExecuteReader();
                while (readerDisplay.Read()) {
                    for (int i = 0; i < 10; i++) {
                        displayTimes.Add(readerDisplay.GetString(i));
                    }
                }
                readerDisplay.Close();

                cmd.CommandText = @"SELECT Time1Name, 
                                           Time2Name, 
                                           Time3Name, 
                                           Time4Name, 
                                           Time5Name, 
                                           Time6Name, 
                                           Time7Name, 
                                           Time8Name, 
                                           Time9Name, 
                                           Time10Name
                                    FROM GlobalStats";
                using SQLiteDataReader readerUsername = cmd.ExecuteReader();
                while (readerUsername.Read()) {
                    for (int i = 0; i < 10; i++) {
                        usernames.Add(readerUsername.GetString(i));
                    }
                }
                readerUsername.Close();

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

                displayTimes.Insert(place, request.Time_);
                if (displayTimes.Count > 10) displayTimes.RemoveAt(displayTimes.Count - 1);

                usernames.Insert(place, request.Username);
                if (usernames.Count > 10) usernames.RemoveAt(usernames.Count - 1);
                
                    
                
                for (int i = 0; i < 10; i++) {
                    cmd.CommandText = $@"UPDATE GlobalStats 
                                         SET Time{i + 1}Milliseconds = {milliseconds[i]}";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = $@"UPDATE GlobalStats 
                                         SET Time{i + 1}Display = '{displayTimes[i]}'";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = $@"UPDATE GlobalStats 
                                         SET Time{i + 1}Name = '{usernames[i]}'";
                    cmd.ExecuteNonQuery();
                }
            }
            return Task.FromResult(new Empty());
        }
    }
}
