using PrReviewAgent.Core.Interfaces;
using PrReviewAgent.Core.Models;

namespace PrReviewAgent.AzureDevOps;

public sealed class CommentPublisher : ICommentPublisher
{
    public Task PublishAsync(PullRequestContext context, IReadOnlyList<Finding> findings, CancellationToken cancellationToken = default)
    {
        // TODO: post PR thread comments via Azure DevOps REST API.
        throw new NotImplementedException();
    }
}
