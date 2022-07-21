namespace KysectAcademyTask.Config;

public class AuthorFilter : IFilter
{
    public List<string> AuthorsBlackList { get; set; } = null!;
    public List<string> AuthorsWhiteList { get; set; } = null!;
    
    public IEnumerable<FileInfo> GetFiltredFiles(IEnumerable<FileInfo> list, Configuration configuration)
    {
        return list.Where(author => author.DirectoryName != null 
                                    && Convert.ToBoolean(configuration.AuthorFilter.AuthorsWhiteList
                                        .Any(x => author.DirectoryName.Contains(x))))
            .Except(list.Where(author => author.DirectoryName != null
                                         && Convert.ToBoolean(configuration.AuthorFilter.AuthorsBlackList
                                             .Any(x => author.DirectoryName.Contains(x)))));
    }
}