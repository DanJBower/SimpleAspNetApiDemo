using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SimpleAspNetApiDemo.DataAccess;

namespace SimpleAspNetApiDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Ensure Database exists
            // If doesn't exist, add base data
            SchoolDatabase.SchoolDatabaseConnectionString.BuildSample();

            // Run API
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
