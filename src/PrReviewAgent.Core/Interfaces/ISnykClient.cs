using PrReviewAgent.Core.Models;

namespace PrReviewAgent.Core.Interfaces;

public interface ISnykClient
{
    Task<IReadOnlyList<Finding>> GetFindingsAsync(PullRequestContext context, CancellationToken cancellationToken = default);
}
