using System.Text.Json;
using KysectAcademyTask;
using NetDiff;

string? path = Deserializer.GetPath();
string? pathToSerialize = Deserializer.SetPath();

int count = 0;


if (path == null)
{
    throw new Exception("Your path are empty!");
}
else
{
    string[] allFiles = Directory.GetFiles(path);
    for (int i = 0; i < allFiles.Length - 1; i++)
    {
        string str1 = File.ReadAllText(allFiles[i]);
        string str2 = File.ReadAllText(allFiles[i + 1]);

        IEnumerable<DiffResult<char>> results = new EntitiesCompare().Comparison(str1, str2);

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

        var property = new Properties(str1, str2, percent);
        if (pathToSerialize == null) continue;
        await using var fs = new FileStream(pathToSerialize, FileMode.OpenOrCreate);
        await JsonSerializer.SerializeAsync<Properties>(fs, property);
        Console.WriteLine("Data has been saved to file");
    }
    
}