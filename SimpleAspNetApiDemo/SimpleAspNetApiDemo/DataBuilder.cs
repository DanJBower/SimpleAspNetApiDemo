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

            Build(dbConnection, (context, tablesExist) =>
            {
                if (tablesExist) return;

                context.Teachers.AddRange(fiona, dereck);
                context.Students.AddRange(kimi, ed, adam);
                context.Subjects.AddRange(mathsSubject, adaSubject);
                context.Classes.AddRange(maths, ada);
                context.Grades.AddRange(edAda);
            });
        }

        private static void Build(DbConnection dbConnection, Action<SchoolContext, bool> buildData = null)
        {
            // Basically check if the Teachers table exists or not.
            // If it does, set tablesExist to true so the program
            // does not re-add the sample starting data.
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

            // Create tables if database doesn't exist.
            // This will not update the tables if their definition changes.
            // Delete the database after model changes so this can
            // make the right tables.
            context.Database.EnsureCreated();
            buildData?.Invoke(context, tablesExist);
            context.SaveChanges();
        }
    }
}
