using GamesCRUD.DTOs;
using GamesCRUD.Models;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

List<GameDTOs> games =
[
new GameDTOs(1,"Call of Duty",1500),
new GameDTOs(2,"Efootball",1100),
new GameDTOs(3,"Fifa",1000),
new GameDTOs(4,"Racing",1200),
new GameDTOs(5,"WWE",1800),
new GameDTOs(6,"Jet Fighter",700),

];

app.MapGet("ok", () => "Hello Sakib");
app.MapGet("/all",()=> games);
app.MapGet("/game/{id}", (int id) =>
{
   return games.Find(game => game.id == id);
});

app.MapPost("/add", (CreateGameDTO newGame) =>
{
    GameDTOs gameTodd = new(
            games.Count+1,
            newGame.name,
            newGame.price
    );
    games.Add(gameTodd);
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

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();


app.Run();