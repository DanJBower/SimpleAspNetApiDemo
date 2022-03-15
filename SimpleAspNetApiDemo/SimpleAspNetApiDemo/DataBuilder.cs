using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using SimpleAspNetApiDemo.DataAccess;
using SimpleAspNetApiDemo.Model;
using System;

namespace SimpleAspNetApiDemo
{
    public static class DataBuilder
    {
        public static void EnsureCreated(this string dbConnectionString)
        {
            Build(dbConnectionString);
        }

        public static void BuildSample(this string dbConnectionString)
        {
            Subject mathsSubject = new()
            {
                Name = "Maths",
            };

            Subject adaSubject = new()
            {
                Name = "Ada",
                Description = "The \"best\" programming language!",
            };

            Teacher fiona = new()
            {
                Name = "Fiona",
            };

            Teacher dereck = new()
            {
                Name = "Dereck",
            };

            Student adam = new()
            {
                Age = 12,
                Name = "Adam",
            };

            Student ed = new()
            {
                Age = 11,
                Name = "Ed",
            };

            Student kimi = new()
            {
                Age = 13,
                Name = "Kimi",
                FavouriteSubject = adaSubject,
            };

            Class maths = new()
            {
                Name = "Maths Group A",
                Teacher = fiona,
                Subject = mathsSubject,
            };

            Class ada = new()
            {
                Name = "Ada Group C",
                Teacher = dereck,
                Subject = adaSubject,
            };

            ada.Students.Add(adam);
            ada.Students.Add(kimi);
            ada.Students.Add(ed);
            maths.Students.Add(kimi);
            maths.Students.Add(ed);

            Grade edAda = new()
            {
                Class = ada,
                Student = ed,
                Name = "First Ada Exam",
                Result = 75,
            };

            Build(dbConnectionString, (context, tablesExist) =>
            {
                if (tablesExist) return;

                context.Teachers.AddRange(fiona, dereck);
                context.Students.AddRange(kimi, ed, adam);
                context.Subjects.AddRange(mathsSubject, adaSubject);
                context.Classes.AddRange(maths, ada);
                context.Grades.AddRange(edAda);
            });
        }

        private static void Build(string connectionString, Action<SchoolContext, bool> buildData = null)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddDebug());
            DbContextOptionsBuilder<SchoolContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<SchoolContext>()
                    .EnableSensitiveDataLogging()
                    .UseLoggerFactory(loggerFactory)
                    .UseSqlite(connectionString);

            using SchoolContext context = new(dbContextOptionsBuilder.Options);
            bool tablesExist = context.Database.GetService<IRelationalDatabaseCreator>().HasTables();
            context.Database.EnsureCreated();
            buildData?.Invoke(context, tablesExist);
            context.SaveChanges();
        }
    }
}
