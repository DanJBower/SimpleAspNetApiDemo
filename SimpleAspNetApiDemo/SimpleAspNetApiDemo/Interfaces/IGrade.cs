using System;

namespace SimpleAspNetApiDemo.Interfaces
{
    public interface IGrade : IEquatable<IGrade>, IComparable<IGrade>, IComparable
    {
        IStudent Student { get; }
        IClass Class { get; }
        string Name { get; }
        int Result { get; }
    }
}
