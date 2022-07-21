namespace KysectAcademyTask.Config;

public class FileFilter : IFilter
{
    public List<string> ExtensionsBlackList { get; set; } = null!;
    public List<string> ExtensionsWhiteList { get; set; } = null!;
    public List<string> DirectoriesBlackList { get; set; } = null!;
    
    public IEnumerable<FileInfo> GetFiltredFiles(IEnumerable<FileInfo> list, Configuration configuration)
    {
        return list.Where(f =>
                Convert.ToBoolean(configuration.FileFilter.ExtensionsWhiteList
                    .Any(x => f.Name.EndsWith(x))))
            .Except(list.Where(dir => dir.DirectoryName != null &&
                                      Convert.ToBoolean(configuration.FileFilter.ExtensionsBlackList
                                          .Any(x => dir.DirectoryName.Contains(x)))));
    }
}