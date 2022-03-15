using Microsoft.EntityFrameworkCore;
using SimpleAspNetApiDemo.Model;

namespace SimpleAspNetApiDemo.DataAccess
{
    public class SchoolContext : DbContext
    {
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
    }
}
