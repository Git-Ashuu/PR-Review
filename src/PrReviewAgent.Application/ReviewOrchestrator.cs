using PrReviewAgent.Core.Interfaces;
using PrReviewAgent.Core.Models;

namespace PrReviewAgent.Application;

public sealed class ReviewOrchestrator
{
    private readonly IPullRequestClient _pullRequestClient;
    private readonly IDiffClient _diffClient;
    private readonly IAiReviewer _aiReviewer;
    private readonly ISnykClient _snykClient;
    private readonly ICommentPublisher _commentPublisher;
    private readonly IStatusPublisher _statusPublisher;
    private readonly ReviewAggregator _aggregator;

    public ReviewOrchestrator(
        IPullRequestClient pullRequestClient,
        IDiffClient diffClient,
        IAiReviewer aiReviewer,
        ISnykClient snykClient,
        ICommentPublisher commentPublisher,
        IStatusPublisher statusPublisher,
        ReviewAggregator aggregator)
    {
        _pullRequestClient = pullRequestClient;
        _diffClient = diffClient;
        _aiReviewer = aiReviewer;
        _snykClient = snykClient;
        _commentPublisher = commentPublisher;
        _statusPublisher = statusPublisher;
        _aggregator = aggregator;
    }

    public async Task ReviewAsync(string repositoryId, int pullRequestId, CancellationToken cancellationToken = default)
    {
        var context = await _pullRequestClient.GetPullRequestAsync(repositoryId, pullRequestId, cancellationToken);
        var diffs = await _diffClient.GetPullRequestDiffAsync(context, cancellationToken);

        var aiFindings = await _aiReviewer.ReviewAsync(context, diffs, cancellationToken);
        var snykFindings = await _snykClient.GetFindingsAsync(context, cancellationToken);

        var findings = _aggregator.Aggregate(aiFindings, snykFindings);

        await _commentPublisher.PublishAsync(context, findings, cancellationToken);
        await _statusPublisher.PublishAsync(context, state: "succeeded", description: "AI advisory review complete.", cancellationToken);
    }
}
