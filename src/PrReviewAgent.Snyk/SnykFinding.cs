namespace PrReviewAgent.Snyk;

public sealed class SnykFinding
{
    public required string Id { get; init; }
    public required string Severity { get; init; }
    public required string Title { get; init; }
    public string? FilePath { get; init; }
    public int? LineNumber { get; init; }
    public string? PackageName { get; init; }
    public string? PackageVersion { get; init; }
}
