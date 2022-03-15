using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SimpleAspNetApiDemo.Model
{
    public class Teacher : IEquatable<Teacher>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Class> Classes { get; set; }

        public override bool Equals(object other) => Equals(other as Teacher);

        public bool Equals(Teacher other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;

            return Id == other.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(Teacher lhs, Teacher rhs)
        {
            if (lhs is null) return rhs is null;

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Teacher lhs, Teacher rhs) => !(lhs == rhs);

        public override string ToString()
        {
            return $"{Name}";
        }

        internal static void Configure(ModelBuilder modelBuilder)
        {
        }
    }
}
