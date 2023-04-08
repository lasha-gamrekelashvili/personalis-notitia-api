using PN.Infrastructure.Options;

namespace PN.API.Options;

public class AppSettingsDatabaseOptions : IDatabaseOptions
{
    public string? DatabaseName { get; set; }
}