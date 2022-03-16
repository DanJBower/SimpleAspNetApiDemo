using System.Collections.Immutable;

namespace SimpleAspNetApiDemo.Model.Core
{
    public abstract record BaseModel
    {
        public ImmutableList<Link> Links { get; init; }
    }
}
