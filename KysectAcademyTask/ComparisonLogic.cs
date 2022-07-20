﻿
namespace KysectAcademyTask;

public class ComparisonLogic
{
    public double CompareFolders(IEnumerable<FileInfo> firstList, IEnumerable<FileInfo> secondList)
    {
        var percentsForFile = new List<double>();
        var percents = new List<List<double>>();
        var tmpList = new List<double>();
        var tmpListForPercent = new List<List<double>>();
        double finalPercent = 0.0;
        int iterations = 0;

        foreach (FileInfo curFirstFile in firstList)
        {
            foreach (FileInfo curSecondFile in secondList)
            {
                double percent = CompareFilesByBites(curFirstFile.DirectoryName, curSecondFile.DirectoryName);
                percentsForFile.Add(percent);
                tmpList.Add(percent);
                

                iterations++;
                
                Console.WriteLine($"Comparing {curFirstFile.Name} and {curSecondFile.Name}.");
                Console.WriteLine($"{iterations} in {secondList.Count()+firstList.Count()}");
            }

            percents.Add(percentsForFile);
            tmpListForPercent.Add(tmpList);
        }

        finalPercent += tmpListForPercent.Sum(curPercent => curPercent.Sum());

        finalPercent = percents.Aggregate(finalPercent, (current, curPercent) => current / curPercent.Sum());

        return finalPercent;

    }

    public List<List<double>> CompareFilesInOneFolder(IEnumerable<FileInfo> list)
    {
        var percentsForFile = new List<double>();
        var percents = new List<List<double>>();
        
        foreach (FileInfo curFirstFile in list)
        {
            percentsForFile.AddRange(list.Select(curSecondFile => 
                    CompareFilesByBites(curFirstFile.DirectoryName, curSecondFile.DirectoryName))
                .Where(percent => percent != 1.0));

            percents.Add(percentsForFile);
        }

        return percents;
    }
    
    private double CompareFilesByBites(string? firstFile, string? secondFile)
    {
        int count = 0;
        double percent = 0.0;
        
        if (firstFile is null) return percent; 
        if (secondFile is null) return percent;
        
        using FileStream first = File.OpenRead(firstFile);
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

        return percent;
    }
}

