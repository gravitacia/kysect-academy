namespace KysectAcademyTask.Config;

public class ConfigFilter
{
    private Configuration _configuration = new Configuration();
    
    public IEnumerable<FileInfo> GetFinalList(IEnumerable<FileInfo> list)
    {
        return list.Where(f =>
                (bool)_configuration.FileFilter?.ExtensionsWhiteList!
                    .Any(x => f.Name.EndsWith(x)))
            .Except(list.Where(dir => dir.DirectoryName != null &&
                                      (bool)_configuration.FileFilter?.ExtensionsBlackList!
                                          .Any(x => dir.DirectoryName.Contains(x))))
            .Intersect(list.Where(author => author.DirectoryName != null 
                                            && (bool)_configuration.AuthorFilter?.AuthorsWhiteList!
                                                .Any(x => author.DirectoryName.Contains(x))))
            .Except(list.Where(author => author.DirectoryName != null 
                                         && (bool)_configuration.AuthorFilter?.AuthorsBlackList!
                                             .Any(x => author.DirectoryName.Contains(x))))
            .Intersect(list.Where(dir => dir.DirectoryName != null &&
                                         (bool)_configuration.SubmissionFilter?.SubmissionDate!
                                             .Any(x => dir.DirectoryName.Contains(x)))
                .Intersect(list.Where(dir => dir.DirectoryName != null &&
                                             (bool)_configuration.SubmissionFilter?.HomeworkName!
                                                 .Any(x => dir.DirectoryName.Contains(x)))));
    }
}