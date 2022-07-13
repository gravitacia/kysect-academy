using System.Text.Json;
using NetDiff;

namespace KysectAcademyTask;

public class ComparisonLogic
{
    public async void GetResults(string? path, string? pathToSerialize)
    {
        if (path == null) throw new Exception("Your path are empty!");
        string[] allFiles = Directory.GetFiles(path);
        
        int count = 0;
        for (int i = 0; i < allFiles.Length - 1; i++)
        {
            string str1 = File.ReadAllText(allFiles[i]);
            string str2 = File.ReadAllText(allFiles[i + 1]);

            IEnumerable<DiffResult<char>> results = new Comparator().EntitiesCompare(str1, str2);

            count += results.Count(r => r.Status == NetDiff.DiffStatus.Equal);

            double percent;
            if (str1.Length > str2.Length)
            {
                percent = count / str1.Length;
            }
            else
            {
                percent = count / str2.Length;
            }

            var comparisonResult = new ComparisonResult(str1, str2, percent);
            if (pathToSerialize == null) continue;
            await using var fs = new FileStream(pathToSerialize, FileMode.OpenOrCreate);
            await JsonSerializer.SerializeAsync<ComparisonResult>(fs, comparisonResult);
            Console.WriteLine("Data has been saved to file");
        }
    }
}