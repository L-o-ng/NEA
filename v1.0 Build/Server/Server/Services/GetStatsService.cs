using Grpc.Core;
using System.Data.SQLite;

namespace Server.Services
{
    public class GetStatsService : StatsGetter.StatsGetterBase
    {
        public override Task<GlobalMazesGenerated> GetGlobalMazesGenerated(GetGlobalMazesGeneratedRequest request, ServerCallContext context) {
            int recursiveBacktrackMazesGenerated = 0;
            int growingTreeMazesGenerated = 0;
            int wilsonsMazesGenerated = 0;

            using SQLiteConnection conn = new SQLiteConnection(
                "Data Source=mazeData.db; " +
                "Version=3; " +
                "New=True; " +
                "Compress=True; ");
            conn.Open();
            using SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT RecursiveBacktrackMazesGenerated, 
                                       GrowingTreeMazesGenerated, 
                                       WilsonsMazesGenerated
                                FROM GlobalStats";
            using SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                recursiveBacktrackMazesGenerated = reader.GetInt32(0);
                growingTreeMazesGenerated = reader.GetInt32(1);
                wilsonsMazesGenerated = reader.GetInt32(2);
            }
            conn.Close();

            return Task.FromResult(new GlobalMazesGenerated {
                RecursiveBacktrackMazesGenerated = recursiveBacktrackMazesGenerated,
                GrowingTreeMazesGenerated = growingTreeMazesGenerated,
                WilsonsMazesGenerated = wilsonsMazesGenerated
            });
        }

        public override Task<GlobalTimes> GetGlobalTimes(GetGlobalTimesRequest request, ServerCallContext context) {

            string time1DisplayTime = string.Empty;
            string time2DisplayTime = string.Empty;
            string time3DisplayTime = string.Empty;
            string time4DisplayTime = string.Empty;
            string time5DisplayTime = string.Empty;
            string time6DisplayTime = string.Empty;
            string time7DisplayTime = string.Empty;
            string time8DisplayTime = string.Empty;
            string time9DisplayTime = string.Empty;
            string time10DisplayTime = string.Empty;
            string time1Username = string.Empty;
            string time2Username = string.Empty;
            string time3Username = string.Empty;
            string time4Username = string.Empty;
            string time5Username = string.Empty;
            string time6Username = string.Empty;
            string time7Username = string.Empty;
            string time8Username = string.Empty;
            string time9Username = string.Empty;
            string time10Username = string.Empty;

            using SQLiteConnection conn = new("" +
                "Data Source=mazeData.db; " +
                "Version=3; " +
                "New=True; " +
                "Compress=True; ");
            conn.Open();
            using SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT Time1Display, 
                                       Time2Display, 
                                       Time3Display, 
                                       Time4Display, 
                                       Time5Display, 
                                       Time6Display, 
                                       Time7Display, 
                                       Time8Display, 
                                       Time9Display, 
                                       Time10Display,                      
                                       Time1Name, 
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
            using SQLiteDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read()) {
                time1DisplayTime = reader.GetString(0);
                time2DisplayTime = reader.GetString(1);
                time3DisplayTime = reader.GetString(2);
                time4DisplayTime = reader.GetString(3);
                time5DisplayTime = reader.GetString(4);
                time6DisplayTime = reader.GetString(5);
                time7DisplayTime = reader.GetString(6);
                time8DisplayTime = reader.GetString(7);
                time9DisplayTime = reader.GetString(8);
                time10DisplayTime = reader.GetString(9);
                time1Username = reader.GetString(10);
                time2Username = reader.GetString(11);
                time3Username = reader.GetString(12);
                time4Username = reader.GetString(13);
                time5Username = reader.GetString(14);
                time6Username = reader.GetString(15);
                time7Username = reader.GetString(16);
                time8Username = reader.GetString(17);
                time9Username = reader.GetString(18);
                time10Username = reader.GetString(19);
            }

