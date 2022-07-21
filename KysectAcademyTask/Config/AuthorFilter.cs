namespace KysectAcademyTask.Config;

public class AuthorFilter : IFilter
{
    public List<string> AuthorsBlackList { get; set; } = null!;
    public List<string> AuthorsWhiteList { get; set; } = null!;
    
    public IEnumerable<FileInfo> GetFiltredFiles(IEnumerable<FileInfo> list)
    {
        return list.Where(author => author.DirectoryName != null 
                                    && Convert.ToBoolean(this.AuthorsWhiteList
                                        .Any(x => author.DirectoryName.Contains(x))))
            .Except(list.Where(author => author.DirectoryName != null
                                         && Convert.ToBoolean(this.AuthorsBlackList
                                             .Any(x => author.DirectoryName.Contains(x)))));
    }
}