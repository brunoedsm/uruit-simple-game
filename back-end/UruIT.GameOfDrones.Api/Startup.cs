using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using UruIT.GameOfDrones.Business.Services;
using UruIT.GameOfDrones.Domain.Contracts.Services;
using UruIT.GameOfDrones.Domain.Contracts.Repositories;
using UruIT.GameOfDrones.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace UruIT.GameOfDrones.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            /*Configs*/


            /*Data Context*/
            services.AddDbContext<AssessmentContext>(opts => 
            opts.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]
            ));
            /*Services*/    
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<IRoundService, RoundService>();
            services.AddScoped<IHandSignalService, HandSignalService>();
            /*Repositories*/
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<IRoundRepository, RoundRepository>();
            services.AddScoped<IHandSignalRepository, HandSignalRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
