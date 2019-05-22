using System;
using Microsoft.EntityFrameworkCore;
using UruIT.GameOfDrones.Domain.Entities;

namespace UruIT.GameOfDrones.Repository
{
    public class AssessmentContext : DbContext
    {
        public AssessmentContext(DbContextOptions<AssessmentContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<HandSignal> HandSignals { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Round> Rounds { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HandSignal>().HasData(new HandSignal()
            {
                Id = 1,
                Description = "Paper",
                DataRegister = DateTime.Now
            });
            modelBuilder.Entity<HandSignal>().HasData(new HandSignal()
            {
                Id = 2,
                Description = "Rock",
                DataRegister = DateTime.Now
            });
            modelBuilder.Entity<HandSignal>().HasData(new HandSignal()
            {
                Id = 3,
                Description = "Scissor",
                DataRegister = DateTime.Now
            });
        }
    }
}