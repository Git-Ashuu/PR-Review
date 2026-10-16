namespace PrReviewAgent.Core.Configuration;

public sealed class AzureDevOpsOptions
{
    public const string SectionName = "AzureDevOps";

    public string Organization { get; set; } = string.Empty;
    public string Project { get; set; } = string.Empty;
    public string BaseUrl { get; set; } = "https://dev.azure.com";
}
