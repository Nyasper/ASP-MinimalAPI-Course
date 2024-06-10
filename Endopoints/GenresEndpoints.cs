using System.Reflection.Metadata.Ecma335;
using asp_course.Data;
using asp_course.Mapping;
using Microsoft.EntityFrameworkCore;

namespace asp_course.Endpoints;

public static class GenresEndpoints
{
  public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
  {
    var Group = app.MapGroup("/genres");

    Group.MapGet("/", async (GameStoreContext dbContext) => 
      await dbContext.Genres
        .Select(genre => genre.ToDto())
        .AsNoTracking()
        .ToListAsync());

    return Group; 
    }
}
