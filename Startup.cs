using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using ApcUpsLogger.Utils;
using ApcUpsLogger.DataAccess;
using ApcUpsLogger.Engine;

namespace ApcUpsLogger
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"User ID=application;Password=1234;Host=localhost;Port=5432;Database=apcups;Pooling=true;";
            services.AddDbContext<ApcUpsLoggerDbContext>(options => options.UseNpgsql(connection));
            services.AddScoped<ApcDevice, ApcDevice>();
            services.AddScoped<ApcDbLogger, ApcDbLogger>();
            services.AddTransient<ScopedRunner, ScopedRunner>();
            services.AddSingleton<PeriodicLogger, PeriodicLogger>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMvc();
            app.ApplicationServices.GetService<PeriodicLogger>().Run();
        }
    }
}
