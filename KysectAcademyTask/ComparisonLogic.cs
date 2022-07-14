using System.Text.Json;
using NetDiff;

namespace KysectAcademyTask;

public class ComparisonLogic
{
    public async void CompareFilesInOneFolder(string? path, string? pathToSerialize, Comparator comparator)
    {
        if (path == null) throw new Exception("Your path are empty!");
        string[] allFiles = Directory.GetFiles(path);

        int count = 0;

        for (int i = 0; i < allFiles.Length - 1; i++)
        {
            for (int j = i + 1; j < allFiles.Length - 1; j++)
            {

                string str1 = File.ReadAllText(allFiles[i]);
                string str2 = File.ReadAllText(allFiles[j]);

                IEnumerable<DiffResult<char>> results = comparator.EntitiesCompare(str1, str2);

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

    public double CompareFilesByBites(string? firstFile, string? secondFile)
    {
        int count = 0;
        double percent = 0.0;
        
        if (firstFile != null)
        {
            using FileStream first = File.OpenRead(firstFile);
            if (secondFile != null)
            {
                using FileStream second = File.OpenRead(secondFile);
                for (int i = 0; i < first.Length; i++)
                {
                    if (first.ReadByte() != second.ReadByte())
                        count++;
                }
                
                string str1 = File.ReadAllText(firstFile);
                string str2 = File.ReadAllText(secondFile);

                if (str1.Length > str2.Length)
                {
                    percent = Convert.ToDouble(count) / Convert.ToDouble(str1.Length);

                }
                else
                {
                    percent = Convert.ToDouble(count) / Convert.ToDouble(str2.Length);
                }
            }
        }

        return percent;
    }


    public double CompareFolders(string? firstPath, string? secondPath)
    {
        double percent = 0.0;
        var percentsForFile = new List<double>();
        var percents = new List<List<double>>();
        var tmpList = new List<double>();
        var tmpListForPercent = new List<List<double>>();
        double finalPercent = 0.0;

        if (firstPath == null) throw new Exception("Invalid path!");
        if (secondPath == null) throw new Exception("Invalid path!");
        
        var dir2 = new DirectoryInfo(secondPath);
        var dir1 = new DirectoryInfo(firstPath);
                
        IEnumerable<FileInfo> list1 = dir1.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
        IEnumerable<FileInfo> list2 = dir2.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
                

        foreach (FileInfo curFirstFile in list1)
        {
            foreach (FileInfo curSecondFile in list2)
            {
                percent = CompareFilesByBites(curFirstFile.DirectoryName, curSecondFile.DirectoryName);
                percentsForFile.Add(percent);
                        
                if (percent >= 0.3)
                {
                    tmpList.Add(percent);
                }
            }
            percents.Add(percentsForFile);
            tmpListForPercent.Add(tmpList);
        }

        finalPercent += tmpListForPercent.Sum(curPercent => curPercent.Sum());

        finalPercent = percents.Aggregate(finalPercent, (current, curPercent) => current / curPercent.Sum());

        return finalPercent;
    }
}

