namespace SimpleAspNetApiDemo.Model
{
    public record Link
    {
        public string Path { get; init; }
        public string Relation { get; init; }
        public string Type { get; init; }
    }
}
