namespace PrReviewAgent.Core.Configuration;

public sealed class SnykOptions
{
    public const string SectionName = "Snyk";

    public string OrgId { get; set; } = string.Empty;
    public string BaseUrl { get; set; } = "https://api.snyk.io";
}
