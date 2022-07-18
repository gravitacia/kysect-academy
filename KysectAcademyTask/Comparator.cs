using KysectAcademyTask.Config;

namespace KysectAcademyTask;

public class Comparator
{
    public double CompareAlgorithm(string firstPath, string secondPath)

    {
        if (firstPath == null) throw new Exception("Invalid path!");
        if (secondPath == null) throw new Exception("Invalid path!");

        var firstDir = new DirectoryInfo(firstPath);
        var secondDir = new DirectoryInfo(secondPath);

        IEnumerable<FileInfo> firstList = firstDir.GetFiles("*.*", SearchOption.AllDirectories);
        IEnumerable<FileInfo> secondList = secondDir.GetFiles("*.*", SearchOption.AllDirectories);


        IEnumerable<FileInfo> finalFirstList = new ConfigFilter().GetFinalList(firstList);
        IEnumerable<FileInfo> finalSecondList = new ConfigFilter().GetFinalList(secondList);
        
        
        double result = new ComparisonLogic().CompareFolders(finalFirstList, finalSecondList);

        return result;
    }

    public List<List<double>> CompareAlgorithm(string path)
    {
        if (path == null) throw new Exception("Invalid path!");

        var dir = new DirectoryInfo(path);
        IEnumerable<FileInfo> list = dir.GetFiles("*.*", SearchOption.AllDirectories);
        IEnumerable<FileInfo> finalList = new ConfigFilter().GetFinalList(list);

        List<List<double>> result = new ComparisonLogic().CompareFilesInOneFolder(finalList);
        
        return result;
    }
}