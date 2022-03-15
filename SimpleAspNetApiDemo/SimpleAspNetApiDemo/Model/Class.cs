using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleAspNetApiDemo.Model
{
    public class Class : IEquatable<Class>
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        [Required]
        public Teacher Teacher { get; set; }

        [Required]
        public Subject Subject { get; set; }

        public List<Student> Students { get; set; } = new();

        public List<Grade> Grades { get; set; } = new();

        public override bool Equals(object other) => Equals(other as Class);

        public bool Equals(Class other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;

            return Id == other.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(Class lhs, Class rhs)
        {
            if (lhs is null) return rhs is null;

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Class lhs, Class rhs) => !(lhs == rhs);

        public override string ToString()
        {
            return $"{Name}";
        }

        internal static void Configure(ModelBuilder modelBuilder)
        {
        }
    }
}
