namespace KysectAcademyTask.Config;

public class ConfigFilter
{
    private Configuration _configuration = new Configuration();
    
    public IEnumerable<FileInfo> GetFinalList(IEnumerable<FileInfo> list)
    {

        return  _configuration.FileFilter.GetFiltredFiles(list)
            .Intersect(_configuration.AuthorFilter.GetFiltredFiles(list))
            .Intersect(_configuration.SubmissionFilter.GetFiltredFiles(list));
    }
}