using CpmPedidos.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Npgsql;
using System.Data.Common;

namespace CpmPedidos.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public DbConnection DbConnection => new NpgsqlConnection(Configuration.GetConnectionString("App"));

        //public SqlConnection DbConnection => new SqlConnection(Configuration.GetConnectionString("App"));

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // 3 startUp DbConnection  
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(
                   DbConnection,
                   assembly => assembly.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));

                //options.UseSqlServer(
                //  DbConnection,
                //  assembly => assembly.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));

                //options.UseSqlServer(
                //  Configuration.GetConnectionString("App"),
                //  assembly => assembly.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            DependencyInjection.Register(services);

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CpmPedidos.API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CpmPedidos.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}