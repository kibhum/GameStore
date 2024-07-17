using Microsoft.EntityFrameworkCore;

namespace Gamestore.server.Data;

public class GamestoreContext : DbContext
{
    public GamestoreContext(DbContextOptions<GamestoreContext> options) : base(options)
    {

    }
}