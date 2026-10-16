namespace PrReviewAgent.Core.Models;

public sealed class PullRequestContext
{
    public required string Organization { get; init; }
    public required string Project { get; init; }
    public required string RepositoryId { get; init; }
    public required int PullRequestId { get; init; }
    public required string SourceBranch { get; init; }
    public required string TargetBranch { get; init; }
    public string? Title { get; init; }
    public string? Author { get; init; }
}
