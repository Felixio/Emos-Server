using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lgm.Emos.Core.Entities;
using Lgm.Emos.Infrastructure.Data;
using Lgm.Emos.Infrastructure.Identity;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Lgm.Emos.Web
{
    public class Program
    {
        public static int Main(string[] args)
        {
            //Build Config
            var currentEnv = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{currentEnv}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            //Configure logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try
            {
                Log.Information("Web Host - Starting");
                var host = BuildWebHost(args);
                
                SeedData(host);

                host.Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Web Host -  Fatal error");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }


        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog()
                .Build();

        private static void SeedData(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    AppDbContextSeedData.SeedAsync(services)
                        .Wait();

                    var userManager = services.GetRequiredService<UserManager<IdentityAppUser>>();
                    var dbContext = services.GetRequiredService<AppDbContext>();
                    IdentityAppDbContextSeedData.SeedAsync(userManager, dbContext).Wait();
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
