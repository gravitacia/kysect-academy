namespace KysectAcademyTask;

public class Comparator
{
    private Configuration _configuration = new Configuration();

    public double CompareAlgorithm(string firstPath, string secondPath)
    {
        if (firstPath == null) throw new Exception("Invalid path!");
        if (secondPath == null) throw new Exception("Invalid path!");

        var dir2 = new DirectoryInfo(secondPath);
        var dir1 = new DirectoryInfo(firstPath);

        IEnumerable<FileInfo> firstList = dir1.GetFiles("*.*", SearchOption.AllDirectories);
        IEnumerable<FileInfo> secondList = dir2.GetFiles("*.*", SearchOption.AllDirectories);

        double result = new ComparisonLogic().CompareFolders(firstList, secondList);


        foreach (FileInfo curFirstFile in firstList)
        {
            foreach (FileInfo curSecondFile in secondList)
            {
                if (Convert.ToString(_configuration.FileFilter?.ExtensionsWhiteList) == curFirstFile.Extension
                    && Convert.ToString(_configuration.FileFilter?.ExtensionsWhiteList) == curSecondFile.Extension)
                {
                    if (!dir1.GetDirectories()
                            .Contains<>(Convert.ToString(_configuration.FileFilter?.DirectoriesBlackList))
                        || !dir2.GetDirectories()
                            .Contains<>(Convert.ToString(_configuration.FileFilter?.DirectoriesBlackList)))
                    {

                    }
                }
            }
        }

        return result;
    }
}