            return Task.FromResult(new GlobalTimes {
                Time1DisplayTime = time1DisplayTime,
                Time2DisplayTime = time2DisplayTime,
                Time3DisplayTime = time3DisplayTime,
                Time4DisplayTime = time4DisplayTime,
                Time5DisplayTime = time5DisplayTime,
                Time6DisplayTime = time6DisplayTime,
                Time7DisplayTime = time7DisplayTime,
                Time8DisplayTime = time8DisplayTime,
                Time9DisplayTime = time9DisplayTime,
                Time10DisplayTime = time10DisplayTime,
                Time1Username = time1Username,
                Time2Username = time2Username,
                Time3Username = time3Username,
                Time4Username = time4Username,
                Time5Username = time5Username,
                Time6Username = time6Username,
                Time7Username = time7Username,
                Time8Username = time8Username,
                Time9Username = time9Username,
                Time10Username = time10Username
            });
        }

        public override Task<UserMazesGenerated> GetUserMazesGenerated(GetUserMazesGeneratedRequest request, ServerCallContext context) {
            int recursiveBacktrackMazesGenerated = 0;
            int growingTreeMazesGenerated = 0;
            int wilsonsMazesGenerated = 0;

            using SQLiteConnection conn = new(
                "Data Source=mazeData.db; " +
                "Version=3; " +
                "New=True; " +
                "Compress=True; ");
            conn.Open();
            using SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = @$"SELECT RecursiveBacktrackMazesGenerated, 
                                        GrowingTreeMazesGenerated, 
                                        WilsonsMazesGenerated
                                FROM UserStats
                                WHERE UID = {request.UserID}";
            using SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                recursiveBacktrackMazesGenerated = reader.GetInt32(0);
                growingTreeMazesGenerated = reader.GetInt32(1);
                wilsonsMazesGenerated = reader.GetInt32(2);
            }
            conn.Close();

            return Task.FromResult(new UserMazesGenerated {
                RecursiveBacktrackMazesGenerated = recursiveBacktrackMazesGenerated,
                GrowingTreeMazesGenerated = growingTreeMazesGenerated,
                WilsonsMazesGenerated = wilsonsMazesGenerated
            });
        }

        public override Task<UserTimes> GetUserTimes(GetUserTimesRequest request, ServerCallContext context) {

            string time1DisplayTime = string.Empty;
            string time2DisplayTime = string.Empty;
            string time3DisplayTime = string.Empty;
            string time4DisplayTime = string.Empty;
            string time5DisplayTime = string.Empty;
            string time6DisplayTime = string.Empty;
            string time7DisplayTime = string.Empty;
            string time8DisplayTime = string.Empty;
            string time9DisplayTime = string.Empty;
            string time10DisplayTime = string.Empty;

            using SQLiteConnection conn = new("" +
                "Data Source=mazeData.db; " +
                "Version=3; " +
                "New=True; " +
                "Compress=True; ");
            conn.Open();
            using SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = @$"SELECT Time1Display, 
                                        Time2Display, 
                                        Time3Display, 
                                        Time4Display, 
                                        Time5Display, 
                                        Time6Display, 
                                        Time7Display, 
                                        Time8Display,
                                        Time9Display, 
                                        Time10Display
                                FROM UserStats
                                WHERE UID = {request.UserID}";
            using SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) {
                time1DisplayTime = reader.GetString(0);
                time2DisplayTime = reader.GetString(1);
                time3DisplayTime = reader.GetString(2);
                time4DisplayTime = reader.GetString(3);
                time5DisplayTime = reader.GetString(4);
                time6DisplayTime = reader.GetString(5);
                time7DisplayTime = reader.GetString(6);
                time8DisplayTime = reader.GetString(7);
                time9DisplayTime = reader.GetString(8);
                time10DisplayTime = reader.GetString(9);
            }

            return Task.FromResult(new UserTimes {
                Time1DisplayTime = time1DisplayTime,
                Time2DisplayTime = time2DisplayTime,
                Time3DisplayTime = time3DisplayTime,
                Time4DisplayTime = time4DisplayTime,
                Time5DisplayTime = time5DisplayTime,
                Time6DisplayTime = time6DisplayTime,
                Time7DisplayTime = time7DisplayTime,
                Time8DisplayTime = time8DisplayTime,
                Time9DisplayTime = time9DisplayTime,
                Time10DisplayTime = time10DisplayTime
            });
        }
    }
}
