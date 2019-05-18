using Microsoft.EntityFrameworkCore;
using UruIT.GameOfDrones.Domain.Entities;

namespace UruIT.GameOfDrones.Repository
{
    public class MatchContext : DbContext
    {
        public MatchContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Match> Matches { get; set; }
    }
}