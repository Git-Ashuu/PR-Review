using PrReviewAgent.Core.Interfaces;
using PrReviewAgent.Core.Models;

namespace PrReviewAgent.Snyk;

public sealed class SnykClient : ISnykClient
{
    public Task<IReadOnlyList<Finding>> GetFindingsAsync(PullRequestContext context, CancellationToken cancellationToken = default)
    {
        // TODO: query Snyk for latest scan status/results tied to this PR/commit.
        throw new NotImplementedException();
    }
}
