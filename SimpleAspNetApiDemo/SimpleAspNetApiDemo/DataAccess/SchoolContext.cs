using Microsoft.EntityFrameworkCore;
using SimpleAspNetApiDemo.Model;
using System;

namespace SimpleAspNetApiDemo.DataAccess
{
    public class SchoolContext : DbContext
    {
        public bool DisposeConnectionOnDispose { get; set; } = true;

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public SchoolContext() { }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Grade.Configure(modelBuilder);
            Teacher.Configure(modelBuilder);
            Student.Configure(modelBuilder);
            Class.Configure(modelBuilder);
            Subject.Configure(modelBuilder);
        }

        public sealed override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (DisposeConnectionOnDispose)
            {
                Database.CloseConnection();
                Database.GetDbConnection().Dispose();
            }

            base.Dispose();
        }
    }
}
