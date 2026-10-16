using PrReviewAgent.Core.Interfaces;
using PrReviewAgent.Core.Models;

namespace PrReviewAgent.AI;

public sealed class AzureOpenAIReviewer : IAiReviewer
{
    public Task<IReadOnlyList<Finding>> ReviewAsync(PullRequestContext context, IReadOnlyList<FileDiff> diffs, CancellationToken cancellationToken = default)
    {
        // TODO: call Azure OpenAI via DefaultAzureCredential and translate ReviewResult into Findings.
        throw new NotImplementedException();
    }
}
