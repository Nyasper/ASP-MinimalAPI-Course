using Microsoft.EntityFrameworkCore;

namespace asp_course.Data;

public static class DataExtension
{
  public static async Task MigrateDbAsync(this WebApplication app){
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
    await dbContext.Database.MigrateAsync();
  }
}
