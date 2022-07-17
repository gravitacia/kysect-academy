namespace KysectAcademyTask.Config;

public class AuthorFilter
{
    public List<string>? AuthorsBlackList { get; set; }
    public List<string>? AuthorsWhiteList { get; set; }
    
    public bool IsAuthorsBlackListExist()
    {
        return this.AuthorsBlackList?.Count != 0;
    }
    
    public bool IsAuthorsWhiteListExist()
    {
        return this.AuthorsWhiteList?.Count != 0;
    }
}