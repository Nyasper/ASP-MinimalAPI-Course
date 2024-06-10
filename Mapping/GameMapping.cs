using asp_course.DTOs;
using asp_course.Entities;

namespace asp_course.Mapping;

public static class GameMapping
{
  public static Game ToEntity(this CreateGameDTO game)
  {
     return new()
      {
        Name = game.Name,
        GenreId = game.GenreId,
        Price = game.Price,
        ReleaseDate = game.ReleaseDate
      };
  }

  public static GameSummaryDTO ToGameSummaryDto(this Game game)
  {
    return new 
      (
        game.Id,
        game.Name,
        game.Genre!.Name,
        game.Price,
        game.ReleaseDate
      );

  }

   public static GameDetailDTO ToGameDetailsDto(this Game game)
  {
    return new 
      (
        game.Id,
        game.Name,
        game.GenreId,
        game.Price,
        game.ReleaseDate
      );

  }

   public static Game ToEntity(this UpdateGameDTO game, int id)
  {
     return new()
      {
        Id = id,
        Name = game.Name,
        GenreId = game.GenreId,
        Price = game.Price,
        ReleaseDate = game.ReleaseDate
      };
  }

}
