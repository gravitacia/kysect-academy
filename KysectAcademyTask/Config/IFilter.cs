namespace KysectAcademyTask.Config;

public interface IFilter
{
    public IEnumerable<FileInfo> GetFiltredFiles(IEnumerable<FileInfo> list);
}