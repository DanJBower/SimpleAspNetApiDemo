using SimpleAspNetApiDemo.Model;
using System;
using System.Collections.Generic;

namespace SimpleAspNetApiDemo.Interfaces
{
    public interface IClass : IEquatable<IClass>
    {
        Guid Id { get; }
        string Name { get; }
        IList<Student> Students { get; }
        IList<Grade> Grades { get; }
        ITeacher Teacher { get; }
    }
}
