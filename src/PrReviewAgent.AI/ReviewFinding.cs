namespace PrReviewAgent.AI;

public sealed class ReviewFinding
{
    public required string Category { get; init; }
    public required string Severity { get; init; }
    public required string Message { get; init; }
    public string? FilePath { get; init; }
    public int? LineNumber { get; init; }
    public string? Recommendation { get; init; }
}
