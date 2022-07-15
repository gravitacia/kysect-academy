using System.Text.Json;

namespace KysectAcademyTask;

public class Output
{
    public void OutputResult(string? path, string? pathToSerialize, Comparator comparator)
    {
        List<ComparisonResult> resultsList = new ComparisonLogic().CompareFiles(path, comparator);

        foreach (ComparisonResult curResult in resultsList)
        {
            if (pathToSerialize != null)
            {
                using var fs = new FileStream(pathToSerialize, FileMode.OpenOrCreate);
                JsonSerializer.SerializeAsync<ComparisonResult>(fs, curResult);
            }

            Console.WriteLine($"First file: {curResult.Path1}, Second file: {curResult.Path2}, Percent: {curResult.Percent} ");
        }
    }
}
    