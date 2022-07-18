using Microsoft.Extensions.Configuration;

namespace KysectAcademyTask.Config;

public class Configuration
{

    public Configuration()
    {
        LoadContent();
    }
    
    public string? RootPath { get; set; }
    public ResultFilter? ResultFilter { get; set; }
    public FileFilter? FileFilter { get; set; }
    public AuthorFilter? AuthorFilter{ get; set; }
    public SubmissionFilter? SubmissionFilter { get; set; }
    
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