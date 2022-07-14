namespace KysectAcademyTask.Config;

public class AuthorFilter
{
    public AuthorFilter()
    {
        new Deserializer().GetAuthorFilter();
    }
    
    public List<string>? AuthorsBlackList { get; set; }
    public List<string>? AuthorsWhiteList { get; set; }
}