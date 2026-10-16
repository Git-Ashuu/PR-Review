using PrReviewAgent.Core.Interfaces;
using PrReviewAgent.Core.Models;

namespace PrReviewAgent.AzureDevOps;

public sealed class DiffClient : IDiffClient
{
    public Task<IReadOnlyList<FileDiff>> GetPullRequestDiffAsync(PullRequestContext context, CancellationToken cancellationToken = default)
    {
        // TODO: retrieve iteration changes and build unified diffs.
        throw new NotImplementedException();
    }
}
