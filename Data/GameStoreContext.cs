using GamesCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesCRUD.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Games> games => Set<Games>();
    public DbSet<Genre> genre => Set<Genre>();
}