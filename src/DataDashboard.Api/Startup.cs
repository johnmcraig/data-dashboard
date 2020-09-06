using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataDashboard.Infrastructure;
using DataDashboard.Infrastructure.Data;
using DataDashboard.Infrastructure.SeedData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DataDashboard.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration
        {
            get;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure();

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", c => c.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });

            //transient service to call DataSeed program class on startup
            services.AddTransient<DataSeed>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataSeed seed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseRouting();

            seed.SeedData(25, 1000); //(x,y) called from service DataSeed that will populate DB with X customers and Y orders

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}