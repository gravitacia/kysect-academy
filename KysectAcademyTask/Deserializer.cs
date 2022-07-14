using KysectAcademyTask.Config;
using Microsoft.Extensions.Configuration;

namespace KysectAcademyTask;

public class Deserializer
{
    public Deserializer? GetRootPath()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json").Build();
        
        IConfigurationSection section = config.GetSection(nameof(Deserializer));
        return section.Get<Deserializer>();
    }

    public ResultFilter GetResultFilter()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json").Build();
        
        IConfigurationSection section = config.GetSection(nameof(Config.ResultFilter));
        ResultFilter? result =  section.Get<ResultFilter>();

        if (result != null)
        {
            var res = new ResultFilter(result.PathForResults, result.FileType);
            return res;
        }

        throw new InvalidOperationException();
    }

    public FileFilter? GetFileFilter()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json").Build();
        
        IConfigurationSection section = config.GetSection(nameof(FileFilter));
        return section.Get<FileFilter>();
    }

    public AuthorFilter? GetAuthorFilter()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json").Build();
        
        IConfigurationSection section = config.GetSection(nameof(AuthorFilter));
        return section.Get<AuthorFilter>();
    }
    
    public string? RootPath { get; set; }
}