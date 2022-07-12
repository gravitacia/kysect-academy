using System.Text.Json;
using KysectAcademyTask;
using NetDiff;

string? path = Deserializer.DeserializeConfig();
string? pathToSerilize = Deserializer.SerializeConfig();

if (null != path)
{
    string[] allFiles = Directory.GetFiles(path);

    string str1;
    string str2;
    int count = 0;
    int percent;
    IEnumerable<DiffResult<char>> results;
    
    for (int i = 0; i < allFiles.Length - 1; i++)
    {
        str1 = File.ReadAllText(allFiles[i]);
        str2 = File.ReadAllText(allFiles[i+1]);

        results = DiffUtil.Diff(str1, str2);

        foreach (DiffResult<char> r in results.ToList())
        {
            if (r.Status == NetDiff.DiffStatus.Equal)
            {
                count++;
            }
        }

        if (str1.Length > str2.Length)
        {
            percent = count / str1.Length;
        }
        else
        {
            percent = count/str2.Length;
        }
        
        var property = new Properties(str1, str2, percent);
        if (pathToSerilize == null) continue;
        using (var fs = new FileStream(pathToSerilize, FileMode.OpenOrCreate))
        {
            await JsonSerializer.SerializeAsync<Properties>(fs, property);
            Console.WriteLine("Data has been saved to file");
        }
    }
}
else
{
    throw new Exception("Your path are empty!");
}
    