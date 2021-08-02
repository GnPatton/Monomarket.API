using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Monomarket.API.Helpers;
using Monomarket.Business.Services;
using Monomarket.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monomarket.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _environment = environment;

            if(environment.IsDevelopment())
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(environment.ContentRootPath)
                    .AddJsonFile("appsettings.json",
                    optional: false,
                    reloadOnChange: true)
                    .AddEnvironmentVariables();

                builder.AddUserSecrets<Startup>();
                _configuration = builder.Build();
            }
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureOptions(services);

            ConfigureDatabase(services);

            services.AddControllers();
            
            services.AddMonoServices()
            .AddMonoRepositories()
            .AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Monomarket.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(_ => 
                _.SwaggerEndpoint($"/swagger/{_configuration["ApiCurrentVersion"]}/swagger.json", "Monomarket.API"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        private void ConfigureOptions(IServiceCollection services)
        {
            
        }

        protected virtual void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<MonoDbContext>(options => options.UseNpgsql(_configuration.GetConnectionString("MonoDb")));
        }
    }
}
