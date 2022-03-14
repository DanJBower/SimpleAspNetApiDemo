using SimpleAspNetApiDemo.Model;
using System;
using System.Collections.Generic;

namespace SimpleAspNetApiDemo.Interfaces
{
    public interface IClass : IEquatable<IClass>
    {
        Guid Id { get; set; }
        string Name { get; set; }
        IList<Student> Students { get; set; }
        IList<Grade> Grades { get; set; }
        ITeacher Teacher { get; set; }
    }
}
