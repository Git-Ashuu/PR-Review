using PrReviewAgent.Core.Interfaces;
using PrReviewAgent.Core.Models;

namespace PrReviewAgent.AzureDevOps;

public sealed class StatusPublisher : IStatusPublisher
{
    public Task PublishAsync(PullRequestContext context, string state, string description, CancellationToken cancellationToken = default)
    {
        // TODO: publish PR status via Azure DevOps REST API. AI status remains advisory.
        throw new NotImplementedException();
    }
}
