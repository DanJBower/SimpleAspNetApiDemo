using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using SimpleAspNetApiDemo.DataAccess;
using System;
using SimpleAspNetApiDemo.DataAccess.Entities;

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
            SubjectEntity mathsSubject = new()
            {
                Name = "Maths",
            };

            SubjectEntity adaSubject = new()
            {
                Name = "Ada",
                Description = "The \"best\" programming language!",
            };

            TeacherEntity fiona = new()
            {
                Name = "Fiona",
            };

            TeacherEntity dereck = new()
            {
                Name = "Dereck",
            };

            StudentEntity adam = new()
            {
                Age = 12,
                Name = "Adam",
            };

            StudentEntity ed = new()
            {
                Age = 11,
                Name = "Ed",
            };

            StudentEntity kimi = new()
            {
                Age = 13,
                Name = "Kimi",
                FavouriteSubject = adaSubject,
            };

            ClassEntity maths = new()
            {
                Name = "Maths Group A",
                Teacher = fiona,
                Subject = mathsSubject,
            };

            ClassEntity ada = new()
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

            GradeEntity edAda = new()
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
