using System;
using System.Collections.Generic;

namespace SimpleAspNetApiDemo.Interfaces
{
    public interface IStudent : IEquatable<IStudent>
    {
        Guid Id { get; }
        string Name { get; }
        string Description { get; }
        IList<IClass> Classes { get; }
    }
}
