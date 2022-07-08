using Microsoft.Extensions.Configuration;

namespace KysectAcademyTask;

public class Deserialize
{
    public static string? deserializer()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json").Build();
        return config.GetValue<string>("Path1");
    }
    
    public static string? serializer()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json").Build();
        return config.GetValue<string>("Path2");
    }

}