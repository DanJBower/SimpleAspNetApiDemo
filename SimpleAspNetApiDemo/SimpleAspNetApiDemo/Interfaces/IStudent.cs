using System;
using System.Collections.Generic;

namespace SimpleAspNetApiDemo.Interfaces
{
    public interface IStudent : IEquatable<IStudent>
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        IList<IClass> Classes { get; set; }
    }
}
