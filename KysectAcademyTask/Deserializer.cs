using Microsoft.Extensions.Configuration;

namespace KysectAcademyTask;

public class Deserializer
{
    public static string? DeserializeConfig()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json").Build();
        return config.GetValue<string>("Path1");
    }
    
    public static string? SerializeConfig()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json").Build();
        return config.GetValue<string>("Path2");
    }

}