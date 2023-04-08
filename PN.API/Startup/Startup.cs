using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PN.API.Controllers;
using PN.API.Options;
using PN.API.Services;
using PN.Infrastructure.Options;
using PN.Infrastructure.Persistence;

namespace PN.API.Startup;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        DotNetEnv.Env.Load();

        services.AddOptions();

        services.Configure<AppSettingsDatabaseOptions>(Configuration.GetSection("DatabaseOptions"));
        services.AddSingleton<IDatabaseOptions>(sp => sp.GetRequiredService<IOptions<AppSettingsDatabaseOptions>>().Value);


        services.AddControllers();
        services.AddScoped<DialogController>();
        services.AddScoped<HealthcheckController>();
        services.AddScoped<IDialogService, DialogService>();
        services.AddScoped<IDialogRepository, DialogRepository>();

        var config = Environment.GetEnvironmentVariable("MyMongoDB");
        var client = new MongoClient(config);

        services.AddSingleton<IMongoClient>(client);

        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder => builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
    {
        app.UseRouting();
        app.UseCors("AllowSpecificOrigin");

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}