namespace nest.core.dominio
{
    public record ErrorResponse
    {
        public string Type { get; init; } = string.Empty;
        public string Title { get; init; } = string.Empty;
        public int Status { get; init; }
        public string? Detail { get; init; }
        public IEnumerable<ErrorItem>? Errors { get; init; }
        public string TraceId { get; init; } = string.Empty;
    }
}
