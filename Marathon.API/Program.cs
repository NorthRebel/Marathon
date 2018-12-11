using System;
using Marathon.Persistence;
using Marathon.Persistence.Seed;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Marathon.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var env = scope.ServiceProvider.GetService<IHostingEnvironment>();
                    var logger = scope.ServiceProvider.GetService<ILogger<ContextInitializer>>();

                    var context = scope.ServiceProvider.GetService<MarathonDbContext>();
                    context.Database.Migrate();

                    new ContextInitializer()
                        .SeedAsync(context, env, logger)
                        .Wait();
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}