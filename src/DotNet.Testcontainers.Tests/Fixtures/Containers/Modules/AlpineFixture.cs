namespace DotNet.Testcontainers.Tests.Fixtures.Containers.Modules
{
  using System.Threading.Tasks;
  using DotNet.Testcontainers.Containers.Builders;
  using DotNet.Testcontainers.Containers.Modules;
  using Xunit;

  public class AlpineFixture : ModuleFixture<TestcontainersContainer>, IAsyncLifetime
  {
    public AlpineFixture()
      : base(new TestcontainersBuilder<TestcontainersContainer>()
        .WithImage("alpine")
        .WithCommand(KeepTestcontainersUpAndRunning.Command)
        .Build())
    {
    }

    public async Task InitializeAsync()
    {
      return;

      await this.Container.StartAsync()
        .ConfigureAwait(false);

      await this.Container.StopAsync()
        .ConfigureAwait(false);
    }

    public Task DisposeAsync()
    {
      return Task.CompletedTask;

      return this.Container.DisposeAsync().AsTask();
    }
  }
}
