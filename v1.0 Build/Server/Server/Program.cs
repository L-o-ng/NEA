using Server.Services;
using System.Data.SQLite;

//initialize database
SQLiteConnection conn = new("Data Source= mazeData.db; Version = 3; New = True; Compress = True; ");
conn.Open();
using (SQLiteCommand cmd = conn.CreateCommand()) {
    cmd.CommandText = "PRAGMA foreign_keys = ON;";
    cmd.ExecuteNonQuery();
    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Login(UID INTEGER PRIMARY KEY, Username VARCHAR, Password VARCHAR, Salt VARCHAR)";
    cmd.ExecuteNonQuery();
    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Mazes(MazeID INTEGER PRIMARY KEY, MazeObject VARCHAR, MazeGenAlg VARCHAR, MazeName VARCHAR(10), UID INTEGER, FOREIGN KEY(UID) REFERENCES Login(UID))";
    cmd.ExecuteNonQuery();
    
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

app.Run();