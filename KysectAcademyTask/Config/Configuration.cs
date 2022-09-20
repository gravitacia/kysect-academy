using Microsoft.Extensions.Configuration;

namespace KysectAcademyTask.Config;

public class Configuration
{

    public Configuration()
    {
        LoadContent();
    }
    
    public List<string> RootPath { get; set; } = null!;
    public ResultFilter ResultFilter { get; set; } = null!;
    public FileFilter FileFilter { get; set; } = null!;
    public AuthorFilter AuthorFilter{ get; set; } = null!;
    public SubmissionFilter SubmissionFilter { get; set; } = null!;
    
    public bool LoadPreviousResults { get; set; }
    
    public static Configuration LoadContent()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json").Build();
        
        IConfigurationSection section = config.GetSection(nameof(Configuration));
        Configuration rootPath = section.Get<Configuration>();
        return rootPath;
    }
}