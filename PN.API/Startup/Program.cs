using Microsoft.Extensions.Logging.Console;

namespace PN.API.Startup;

public static class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
            .ConfigureLogging(builder =>
                builder.AddSimpleConsole(options => options.ColorBehavior = LoggerColorBehavior.Enabled));
}