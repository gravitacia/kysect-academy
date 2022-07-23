using KysectAcademyTask.Config;

namespace KysectAcademyTask;

public class Comparator
{
    public double CompareAlgorithm(string firstPath, string secondPath)

    {
        if (firstPath is null) throw new ArgumentNullException();
        if (secondPath is null) throw new ArgumentNullException();

        var firstDir = new DirectoryInfo(firstPath);
        var secondDir = new DirectoryInfo(secondPath);

        IEnumerable<FileInfo> firstList = firstDir.GetFiles("*.*", SearchOption.AllDirectories);
        IEnumerable<FileInfo> secondList = secondDir.GetFiles("*.*", SearchOption.AllDirectories);


        IEnumerable<FileInfo> finalFirstList = new ConfigFilter().GetFinalList(firstList);
        IEnumerable<FileInfo> finalSecondList = new ConfigFilter().GetFinalList(secondList);


        double result = CompareFolders(finalFirstList, finalSecondList);

        return result;
    }

    public List<List<double>> CompareAlgorithm(string path)
    {
        if (path is null) throw new ArgumentNullException();

        var dir = new DirectoryInfo(path);
        IEnumerable<FileInfo> list = dir.GetFiles("*.*", SearchOption.AllDirectories);
        IEnumerable<FileInfo> finalList = new ConfigFilter().GetFinalList(list);

        List<List<double>> result = CompareFilesInOneFolder(finalList);

        return result;
    }


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
                if (curFirstFile.DirectoryName is null || curSecondFile.DirectoryName is null)
                    throw new ArgumentNullException();
                using FileStream first = File.OpenRead(curFirstFile.DirectoryName);
                using FileStream second = File.OpenRead(curSecondFile.DirectoryName);

                double percent = new ComparisonLogic().CompareFiles(first, second);
                percentsForFile.Add(percent);
                tmpList.Add(percent);


                iterations++;

                Console.WriteLine($"Comparing {curFirstFile.Name} and {curSecondFile.Name}.");
                Console.WriteLine($"{iterations} in {secondList.Count() + firstList.Count()}");
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
            foreach (FileInfo curSecondFile in list)
            {
                if (curFirstFile.DirectoryName is null || curSecondFile.DirectoryName is null)
                    throw new ArgumentNullException();
                using FileStream first = File.OpenRead(curFirstFile.DirectoryName);
                using FileStream second = File.OpenRead(curSecondFile.DirectoryName);

                double percent = new ComparisonLogic().CompareFiles(first, second);
                
                percentsForFile.Add(percent);
            }

            percents.Add(percentsForFile);
        }

        return percents;
    }
}