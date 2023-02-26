var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Task.FromResult("Hello World!"));

app.MapPost("/", async context => Results.NoContent());

app.Run();