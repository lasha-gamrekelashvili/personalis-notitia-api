using personalis_notitia_api.Controllers;
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
        services.AddControllers();
        services.AddScoped<DialogController>();
        services.AddScoped<HealthcheckController>();
        services.AddScoped<IDialogService,DialogService>();
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