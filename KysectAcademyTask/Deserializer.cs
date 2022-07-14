using KysectAcademyTask.Config;
using Microsoft.Extensions.Configuration;

namespace KysectAcademyTask;

public class Deserializer
{

    public Deserializer()
    {
        GetContent();
    }
    
    public string? RootPath { get; set; }
    public ResultFilter? ResultFilter { get; set; }
    public FileFilter? FileFilter { get; set; }
    public AuthorFilter? AuthorFilter{ get; set; }
    
    public static Deserializer? GetContent()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json").Build();
        
        IConfigurationSection section = config.GetSection(nameof(Deserializer));
        Deserializer? rootPath = section.Get<Deserializer>();
        return rootPath;
    }
}