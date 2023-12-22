using Server.Services;
using System.Data.SQLite;

//initialize database
SQLiteConnection conn = new("Data Source= mazeData.db; Version = 3; New = True; Compress = True; ");
conn.Open();
using (SQLiteCommand cmd = conn.CreateCommand()) {
    cmd.CommandText = "PRAGMA foreign_keys = ON;";
    cmd.ExecuteNonQuery();

    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Login(
                            UID INTEGER PRIMARY KEY, 
                            Username VARCHAR, 
                            Password VARCHAR, 
                            Salt VARCHAR
                        )";
    cmd.ExecuteNonQuery();

    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Mazes(
                            MazeID INTEGER PRIMARY KEY, 
                            MazeObject VARCHAR, 
                            MazeGenAlg VARCHAR, 
                            MazeName VARCHAR(10), 
                            UID INTEGER, 
                            FOREIGN KEY(UID) REFERENCES Login(UID)
                        )";
    cmd.ExecuteNonQuery();

    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS UserStats(
                            UID INTEGER PRIMARY KEY, 
                            Time1Display VARCHAR, 
                            Time1Milliseconds INTEGER,
                            Time2Display VARCHAR, 
                            Time2Milliseconds INTEGER,
                            Time3Display VARCHAR, 
                            Time3Milliseconds INTEGER,
                            Time4Display VARCHAR, 
                            Time4Milliseconds INTEGER,
                            Time5Display VARCHAR, 
                            Time5Milliseconds INTEGER,
                            Time6Display VARCHAR, 
                            Time6Milliseconds INTEGER,
                            Time7Display VARCHAR, 
                            Time7Milliseconds INTEGER,
                            Time8Display VARCHAR, 
                            Time8Milliseconds INTEGER,
                            Time9Display VARCHAR, 
                            Time9Milliseconds INTEGER,
                            Time10Display VARCHAR, 
                            Time10Milliseconds INTEGER,
                            RecursiveBacktrackMazesGenerated INTEGER, 
                            KruskalsMazesgenerated INTEGER, 
                            WilsonsMazesGenerated INTEGER, 
                            FOREIGN KEY(UID) REFERENCES Login(UID)
                        )"; 
    cmd.ExecuteNonQuery();
    //ON DELETE CASCADE deletes the relevent record if the user is deleted

    cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS GlobalStats (
                        Time1Display VARCHAR,
                        Time1Milliseconds INTEGER,
                        Time1Name VARCHAR,
                        
                        Time2Display VARCHAR,
                        Time2Milliseconds INTEGER,
                        Time2Name VARCHAR,
                        
                        Time3Display VARCHAR,
                        Time3Milliseconds INTEGER,
                        Time3Name VARCHAR,
                        
                        Time4Display VARCHAR,
                        Time4Milliseconds INTEGER,
                        Time4Name VARCHAR,
                        
                        Time5Display VARCHAR,
                        Time5Milliseconds INTEGER,
                        Time5Name VARCHAR,
                        
                        Time6Display VARCHAR,
                        Time6Milliseconds INTEGER,
                        Time6Name VARCHAR,
                        
                        Time7Display VARCHAR,
                        Time7Milliseconds INTEGER,
                        Time7Name VARCHAR,
                        
                        Time8Display VARCHAR,
                        Time8Milliseconds INTEGER,
                        Time8Name VARCHAR,
                        
                        Time9Display VARCHAR,
                        Time9Milliseconds INTEGER,
                        Time9Name VARCHAR,
                        
                        Time10Display VARCHAR,
                        Time10Milliseconds INTEGER,
                        Time10Name VARCHAR,
                        
                        RecursiveBacktrackMazesGenerated INTEGER,
                        KruskalsMazesGenerated INTEGER,
                        WilsonsMazesGenerated INTEGER
                    )";
    cmd.ExecuteNonQuery();

    cmd.CommandText = @"CREATE TRIGGER IF NOT EXISTS CreateStatsRecord
                        AFTER INSERT ON Login 
                        BEGIN 
                            INSERT INTO UserStats VALUES (NEW.UID, '', -1, '', -1, '', -1, '', -1, '', -1, '', -1, '', -1, '', -1, '', -1, '', -1, 0, 0, 0); 
                        END;";
    cmd.ExecuteNonQuery();

    cmd.CommandText = "SELECT COUNT(*) FROM GlobalStats";
    int rowCount = Convert.ToInt32(cmd.ExecuteScalar());
    if (rowCount == 0) {
        cmd.CommandText = "INSERT INTO GlobalStats Values('', -1, '', '', -1, '', '', -1, '', '', -1, '', '', -1, '', '', -1, '', '', -1, '', '', -1, '', '', -1, '', '', -1, '', 0, 0, 0)";
        cmd.ExecuteNonQuery();
    }
}

conn.Close();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<MazeBuilderService>();
app.MapGrpcService<MazeSolverService>();
app.MapGrpcService<RegisterService>();
app.MapGrpcService<CheckerIfUserExistsService>();
app.MapGrpcService<LoginService>();
app.MapGrpcService<SaveMazeService>();
app.MapGrpcService<GetMazesService>();
app.MapGrpcService<LoadMazeService>();
app.MapGrpcService<DeleteMazeService>();
app.MapGrpcService<GlobalStatHandlerService>();
app.MapGrpcService<HandleUserStatsService>();

app.Run();