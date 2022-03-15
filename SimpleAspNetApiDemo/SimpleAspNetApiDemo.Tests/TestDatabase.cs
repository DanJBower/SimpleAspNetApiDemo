using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleAspNetApiDemo.DataAccess;
using SimpleAspNetApiDemo.Model;
using System;
using System.Data.Common;

namespace SimpleAspNetApiDemo.Tests
{
    public class TestDatabase : IDisposable
    {
        private const string MemoryConnectionString = "Data Source=:memory:";

        private TestDatabase() { }

        public SchoolContext Context { get; private init; }

        private DbConnection Connection { get; init; }

        public static TestDatabase NewEmptyDatabase() => Build();

        public static TestDatabase NewSampleDatabase()
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

        private static TestDatabase Build(Action<SchoolContext> buildData = null)
        {
            DbConnection connection = null;
            SchoolContext context = null;

            try
            {
                // EF Core always opens and closes connections in the back end
                // so need to manually keep connection alive for duration of test.
                connection = new SqliteConnection(MemoryConnectionString);
                connection.Open();

                using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddDebug());
                DbContextOptionsBuilder<SchoolContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<SchoolContext>()
                    .EnableSensitiveDataLogging()
                    .UseLoggerFactory(loggerFactory)
                    .UseSqlite(connection);

                context = new SchoolContext(dbContextOptionsBuilder.Options);
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                buildData?.Invoke(context);
                context.SaveChanges();
            }
            catch (Exception)
            {
                connection?.Dispose();
                context?.Dispose();
                throw;
            }

            return new TestDatabase
            {
                Connection = connection,
                Context = context,
            };
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            Connection?.Dispose();
            Context?.Dispose();
        }
    }
}
