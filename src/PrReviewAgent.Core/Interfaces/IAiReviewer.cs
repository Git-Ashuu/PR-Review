using PrReviewAgent.Core.Models;

namespace PrReviewAgent.Core.Interfaces;

public interface IAiReviewer
{
    Task<IReadOnlyList<Finding>> ReviewAsync(PullRequestContext context, IReadOnlyList<FileDiff> diffs, CancellationToken cancellationToken = default);
}
