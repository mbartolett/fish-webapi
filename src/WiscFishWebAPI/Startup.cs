using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiscFishWebAPI.Repo;
using WiscFishWebAPI.Services;

namespace WiscFishWebAPI
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
            services.AddTransient<IPinsService, PinsService>();
            services.AddTransient<IDropDownDataService, DropDownDataService>();

            services.AddTransient<IPinsRepo, PinsRepo>();
            services.AddTransient<IDropDownDataRepo, DropDownDataRepo>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WiscFishWebAPI", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("allowedOrigins",
                builder =>
                {
                    builder.WithOrigins("https://localhost:5001");
                    builder.WithOrigins("https://localhost:44347");
                    builder.WithOrigins("https://fishon.azurewebsites.net").AllowAnyHeader().AllowAnyMethod();
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WiscFishWebAPI v1"));

            
            app.UseRouting();
            app.UseCors("allowedOrigins");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
