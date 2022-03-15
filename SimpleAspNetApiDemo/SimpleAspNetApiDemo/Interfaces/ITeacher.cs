using System;
using System.Collections.Generic;

namespace SimpleAspNetApiDemo.Interfaces
{
    public interface ITeacher : IEquatable<ITeacher>
    {
        Guid Id { get; }
        string Name { get; }
        IList<IClass> Classes { get; }
    }
}
