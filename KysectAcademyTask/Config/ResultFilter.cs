namespace KysectAcademyTask.Config;

public class ResultFilter
{
    public ResultFilter(string pathForResults, string fileType)
    {
        PathForResults = pathForResults;
        FileType = fileType;
    }

    public string PathForResults { get; set; }
    public string FileType { get; set; }
}