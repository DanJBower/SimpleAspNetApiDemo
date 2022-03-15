using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SimpleAspNetApiDemo.DataAccess;
using System.Data.Common;

namespace SimpleAspNetApiDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Ensure Database exists
            // If doesn't exist, add base data
            using (DbConnection connection = SchoolDatabase.GetSchoolDbConnection())
            {
                connection.Open();
                connection.BuildSample();
            }

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
