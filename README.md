# PrReviewAgent

## API configuration

The API reads Azure DevOps and Azure OpenAI settings from
[appsettings.json](./src/PrReviewAgent.Api/appsettings.json). Set `Organization`
and `Project` to the actual Azure DevOps names without placeholder brackets.
`AzureOpenAI:DeploymentName` must match the name of your Azure OpenAI deployment,
which is not necessarily the model name. The configured API version matches the
options model's default, `2024-10-21`.

Hosting environment variables can override these values using
`AzureDevOps__Organization`, `AzureDevOps__Project`, `AzureOpenAI__Endpoint`,
`AzureOpenAI__DeploymentName`, and `AzureOpenAI__ApiVersion`.

Do not store API keys in configuration files. The Azure OpenAI reviewer is still
a placeholder and is intended to use `DefaultAzureCredential`; API-key
authentication is not currently implemented. Rotate any previously exposed key.
These settings alone do not enable PR reviews until the service integrations
are implemented.

## Azure DevOps test pipeline

[azure-pipelines.yml](./azure-pipelines.yml) defines a manual-only validation
pipeline using a Microsoft-hosted Windows agent. It installs the .NET 10 SDK,
restores and builds [PrReviewAgent.slnx](./PrReviewAgent.slnx) in Release mode,
and runs both test projects with the existing xUnit/VSTest runner:

- [Unit tests](./tests/PrReviewAgent.UnitTests/PrReviewAgent.UnitTests.csproj)
- [Integration tests](./tests/PrReviewAgent.IntegrationTests/PrReviewAgent.IntegrationTests.csproj)

Test results appear in the pipeline's **Tests** tab. Coverlet collects Cobertura
coverage, which is published in **Code Coverage**, including on test failures
when coverage files are available. Test failures fail the pipeline; missing
coverage also fails the coverage publishing step. There is no coverage percentage
gate.

### Create and run the pipeline

1. Push the solution, source, tests, and pipeline YAML to an Azure DevOps
   repository. Do not commit generated `bin` or `obj` directories.
2. In Azure DevOps, open **Pipelines > New pipeline > Azure Repos Git**, then
   select the repository.
3. Choose **Existing Azure Pipelines YAML file** and select
   `/azure-pipelines.yml` on the appropriate branch.
4. Save the pipeline and select **Run pipeline**.

The project needs access to Microsoft-hosted agents and an available parallel
job. Package restore needs access to NuGet.org. No service connection, PAT,
Azure OpenAI key, or Snyk token is required for the current tests. This pipeline
does not deploy or start the API or call external services.

### Triggers and PR validation

Both automatic push and YAML PR triggers are disabled for initial testing.
To enable builds on pushes to `main`, replace `trigger: none` with:

```yaml
trigger:
  branches:
    include:
      - main
```

For **Azure Repos Git**, PR validation is configured through the target branch's
**Repos > Branches > Branch policies > Build validation** policy. Add this
pipeline there and select automatic validation if desired. The YAML `pr` setting
does not control Azure Repos branch-policy builds.

### Current test coverage limitation

Each test project currently contains one empty placeholder test. A passing run
confirms that restore, compilation, test discovery, and reporting work; it does
not validate application behavior or external integrations. Add real assertions
and integration fixtures before relying on this pipeline as a quality gate.
