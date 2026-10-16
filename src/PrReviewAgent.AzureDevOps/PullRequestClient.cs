using PrReviewAgent.Core.Interfaces;
using PrReviewAgent.Core.Models;

namespace PrReviewAgent.AzureDevOps;

public sealed class PullRequestClient : IPullRequestClient
{
    public Task<PullRequestContext> GetPullRequestAsync(string repositoryId, int pullRequestId, CancellationToken cancellationToken = default)
    {
        // TODO: call Azure DevOps REST API to retrieve pull request metadata.
        throw new NotImplementedException();
    }
}
