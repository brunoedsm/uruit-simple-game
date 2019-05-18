using Microsoft.EntityFrameworkCore;
using UruIT.GameOfDrones.Domain.Entities;

namespace UruIT.GameOfDrones.Repository
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Player> Players { get; set; }
    }
}