namespace KysectAcademyTask.Config;

public class AuthorFilter
{
    public List<string> AuthorsBlackList { get; set; } = null!;
    public List<string> AuthorsWhiteList { get; set; } = null!;
}