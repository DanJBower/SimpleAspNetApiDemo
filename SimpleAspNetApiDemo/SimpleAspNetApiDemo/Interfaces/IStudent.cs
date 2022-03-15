using System;
using System.Collections.Generic;

namespace SimpleAspNetApiDemo.Interfaces
{
    public interface IStudent : IEquatable<IStudent>
    {
        Guid Id { get; }
        string Name { get; }
        int Age { get; }
        ISubject FavouriteSubject { get; }
        IList<IClass> Classes { get; }
    }
}
