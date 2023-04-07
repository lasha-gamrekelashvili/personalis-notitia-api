﻿using Microsoft.Extensions.Logging.Console;

namespace personalis_notitia_api.Startup;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureLogging(builder =>
                builder.AddSimpleConsole(options => options.ColorBehavior = LoggerColorBehavior.Enabled));
}