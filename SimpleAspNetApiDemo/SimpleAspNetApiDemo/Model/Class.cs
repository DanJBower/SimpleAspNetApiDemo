using SimpleAspNetApiDemo.Interfaces;
using System;
using System.Collections.Generic;

namespace SimpleAspNetApiDemo.Model
{
    public class Class : IClass
    {
        public Guid Id { get; }
        public string Name { get; }
        public IList<Student> Students { get; }
        public IList<Grade> Grades { get; }
        public ITeacher Teacher { get; }

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
    }
}
