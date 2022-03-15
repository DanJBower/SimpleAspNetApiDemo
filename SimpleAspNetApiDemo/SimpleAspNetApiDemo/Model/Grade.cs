using SimpleAspNetApiDemo.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleAspNetApiDemo.Model
{
    public class Grade : IGrade
    {
        [Required]
        public IStudent Student { get; set; }

        [Required]
        public IClass Class { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Result { get; set; }

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

        public int CompareTo(IGrade other)
        {
            return Result.CompareTo(other.Result);
        }

        public int CompareTo(object other)
        {
            if (other is IGrade otherGrade)
                return CompareTo(otherGrade);

            throw new ArgumentException("Can only compare to other grades.");
        }

        public static bool operator >(Grade lhs, IGrade rhs)
        {
            return lhs.CompareTo(rhs) > 0;
        }

        public static bool operator <(Grade lhs, IGrade rhs)
        {
            return lhs.CompareTo(rhs) < 0;
        }

        public static bool operator >=(Grade lhs, IGrade rhs)
        {
            return lhs.CompareTo(rhs) >= 0;
        }

        public static bool operator <=(Grade lhs, IGrade rhs)
        {
            return lhs.CompareTo(rhs) <= 0;
        }

        public override string ToString()
        {
            return $"{Name} : {Student.Name} - {Result}";
        }
    }
}
