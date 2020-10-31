using DataAccess.Factories;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using DataAccess.Settings;
using HomeNeedsWebAPI.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HomeNeedsWebAPI
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
            services.AddControllers();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // Swagger implementation
            services.AddSwaggerGen((option) =>
            {
                option.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "HomeNeedsWebAPI",
                        Version = "v1"
                    });
            });

            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IConnectionStringSettings, ConnectionStringSetting>();
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI((option) =>
            {
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "HomeNeedsWebAPI");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
