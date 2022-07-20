using System.Text.Json;
using KysectAcademyTask.Config;

namespace KysectAcademyTask;

public class OutputInJson : IOutput
{
    public void OutputResults(Configuration configuration)
    {
        if (configuration.ResultFilter.PathForResults.Length == 0) return;
        using var fs = new FileStream(configuration.ResultFilter.PathForResults, FileMode.OpenOrCreate);
        double compareResult = new Comparator().CompareAlgorithm(configuration.RootPath[0], configuration.RootPath[1]);
        var result = new ComparisonResult(configuration.RootPath[0], configuration.RootPath[1], compareResult);
        JsonSerializer.SerializeAsync<ComparisonResult>(fs, result);
    }
}