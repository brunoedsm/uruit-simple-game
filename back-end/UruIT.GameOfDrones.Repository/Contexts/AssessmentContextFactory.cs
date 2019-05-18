using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using UruIT.GameOfDrones.Domain.Entities;

namespace UruIT.GameOfDrones.Repository
{
    public class AssessmentContextFactory : IDesignTimeDbContextFactory<AssessmentContext>
    {
        public AssessmentContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();
            var optionsBuilder = new DbContextOptionsBuilder<AssessmentContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            return new AssessmentContext(optionsBuilder.Options);
        }
    }
}