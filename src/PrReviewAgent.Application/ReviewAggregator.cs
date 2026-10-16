using PrReviewAgent.Core.Models;

namespace PrReviewAgent.Application;

public sealed class ReviewAggregator
{
    public IReadOnlyList<Finding> Aggregate(IReadOnlyList<Finding> aiFindings, IReadOnlyList<Finding> snykFindings)
    {
        // Snyk findings remain authoritative; AI findings are advisory and appended.
        var result = new List<Finding>(snykFindings.Count + aiFindings.Count);
        result.AddRange(snykFindings);
        result.AddRange(aiFindings);
        return result;
    }
}
