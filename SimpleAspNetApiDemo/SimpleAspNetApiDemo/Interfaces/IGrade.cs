using System;

namespace SimpleAspNetApiDemo.Interfaces
{
    public interface IGrade : IEquatable<IGrade>
    {
        IStudent Student { get; set; }
        IClass Class { get; set; }
        string Name { get; set; }
        int Result { get; set; }
    }
}
