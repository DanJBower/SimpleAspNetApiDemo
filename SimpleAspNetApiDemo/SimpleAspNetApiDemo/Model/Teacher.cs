using System;
using System.Collections.Immutable;

namespace SimpleAspNetApiDemo.Model
{
    public record Teacher
    {
        public Guid Id { get; init; }

        public string Name { get; init; }
    }
}
