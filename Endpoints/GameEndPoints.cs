using GamesCRUD.Data;
using GamesCRUD.DTOs;
using GamesCRUD.Models;

namespace GamesCRUD.Endpoints;

public static class GameEndPoints
{
    static List<GameDTOs> games =
    [
        new GameDTOs(1,"Call of Duty",1500),
        new GameDTOs(2,"Efootball",1100),
        new GameDTOs(3,"Fifa",1000),
        new GameDTOs(4,"Racing",1200),
        new GameDTOs(5,"WWE",1800),
        new GameDTOs(6,"Jet Fighter",700),

    ];

    public static void EndPoints(this WebApplication app)
    {
        
        app.MapGet("ok", () => "Hello Sakib");
        app.MapGet("/all",()=> games);
        app.MapGet("/game/{id}", (int id) =>
        {
            return games.Find(game => game.id == id);
        });

        app.MapPost("/add", (CreateGameDTO newGame, GameStoreContext DbContext) =>
        {
            Games game = new()
            {
                id = newGame.id,
                genreId = newGame.genreId,
                name = newGame.name,
                price = newGame.price
            };
            DbContext.games.Add(game);
            DbContext.SaveChanges();
        });

        app.MapDelete("/delete/{id}", (int id) =>
        {
            games.RemoveAll(game => game.id == id);
            return Results.NoContent();
        });

        app.MapPut("/update/{id}", (int id,UpdateGameDTO updatedGame) =>
        {
            var index = games.FindIndex(game => game.id == id);
            games[index] = new GameDTOs(
                id,
                updatedGame.name,
                updatedGame.price
            );
            return Results.NoContent();
        });
    }
}