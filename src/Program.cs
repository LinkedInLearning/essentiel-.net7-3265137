using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.Metrics;

namespace ctrl_02;
class Program
{
    // dotnet tool update -g dotnet-counters
    // bash : export PATH="$PATH:/home/vscode/.dotnet/tools"
    static void Main(string[] args)
    {
      var builder = Host.CreateDefaultBuilder();
      
      builder.ConfigureServices((context, services) =>
      {
        services.AddSingleton<Meter>(_ => new Meter(nameof(ctrl_02), "1.0.0"));
        services.AddSingleton<IMessageProvider, IncMessageService>();
        services.AddHostedService<AppService>();
      });
      using var host = builder.Build();

      host.Run();
    }
}
