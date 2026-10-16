using PrReviewAgent.Core.Models;

namespace PrReviewAgent.Core.Interfaces;

public interface IDiffClient
{
    Task<IReadOnlyList<FileDiff>> GetPullRequestDiffAsync(PullRequestContext context, CancellationToken cancellationToken = default);
}
