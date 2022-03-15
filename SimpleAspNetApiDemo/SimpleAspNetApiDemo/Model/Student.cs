using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SimpleAspNetApiDemo.Model
{
    public class Student : IEquatable<Student>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Subject FavouriteSubject { get; set; }

        public List<Class> Classes { get; set; }

        public List<Grade> Grades { get; set; }

        public override bool Equals(object other) => Equals(other as Student);

        public bool Equals(Student other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;

            return Id == other.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(Student lhs, Student rhs)
        {
            if (lhs is null) return rhs is null;

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Student lhs, Student rhs) => !(lhs == rhs);

        public override string ToString()
        {
            return $"{Name} ({Age})";
        }

        internal static void Configure(ModelBuilder modelBuilder)
        {
        }
    }
}
