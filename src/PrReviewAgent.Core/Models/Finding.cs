namespace PrReviewAgent.Core.Models;

public enum FindingSeverity
{
    Info,
    Low,
    Medium,
    High,
    Critical
}

public enum FindingSource
{
    AzureOpenAI,
    Snyk
}

public sealed class Finding
{
    public required FindingSource Source { get; init; }
    public required FindingSeverity Severity { get; init; }
    public required string Category { get; init; }
    public required string Message { get; init; }
    public string? FilePath { get; init; }
    public int? LineNumber { get; init; }
    public string? Recommendation { get; init; }
}
