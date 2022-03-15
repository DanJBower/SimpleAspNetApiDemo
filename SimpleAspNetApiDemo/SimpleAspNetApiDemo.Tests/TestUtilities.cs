using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleAspNetApiDemo.DataAccess;
using SimpleAspNetApiDemo.Model;
using System;

namespace SimpleAspNetApiDemo.Tests
{
    public static class TestUtilities
    {
        private const string MemoryConnectionString = "Filename=:memory:";

        public static SchoolContext GetBlankContext()
        {
            return Build();
        }

        public static SchoolContext GetSampleContext()
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

            return Build(context =>
            {
                context.Teachers.AddRange(fiona, dereck);
                context.Students.AddRange(kimi, ed, adam);
                context.Subjects.AddRange(mathsSubject, adaSubject);
                context.Classes.AddRange(maths, ada);
                context.Grades.AddRange(edAda);
            });
        }

        private static SchoolContext Build(Action<SchoolContext> buildData = null)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddDebug());
            DbContextOptionsBuilder<SchoolContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<SchoolContext>()
                    .EnableSensitiveDataLogging()
                    .UseLoggerFactory(loggerFactory)
                    .UseSqlite(MemoryConnectionString);

            SchoolContext context = new(dbContextOptionsBuilder.Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            buildData?.Invoke(context);
            context.SaveChanges();
            return context;
        }
    }
}
