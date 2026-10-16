using PrReviewAgent.Core.Models;

namespace PrReviewAgent.Core.Interfaces;

public interface IStatusPublisher
{
    Task PublishAsync(PullRequestContext context, string state, string description, CancellationToken cancellationToken = default);
}
