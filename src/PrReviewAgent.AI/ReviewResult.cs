namespace PrReviewAgent.AI;

public sealed class ReviewResult
{
    public IReadOnlyList<ReviewFinding> Findings { get; init; } = Array.Empty<ReviewFinding>();
    public string? Summary { get; init; }
}
