using Microsoft.EntityFrameworkCore;
using UruIT.GameOfDrones.Domain.Entities;

namespace UruIT.GameOfDrones.Repository
{
    public class RoundContext : DbContext
    {
        public RoundContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Round> Rounds { get; set; }
    }
}