using KysectAcademyTask.Config;

namespace KysectAcademyTask;

public class OutputInConsole : IOutput
{
    public void OutputResults(Configuration configuration)
    {
        if (configuration.ResultFilter.PathForResults.Length == 0) return;
        double compareResult = new Comparator().CompareAlgorithm(configuration.RootPath[0], configuration.RootPath[1]);
        Console.WriteLine($"First path: {configuration.RootPath[0]}, Second path: {configuration.RootPath[1]}, Percent: {compareResult} ");

    }
}