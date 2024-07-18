using System.Reflection;
using GameStore.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.server.Data;

public class GamestoreContext : DbContext
{
    public GamestoreContext(DbContextOptions<GamestoreContext> options) : base(options)
    {

    }

    public DbSet<Game> Games => Set<Game>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}