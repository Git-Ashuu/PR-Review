using System.Text;
using PrReviewAgent.Core.Models;

namespace PrReviewAgent.Application;

public sealed class PromptBuilder
{
    private const string SystemPrompt = """
        You are an advisory code reviewer for .NET pull requests. Focus on:
        functional bugs, null-reference risks, async/await issues, exception handling,
        resource disposal, LINQ inefficiencies, EF Core issues, concurrency/thread-safety,
        input validation, security-sensitive coding issues, API compatibility, and missing
        tests. Do NOT approve, merge, block, or modify code. Do NOT override Snyk, SonarQube,
        compiler, or test results. Avoid nitpicky style-only comments.
        """;

    public string BuildSystemPrompt() => SystemPrompt;

    public string BuildUserPrompt(PullRequestContext context, IReadOnlyList<FileDiff> diffs)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Pull Request #{context.PullRequestId}: {context.Title}");
        sb.AppendLine($"Source: {context.SourceBranch} -> Target: {context.TargetBranch}");
        sb.AppendLine();
        foreach (var diff in diffs)
        {
            sb.AppendLine($"--- {diff.FilePath} ({diff.ChangeType}) ---");
            sb.AppendLine(diff.Patch);
            sb.AppendLine();
        }
        return sb.ToString();
    }
}
