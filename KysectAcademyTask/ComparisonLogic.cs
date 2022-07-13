//using System.Security.Cryptography;
using System.Text.Json;
using NetDiff;

namespace KysectAcademyTask;

public class ComparisonLogic
{
    public async void CompareFilesInOneFolder(string? path, string? pathToSerialize)
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
                percent = Convert.ToDouble(count) / Convert.ToDouble(str1.Length);
            }
            else
            {
                percent = Convert.ToDouble(count) / Convert.ToDouble(str2.Length);
            }

            var comparisonResult = new ComparisonResult(str1, str2, percent);
            if (pathToSerialize == null) continue;
            await using var fs = new FileStream(pathToSerialize, FileMode.OpenOrCreate);
            await JsonSerializer.SerializeAsync<ComparisonResult>(fs, comparisonResult);
            Console.WriteLine("Data has been saved to file");
        }
    }

    public Dictionary<string, double> CompareFilesByBites(string? firstPath, string? secondPath)
    {
        if (firstPath == null) throw new Exception("Your path are empty!");
        if (secondPath == null) throw new Exception("Your path are empty!");

        string[] allFirstPathFiles = Directory.GetFiles(firstPath);
        string[] allSecondPathFiles = Directory.GetFiles(secondPath);
        
        int count = 0;

        var percents = new Dictionary<string, double>();

        foreach (string curFirstFile in allFirstPathFiles)
        {
            foreach (string curSecondFile in allSecondPathFiles)
            {
                using (FileStream first = File.OpenRead(curFirstFile))
                using (FileStream second = File.OpenRead(curSecondFile))
                {
                    for (int i = 0; i < first.Length; i++)
                    {
                        if (first.ReadByte() != second.ReadByte())
                            count++;
                    }
                }
                
                string str1 = File.ReadAllText(curFirstFile);
                string str2 = File.ReadAllText(curSecondFile);

                double percent;
                if (str1.Length > str2.Length)
                {
                    percent = Convert.ToDouble(count) / Convert.ToDouble(str1.Length);
                    string key = "Files being compared: " +  Path.GetFileName(str1) + "and" + Path.GetFileName(str2);
                    percents.Add(key, percent);
                }
                else
                {
                    percent = Convert.ToDouble(count) / Convert.ToDouble(str2.Length);
                    string key = "Files being compared: " +  Path.GetFileName(str1) + "and" +  Path.GetFileName(str2);
                    percents.Add(key, percent);
                }
            }
        }

        return percents;
    }


    public void CompareFolders(string? pathA, string? pathB)
        {
            if (pathA != null)
            {
                var dir1 = new System.IO.DirectoryInfo(pathA);
                if (pathB != null)
                {
                    var dir2 = new System.IO.DirectoryInfo(pathB);

                
                    IEnumerable<System.IO.FileInfo> list1 = dir1.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
                    IEnumerable<System.IO.FileInfo> list2 = dir2.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

                    
                    var myFileCompare = new FileCompare();

                    
                    bool areIdentical = list1.SequenceEqual(list2, myFileCompare);
                    
                    if (areIdentical == true)
                    {
                        Console.WriteLine("the two folders are the same");
                    }
                    else
                    {
                        Console.WriteLine("The two folders are not the same");
                    }
                
                    IEnumerable<FileInfo> queryCommonFiles = list1.Intersect(list2, myFileCompare);

                    if (queryCommonFiles.Any())
                    {
                        Console.WriteLine("The following files are in both folders:");
                        foreach (FileInfo v in queryCommonFiles)
                        {
                            Console.WriteLine(v.FullName); //shows which items end up in result list  
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no common files in the two folders.");
                    }
                
                    IEnumerable<FileInfo> queryList1Only = (from file in list1
                        select file).Except(list2, myFileCompare);

                    Console.WriteLine("The following files are in list1 but not list2:");
                    foreach (FileInfo v in queryList1Only)
                    {
                        Console.WriteLine(v.FullName);
                    }
                }
            }
        
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

    }
}