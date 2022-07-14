namespace KysectAcademyTask.Config;

public class FileFilter
{
    public FileFilter()
    {
        new Deserializer().GetFileFilter();
    }
    
    public List<string>? ExtensionsBlackList { get; set; }
    public List<string>? ExtensionsWhiteList { get; set; }
    public List<string>? DirectoriesBlackList { get; set; }
    public List<string>? DirectoriesWhiteList { get; set; }
}