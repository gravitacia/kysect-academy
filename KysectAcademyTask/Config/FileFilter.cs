namespace KysectAcademyTask.Config;

public class FileFilter
{
    public List<string>? ExtensionsBlackList { get; set; }
    public List<string>? ExtensionsWhiteList { get; set; } 
    public List<string>? DirectoriesBlackList { get; set; } 

    public bool IsExtensionsBlackListExist()
    {
        return this.DirectoriesBlackList?.Count != 0;
    }
    
    public bool IsExtensionsWhiteListExist()
    {
        return this.ExtensionsWhiteList?.Count != 0;
    }
    
    public bool IsDirectoriesBlackListExist()
    {
        return this.DirectoriesBlackList?.Count != 0;
    }
}