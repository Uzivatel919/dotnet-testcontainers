namespace DotNet.Testcontainers.Clients
{
  using System;
  using System.Collections.Concurrent;
  using Docker.DotNet;

  internal abstract class DockerApiClient
  {
    private static readonly ConcurrentDictionary<Uri, IDockerClient> Clients = new ConcurrentDictionary<Uri, IDockerClient>();

    protected DockerApiClient(Uri endpoint) : this(
      Clients.GetOrAdd(endpoint, _ =>
      {
        var client = new DockerClientConfiguration(endpoint).CreateClient();
        client.DefaultTimeout = TimeSpan.FromMinutes(5);
        return client;
      }))
    {
    }

    protected DockerApiClient(IDockerClient client)
    {
      this.Docker = client;
    }

    protected IDockerClient Docker { get; }
  }
}
