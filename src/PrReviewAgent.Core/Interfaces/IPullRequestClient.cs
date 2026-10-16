using PrReviewAgent.Core.Models;

namespace PrReviewAgent.Core.Interfaces;

public interface IPullRequestClient
{
    Task<PullRequestContext> GetPullRequestAsync(string repositoryId, int pullRequestId, CancellationToken cancellationToken = default);
}
