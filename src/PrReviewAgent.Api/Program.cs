using PrReviewAgent.AI;
using PrReviewAgent.Application;
using PrReviewAgent.AzureDevOps;
using PrReviewAgent.Core.Configuration;
using PrReviewAgent.Core.Interfaces;
using PrReviewAgent.Snyk;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.Configure<AzureOpenAIOptions>(builder.Configuration.GetSection(AzureOpenAIOptions.SectionName));
builder.Services.Configure<AzureDevOpsOptions>(builder.Configuration.GetSection(AzureDevOpsOptions.SectionName));
builder.Services.Configure<SnykOptions>(builder.Configuration.GetSection(SnykOptions.SectionName));

builder.Services.AddSingleton<IPullRequestClient, PullRequestClient>();
builder.Services.AddSingleton<IDiffClient, DiffClient>();
builder.Services.AddSingleton<ICommentPublisher, CommentPublisher>();
builder.Services.AddSingleton<IStatusPublisher, StatusPublisher>();
builder.Services.AddSingleton<IAiReviewer, AzureOpenAIReviewer>();
builder.Services.AddSingleton<ISnykClient, SnykClient>();
builder.Services.AddSingleton<ReviewAggregator>();
builder.Services.AddSingleton<PromptBuilder>();
builder.Services.AddSingleton<ReviewOrchestrator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();
app.Run();

public partial class Program;
