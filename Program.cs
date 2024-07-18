using Gamestore.server.Data;
using GameStore.Server.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var ConnString = builder.Configuration.GetConnectionString("GameStoreContext");
builder.Services.AddSqlServer<GamestoreContext>(ConnString);
var app = builder.Build();

var group = app.MapGroup("/games").WithParameterValidation();

// Get all games
group.MapGet("/", async (GamestoreContext context) => await context.Games.AsNoTracking().ToListAsync());
// Get a game by id
group.MapGet("/{id}", async (int id, GamestoreContext context) =>
{

    Game? game = await context.Games.FindAsync(id);
    if (game is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(game);

}).WithName("GetGame");

group.MapPost("/", async (GamestoreContext context, Game game) =>
{
    context.Games.Add(game);
    await context.SaveChangesAsync();
    return Results.CreatedAtRoute("GetGame", new { id = game.Id }, game);
});


group.MapPut("/{id}", async (GamestoreContext context, int id, Game updatedGame) =>
{
    var rowsAffected = await context.Games.Where(game => game.Id == id).ExecuteUpdateAsync(updates =>
        updates.SetProperty(game => game.Name, updatedGame.Name).SetProperty(game => game.Price, updatedGame.Price).SetProperty(game => game.ReleaseDate, updatedGame.ReleaseDate).SetProperty(game => game.Genre, updatedGame.Genre));
    return rowsAffected > 0 ? Results.NoContent() : Results.NotFound();
});

group.MapDelete("/{id}", async (GamestoreContext context, int id) =>
{
    var rowsAffected = await context.Games.Where(game => game.Id == id).ExecuteDeleteAsync();
    return rowsAffected > 0 ? Results.NoContent() : Results.NotFound();

});

app.Run();

