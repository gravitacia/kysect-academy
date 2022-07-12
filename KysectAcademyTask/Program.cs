using System.Text.Json;
using KysectAcademyTask;
using NetDiff;

string? path = Deserializer.DeserializeConfig();
string? pathToSerialize = Deserializer.SerializeConfig();

int count = 0;

if (path != null)
{
    string[] allFiles = Directory.GetFiles(path);

    for (int i = 0; i < allFiles.Length - 1; i++)
    {
        string str1 = File.ReadAllText(allFiles[i]);
        string str2 = File.ReadAllText(allFiles[i+1]);

        IEnumerable<DiffResult<char>> results = DiffUtil.Diff(str1, str2);

        count += results.Count(r => r.Status == NetDiff.DiffStatus.Equal);

        double percent;
        if (str1.Length > str2.Length)
        {
            percent = count / str1.Length;
        }
        else
        {
            percent = count/str2.Length;
        }
        
        var property = new Properties(str1, str2, percent);
        if (pathToSerialize == null) continue;
        await using var fs = new FileStream(pathToSerialize, FileMode.OpenOrCreate);
        await JsonSerializer.SerializeAsync<Properties>(fs, property);
        Console.WriteLine("Data has been saved to file");
    }
}
else
{
    throw new Exception("Your path are empty!");
}
    