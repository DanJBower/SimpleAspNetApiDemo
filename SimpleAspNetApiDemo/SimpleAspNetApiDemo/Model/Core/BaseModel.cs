using System.Collections.Immutable;

namespace SimpleAspNetApiDemo.Model.Core
{
    public abstract record BaseModel
    {
        public ImmutableList<Link> Links { get; init; }

        // TODO See https://code-maze.com/hateoas-aspnet-core-web-api/
        // TODO See https://medium.com/@ylerjen/implementing-hateoas-in-your-asp-netcore-webapi-2139df4e7b0c
    }
}
