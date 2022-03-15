using SimpleAspNetApiDemo.Interfaces;
using System;
using System.Collections.Generic;

namespace SimpleAspNetApiDemo.Model
{
    public class Student : IStudent
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public IList<IClass> Classes { get; }

        public override bool Equals(object other) => Equals(other as IStudent);

        public bool Equals(IStudent other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;

            return Id == other.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(Student lhs, IStudent rhs)
        {
            if (lhs is null) return rhs is null;

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Student lhs, IStudent rhs) => !(lhs == rhs);
    }
}
