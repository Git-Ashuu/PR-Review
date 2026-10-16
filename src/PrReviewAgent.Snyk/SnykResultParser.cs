namespace PrReviewAgent.Snyk;

public static class SnykResultParser
{
    public static IReadOnlyList<SnykFinding> Parse(string json)
    {
        // TODO: parse Snyk API/CLI JSON output into SnykFinding list.
        _ = json;
        return Array.Empty<SnykFinding>();
    }
}
