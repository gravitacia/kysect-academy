using KysectAcademyTask.Config;

namespace KysectAcademyTask;

public class Comparator
{
    public double CompareAlgorithm(string firstPath, string secondPath)
    {
        if (firstPath == null) throw new Exception("Invalid path!");
        if (secondPath == null) throw new Exception("Invalid path!");

        var firstDir = new DirectoryInfo(secondPath);
        var secondDir = new DirectoryInfo(firstPath);

        IEnumerable<FileInfo> firstList = firstDir.GetFiles("*.*", SearchOption.AllDirectories);
        IEnumerable<FileInfo> secondList = secondDir.GetFiles("*.*", SearchOption.AllDirectories);


        IEnumerable<FileInfo> finalFirstList = new ConfigFilter().GetFinalList(firstList);
        IEnumerable<FileInfo> finalSecondList = new ConfigFilter().GetFinalList(secondList);
        
        
        double result = new ComparisonLogic().CompareFolders(finalFirstList, finalSecondList);
        

        return result;
    }
}