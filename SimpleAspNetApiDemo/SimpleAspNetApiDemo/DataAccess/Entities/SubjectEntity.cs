using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleAspNetApiDemo.DataAccess.Entities
{
    public class SubjectEntity : IEquatable<SubjectEntity>
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<ClassEntity> Classes { get; set; } = new();

        public override bool Equals(object other) => Equals(other as SubjectEntity);

        public bool Equals(SubjectEntity other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;

            return Id == other.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(SubjectEntity lhs, SubjectEntity rhs)
        {
            if (lhs is null) return rhs is null;

            return lhs.Equals(rhs);
        }

        public static bool operator !=(SubjectEntity lhs, SubjectEntity rhs) => !(lhs == rhs);

        public override string ToString()
        {
            return $"{Name}";
        }

        internal static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubjectEntity>(entity =>
            {
                entity.ToTable("Subjects");
            });
        }
    }
}
