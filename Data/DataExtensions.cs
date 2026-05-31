using GamesCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesCRUD.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        
        dbContext.Database.Migrate();
    }

    public static void AddGameStoreDb(this WebApplicationBuilder builder)
    {
        var connStr = builder.Configuration.GetConnectionString("GamesStore");

        builder.Services.AddScoped<GameStoreContext>();
        builder.Services.AddSqlite<GameStoreContext>(connStr,
            optionsAction: options=> options.UseSeeding((context, _) =>
            {
                if (!context.Set<Genre>().Any())
                {
                    context.Set<Genre>().AddRange(
                        new Genre{genre = "Racing"},
                        new Genre{genre = "Fighting"},
                        new Genre{genre = "Survival"},
                        new Genre{genre = "Running"}
                    );
                }
                context.SaveChanges();
                Console.Write(connStr);
            })
        );
    }
}