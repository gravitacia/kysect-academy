namespace KysectAcademyTask;

public class OutputInConsole
{
    public void OutputResults(ComparisonResult comparisonResult)
    {
        Console.WriteLine($"First path: {comparisonResult.Path1}, " +
                          $"Second path: {comparisonResult.Path2}," +
                          $" Percent: {comparisonResult.Percent} ");

    }
}