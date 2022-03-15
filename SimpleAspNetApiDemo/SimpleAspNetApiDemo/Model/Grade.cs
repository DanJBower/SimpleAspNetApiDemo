using SimpleAspNetApiDemo.Interfaces;
using System;

namespace SimpleAspNetApiDemo.Model
{
    public class Grade : IGrade
    {
        public IStudent Student { get; }
        public IClass Class { get; }
        public string Name { get; }
        public int Result { get; }

        public override bool Equals(object other) => Equals(other as IGrade);

        public bool Equals(IGrade other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;

            return Student.Equals(other.Student) && Class.Equals(other.Class);
        }

        public override int GetHashCode() => HashCode.Combine(Student, Class);

        public static bool operator ==(Grade lhs, IGrade rhs)
        {
            if (lhs is null) return rhs is null;

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Grade lhs, IGrade rhs) => !(lhs == rhs);
    }
}
