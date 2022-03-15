using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SimpleAspNetApiDemo.Model
{
    public class Subject : IEquatable<Subject>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Class> Classes { get; set; }

        public override bool Equals(object other) => Equals(other as Subject);

        public bool Equals(Subject other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;

            return Id == other.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(Subject lhs, Subject rhs)
        {
            if (lhs is null) return rhs is null;

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Subject lhs, Subject rhs) => !(lhs == rhs);

        public override string ToString()
        {
            return $"{Name}";
        }

        internal static void Configure(ModelBuilder modelBuilder)
        {
        }
    }
}
