namespace KysectAcademyTask.Config;

public class FileFilter
{
    public List<string> ExtensionsBlackList { get; set; } = null!;
    public List<string> ExtensionsWhiteList { get; set; } = null!;
    public List<string> DirectoriesBlackList { get; set; } = null!;
}