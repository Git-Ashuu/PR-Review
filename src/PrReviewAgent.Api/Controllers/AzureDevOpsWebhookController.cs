using Microsoft.AspNetCore.Mvc;
using PrReviewAgent.Application;

namespace PrReviewAgent.Api.Controllers;

[ApiController]
[Route("api/webhooks/azuredevops")]
public sealed class AzureDevOpsWebhookController : ControllerBase
{
    private readonly ReviewOrchestrator _orchestrator;
    private readonly ILogger<AzureDevOpsWebhookController> _logger;

    public AzureDevOpsWebhookController(ReviewOrchestrator orchestrator, ILogger<AzureDevOpsWebhookController> logger)
    {
        _orchestrator = orchestrator;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> ReceiveAsync([FromBody] AzureDevOpsWebhookPayload payload, CancellationToken cancellationToken)
    {
        if (payload?.Resource is null)
        {
            return BadRequest("Missing resource.");
        }

        _logger.LogInformation("Received Azure DevOps event {EventType} for PR {PullRequestId}", payload.EventType, payload.Resource.PullRequestId);

        await _orchestrator.ReviewAsync(payload.Resource.Repository?.Id ?? string.Empty, payload.Resource.PullRequestId, cancellationToken);
        return Ok();
    }
}

public sealed class AzureDevOpsWebhookPayload
{
    public string? EventType { get; set; }
    public AzureDevOpsResource? Resource { get; set; }
}

public sealed class AzureDevOpsResource
{
    public int PullRequestId { get; set; }
    public AzureDevOpsRepository? Repository { get; set; }
}

public sealed class AzureDevOpsRepository
{
    public string? Id { get; set; }
    public string? Name { get; set; }
}
