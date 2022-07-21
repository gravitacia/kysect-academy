namespace KysectAcademyTask.Config;

public class SubmissionFilter : IFilter
{
    public List<string> HomeworkName { get; set; } = null!;
    public List<string> SubmissionDate { get; set; } = null!;

    public IEnumerable<FileInfo> GetFiltredFiles(IEnumerable<FileInfo> list)
    {
        return list.Where(dir => dir.DirectoryName != null &&
                                 Convert.ToBoolean(this.SubmissionDate
                                     .Any(x => dir.DirectoryName.Contains(x))))
            .Intersect(list.Where(dir => dir.DirectoryName != null &&
                                         Convert.ToBoolean(this.HomeworkName
                                             .Any(x => dir.DirectoryName.Contains(x)))));
    }
}