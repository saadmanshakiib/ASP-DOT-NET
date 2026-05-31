using GamesCRUD.Data;
using GamesCRUD.DTOs;
using GamesCRUD.Endpoints;
using GamesCRUD.Models;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.AddGameStoreDb();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.MigrateDb();
app.EndPoints();
app.UseAuthorization();

app.MapStaticAssets();


app.Run();