using KysectAcademyTask.Config;

namespace KysectAcademyTask;

public class OutputInConsole : IOutput
{
    public void OutputResults(Configuration configuration, double compareResult)
    {
        if (configuration.ResultFilter.PathForResults.Length == 0) return;
        Console.WriteLine($"First path: {configuration.RootPath[0]}, " +
                          $"Second path: {configuration.RootPath[1]}," +
                          $" Percent: {compareResult} ");

    }
}