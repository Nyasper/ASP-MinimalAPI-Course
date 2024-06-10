using asp_course.Data;
using asp_course.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var ConnString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(ConnString);
var app = builder.Build();

app.MapGamesEndpoints();
app.MapGenresEndpoints();

//Custom Middleware
app.Use(async (context, next) =>
{
    Console.WriteLine($"{context.Request.Method} on {context.Request.Path}");
    await next(context);
});

app.Run();

//link del curso
//https://youtu.be/AhAxLiGC7Pc