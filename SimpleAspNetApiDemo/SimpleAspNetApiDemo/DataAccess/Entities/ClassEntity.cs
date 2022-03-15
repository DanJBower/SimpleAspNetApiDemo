using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SimpleAspNetApiDemo.DataAccess.Entities
{
    public class ClassEntity : IEquatable<ClassEntity>
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        [Required]
        public TeacherEntity Teacher { get; set; }

        [Required]
        public SubjectEntity Subject { get; set; }

        public List<StudentEntity> Students { get; set; } = new();

        public List<GradeEntity> Grades { get; set; } = new();

        public override bool Equals(object other) => Equals(other as ClassEntity);

        public bool Equals(ClassEntity other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;

            return Id == other.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(ClassEntity lhs, ClassEntity rhs)
        {
            if (lhs is null) return rhs is null;

            return lhs.Equals(rhs);
        }

        public static bool operator !=(ClassEntity lhs, ClassEntity rhs) => !(lhs == rhs);

        public override string ToString()
        {
            return $"{Name}";
        }

        internal static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassEntity>(entity =>
            {
                entity.ToTable("Classes");
            });
        }
    }
}
