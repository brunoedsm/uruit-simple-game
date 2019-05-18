using Microsoft.EntityFrameworkCore;
using UruIT.GameOfDrones.Domain.Entities;

namespace UruIT.GameOfDrones.Repository
{
    public class HandSignalContext : DbContext
    {
        public HandSignalContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<HandSignal> HandSignals { get; set; }
    }
}