using Microsoft.Extensions.Configuration;

namespace KysectAcademyTask;

public class Configuration
{
    public string? RootPath { get; set; }
    public string? PathForResults { get; set; }
    public static Configuration? LoadContent()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json").Build();
        
        IConfigurationSection section = config.GetSection(nameof(Configuration));
        Configuration? rootPath = section.Get<Configuration>();
        return rootPath;
    }

}