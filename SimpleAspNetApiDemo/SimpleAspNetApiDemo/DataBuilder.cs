using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleAspNetApiDemo.DataAccess;
using SimpleAspNetApiDemo.Model;
using System;
using System.Data.Common;

namespace SimpleAspNetApiDemo
{
    public static class DataBuilder
    {
        public static void EnsureCreated(this DbConnection dbConnection)
        {
            Build(dbConnection);
        }

        public static void BuildSample(this DbConnection dbConnection)
        {
            Teacher steve = new()
            {
                Name = "Steve",
            };

            Build(dbConnection, (context, tablesExist) =>
            {
                if (tablesExist) return;

                context.Teachers.AddRange(steve);
            });
        }

        private static void Build(DbConnection dbConnection, Action<SchoolContext, bool> buildData = null)
        {
            using DbCommand command = dbConnection.CreateCommand();
            command.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='Teachers';";
            bool tablesExist = false;

            using DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                tablesExist = true;
            }

            using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddDebug());
            DbContextOptionsBuilder<SchoolContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<SchoolContext>()
                    .EnableSensitiveDataLogging()
                    .UseLoggerFactory(loggerFactory)
                    .UseSqlite(dbConnection);

            using SchoolContext context = new(dbContextOptionsBuilder.Options);
            context.Database.EnsureCreated();
            buildData?.Invoke(context, tablesExist);
            context.SaveChanges();
        }
    }
}
