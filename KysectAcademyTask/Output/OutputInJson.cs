using System.Text.Json;
using KysectAcademyTask.Config;

namespace KysectAcademyTask;

public class OutputInJson : IOutput
{
    public void OutputResults(Configuration configuration, double compareResult)
    {
        if (configuration.ResultFilter.PathForResults.Length == 0) return;
        using var fs = new FileStream(configuration.ResultFilter.PathForResults, FileMode.OpenOrCreate);
        var result = new ComparisonResult(configuration.RootPath[0], configuration.RootPath[1], compareResult);
        JsonSerializer.SerializeAsync<ComparisonResult>(fs, result);
    }
}