using System;
using System.Collections.Generic;

namespace SimpleAspNetApiDemo.Interfaces
{
    public interface ISubject : IEquatable<ISubject>
    {
        Guid Id { get; }
        string Name { get; }
        string Description { get; }
        IList<IClass> Classes { get; }
    }
}
