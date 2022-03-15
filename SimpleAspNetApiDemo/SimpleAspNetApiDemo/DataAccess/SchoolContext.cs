using Microsoft.EntityFrameworkCore;
using SimpleAspNetApiDemo.DataAccess.Entities;

namespace SimpleAspNetApiDemo.DataAccess
{
    public class SchoolContext : DbContext
    {
        public DbSet<TeacherEntity> Teachers { get; set; }

        public DbSet<GradeEntity> Grades { get; set; }

        public DbSet<StudentEntity> Students { get; set; }

        public DbSet<ClassEntity> Classes { get; set; }

        public DbSet<SubjectEntity> Subjects { get; set; }

        public SchoolContext() { }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            GradeEntity.Configure(modelBuilder);
            TeacherEntity.Configure(modelBuilder);
            StudentEntity.Configure(modelBuilder);
            ClassEntity.Configure(modelBuilder);
            SubjectEntity.Configure(modelBuilder);
        }
    }
}
