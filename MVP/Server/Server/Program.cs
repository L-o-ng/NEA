using Server.Services;
using System.Data.SQLite;

//initialize database
SQLiteConnection conn = new("Data Source= mazeData.db; Version = 3; New = True; Compress = True; ");
conn.Open();
SQLiteCommand cmd = conn.CreateCommand();
cmd.CommandText = "CREATE TABLE IF NOT EXISTS Login(Username VARCHAR, Password VARCHAR, Salt VARCHAR)";
cmd.ExecuteNonQuery();
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

app.Run();