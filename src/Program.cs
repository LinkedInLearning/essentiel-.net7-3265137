using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
        services.AddSingleton<IMessageProvider, IncMessageService>();
        services.AddHostedService<AppService>();
      });
      using var host = builder.Build();

      host.Run();
    }
}
