using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SimpleAspNetApiDemo.DataAccess.Entities
{
    public class GradeEntity : IEquatable<GradeEntity>, IComparable<GradeEntity>, IComparable
    {
        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public StudentEntity Student { get; set; }

        [Required]
        public Guid ClassId { get; set; }

        [Required]
        public ClassEntity Class { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Result { get; set; }

        public override bool Equals(object other) => Equals(other as GradeEntity);

        public bool Equals(GradeEntity other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;

            return Student.Equals(other.Student) && Class.Equals(other.Class);
        }

        public override int GetHashCode() => HashCode.Combine(Student, Class);

        public static bool operator ==(GradeEntity lhs, GradeEntity rhs)
        {
            if (lhs is null) return rhs is null;

            return lhs.Equals(rhs);
        }

        public static bool operator !=(GradeEntity lhs, GradeEntity rhs) => !(lhs == rhs);

        public int CompareTo(GradeEntity other)
        {
            return Result.CompareTo(other.Result);
        }

        public int CompareTo(object other)
        {
            if (other is GradeEntity otherGrade)
                return CompareTo(otherGrade);

            throw new ArgumentException("Can only compare to other grades.");
        }

        public static bool operator >(GradeEntity lhs, GradeEntity rhs)
        {
            return lhs.CompareTo(rhs) > 0;
        }

        public static bool operator <(GradeEntity lhs, GradeEntity rhs)
        {
            return lhs.CompareTo(rhs) < 0;
        }

        public static bool operator >=(GradeEntity lhs, GradeEntity rhs)
        {
            return lhs.CompareTo(rhs) >= 0;
        }

        public static bool operator <=(GradeEntity lhs, GradeEntity rhs)
        {
            return lhs.CompareTo(rhs) <= 0;
        }

        public override string ToString()
        {
            return $"{Name} : {Student.Name} - {Result}";
        }

        internal static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GradeEntity>(entity =>
            {
                entity.ToTable("Grades");

                entity.HasKey(e => new { e.ClassId, e.StudentId });

                entity.HasOne(e => e.Class)
                    .WithMany(e => e.Grades)
                    .HasForeignKey(e => e.ClassId);

                entity.HasOne(e => e.Student)
                    .WithMany(e => e.Grades)
                    .HasForeignKey(e => e.StudentId);
            });
        }
    }
}
