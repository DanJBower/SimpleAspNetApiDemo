using System;

namespace SimpleAspNetApiDemo.Interfaces
{
    public interface IGrade : IEquatable<IGrade>
    {
        IStudent Student { get; }
        IClass Class { get; }
        string Name { get; }
        int Result { get; }
    }
}
