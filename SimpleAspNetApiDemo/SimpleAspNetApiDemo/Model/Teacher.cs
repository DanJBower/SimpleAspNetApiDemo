using SimpleAspNetApiDemo.Model.Core;
using System;
using System.Collections.Immutable;

namespace SimpleAspNetApiDemo.Model
{
    public record Teacher : BaseModel
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        // TODO See https://code-maze.com/hateoas-aspnet-core-web-api/
        // TODO See https://medium.com/@ylerjen/implementing-hateoas-in-your-asp-netcore-webapi-2139df4e7b0c

        public static ImmutableList<Link> CreateLinksForTeacher()
        {
            return null;
        }
    }
}
