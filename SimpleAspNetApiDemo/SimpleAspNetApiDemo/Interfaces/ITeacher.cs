using System;
using System.Collections.Generic;

namespace SimpleAspNetApiDemo.Interfaces
{
    public interface ITeacher : IEquatable<ITeacher>
    {
        Guid Id { get; set; }
        string Name { get; set; }
        IList<IClass> Classes { get; set; }
    }
}
