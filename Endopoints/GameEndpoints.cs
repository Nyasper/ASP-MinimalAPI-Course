using asp_course.Data;
using asp_course.DTOs;
using asp_course.Entities;
using asp_course.Mapping;
using Microsoft.EntityFrameworkCore;

namespace asp_course.Endpoints;

public static class GameEndpoints
{
  const string GetGameEndpointName = "GetGame";

  public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
  {
    var Group = app.MapGroup("/games")
      .WithParameterValidation();

    Group.MapGet("/", async(GameStoreContext dbContext) => await dbContext.Games
      .Include(game=> game.Genre)
      .Select(game=>game.ToGameSummaryDto())
      .AsNoTracking()
      .ToListAsync());

    Group.MapGet("/{id}", async (int id, GameStoreContext dbConxtext)=>{
      var Game = await dbConxtext.Games.FindAsync(id);

      return Game == null ? Results.NotFound() : Results.Ok(Game.ToGameDetailsDto());
    })
      .WithName(GetGameEndpointName);

    Group.MapPost("/", async (CreateGameDTO NewGame, GameStoreContext dbContext) => {

      Game Game = NewGame.ToEntity();

      await dbContext.Games.AddAsync(Game);
      await dbContext.SaveChangesAsync(); 

      return Results.CreatedAtRoute(GetGameEndpointName, new { id = Game.Id }, Game.ToGameDetailsDto());
    });

    Group.MapPut("/{id}", async(int id, UpdateGameDTO UpdatedGame, GameStoreContext dbContext)=>
      {
        var existingGame = await dbContext.Games.FindAsync(id);

        if (existingGame == null)
        {
          return Results.NotFound();
        }

        dbContext.Entry(existingGame).CurrentValues.SetValues(UpdatedGame.ToEntity(id));

        await dbContext.SaveChangesAsync();

        return Results.NoContent();
      });

      Group.MapDelete("/{id}", async (int id, GameStoreContext dbContext)=>{

        await dbContext.Games.Where(game => game.Id == id)
          .ExecuteDeleteAsync();

        return Results.NoContent();
      });
      return Group;
  }

}
