namespace PrReviewAgent.Core.Models;

public sealed class FileDiff
{
    public required string FilePath { get; init; }
    public required string ChangeType { get; init; }
    public required string Patch { get; init; }
}
