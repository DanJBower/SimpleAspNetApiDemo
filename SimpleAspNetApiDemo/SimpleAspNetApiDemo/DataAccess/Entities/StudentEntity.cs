using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SimpleAspNetApiDemo.DataAccess.Entities
{
    public class StudentEntity : IEquatable<StudentEntity>
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        public SubjectEntity FavouriteSubject { get; set; }

        public List<ClassEntity> Classes { get; set; } = new();

        public List<GradeEntity> Grades { get; set; } = new();

        public override bool Equals(object other) => Equals(other as StudentEntity);

        public bool Equals(StudentEntity other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;

            return Id == other.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(StudentEntity lhs, StudentEntity rhs)
        {
            if (lhs is null) return rhs is null;

            return lhs.Equals(rhs);
        }

        public static bool operator !=(StudentEntity lhs, StudentEntity rhs) => !(lhs == rhs);

        public override string ToString()
        {
            return $"{Name} ({Age})";
        }

        internal static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentEntity>(entity =>
            {
                entity.ToTable("Students");
            });
        }
    }
}
