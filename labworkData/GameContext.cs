using labworkData;
using Microsoft.EntityFrameworkCore;

namespace labworkData
{
    public class GameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public GameContext(DbContextOptions<GameContext> options): base(options)
        {

        }
    }
}
