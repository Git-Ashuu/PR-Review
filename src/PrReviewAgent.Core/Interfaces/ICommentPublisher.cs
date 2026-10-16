using PrReviewAgent.Core.Models;

namespace PrReviewAgent.Core.Interfaces;

public interface ICommentPublisher
{
    Task PublishAsync(PullRequestContext context, IReadOnlyList<Finding> findings, CancellationToken cancellationToken = default);
}
