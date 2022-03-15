using SimpleAspNetApiDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleAspNetApiDemo.Model
{
    public class Class : IClass
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        public IList<Student> Students { get; set; }

        public IList<Grade> Grades { get; set; }

        public ITeacher Teacher { get; set; }

        public override bool Equals(object other) => Equals(other as IClass);

        public bool Equals(IClass other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;

            return Id == other.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(Class lhs, IClass rhs)
        {
            if (lhs is null) return rhs is null;

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Class lhs, IClass rhs) => !(lhs == rhs);

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
