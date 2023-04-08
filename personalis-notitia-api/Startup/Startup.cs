using MongoDB.Driver;
using personalis_notitia_api.Controllers;
using personalis_notitia_api.Models;
using personalis_notitia_api.Models.Base;
using personalis_notitia_api.Options;
using personalis_notitia_api.Persistence.Dialog;
using personalis_notitia_api.Persistence.Mongo;
using personalis_notitia_api.Services;

namespace personalis_notitia_api.Startup;

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

        services.AddOptions<DatabaseOptions>()
            .Bind(Configuration.GetSection("DatabaseOptions"));

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